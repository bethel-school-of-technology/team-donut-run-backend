using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rexfinder_api.Models;
using rexfinder_api.Repositories;

namespace rexfinder_api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ExperiencesController : ControllerBase
{
    private readonly ILogger<ExperiencesController> _logger;
    private readonly IExperiencesRepository _experiencesRepository;

    public ExperiencesController(ILogger<ExperiencesController> logger, IExperiencesRepository repository)
    {
        _logger = logger;
        _experiencesRepository = repository;
    }

    [HttpGet]
    [Route("all/{userId:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<IEnumerable<Experiences>> GetAllExperiencesByUserId(int userId)
    {
        return Ok(_experiencesRepository.GetAllExperiencesByUserId(userId));
    }

    [HttpGet]
    [Route("user/current")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<IEnumerable<Experiences>> GetCurrentUserExperiences(int userId)
    {
        if (HttpContext.User == null) {
            return Unauthorized();
        }
        
        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        
        userId = Int32.Parse(userIdClaim.Value);

        if (userId == null) {
            return Unauthorized();
        }

        var userExperiences = _experiencesRepository.GetAllExperiencesByUserId(userId);

        if (userExperiences == null) {
            return NotFound();
        }
        
        return Ok(userExperiences);
    }

    [HttpGet]
    [Route("{experienceId:int}")]
    public ActionResult<Experiences> GetExperiencesById(int experienceId)
    {
        var experience = _experiencesRepository.GetExperiencesById(experienceId);

        if (experience == null)
        {
            return NotFound();
        }

        return Ok(experience);
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<Experiences> CreateExperience(Experiences newExperience)
    {
        if (HttpContext.User == null)
        {
            return Unauthorized();
        }

        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        var userId = Int32.Parse(userIdClaim.Value);
        newExperience.UserId = userId;

        if (userId == null)
        {
            return Unauthorized();
        }

        if (!ModelState.IsValid || newExperience == null)
        {
            return BadRequest();
        }

        var createdExperience = _experiencesRepository.CreateExperience(newExperience);
        return Created(nameof(GetExperiencesById), createdExperience);
    }

    [HttpPut]
    [Route("edit/{experienceId:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<Experiences> UpdateExperience(Experiences updatedExperience)
    {
        if (HttpContext.User == null)
        {
            return Unauthorized();
        }

        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        var userId = Int32.Parse(userIdClaim.Value);

        if (!ModelState.IsValid || updatedExperience == null)
        {
            return BadRequest();
        }

        if (userId == updatedExperience.UserId)
        {
            return Ok(_experiencesRepository.UpdateExperience(updatedExperience));
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpDelete]
    [Route("{experienceId:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult DeleteExperience(int experienceId)
    {
        if (HttpContext.User == null)
        {
            return Unauthorized();
        }

        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        var userId = Int32.Parse(userIdClaim.Value);
        var experienceToDelete = _experiencesRepository.GetExperiencesById(experienceId);

        if (userId == null)
        {
            return Unauthorized();
        }

        if (userId == experienceToDelete.UserId)
        {
            _experiencesRepository.DeleteExperienceById(experienceId);
            return NoContent();
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpGet]
    [Route("find/current-user/{googlePlaceId}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<Experiences> GetExperienceByUserIdGooglePlaceId(int userId, string googlePlaceId)
    {
        if (HttpContext.User == null) {
            return Unauthorized();
        }

        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        
        userId = Int32.Parse(userIdClaim.Value);

        if (userId == null) {
            return Unauthorized();
        }

        var foundExperience = _experiencesRepository.GetExperiencesByUserIdGoogleId(userId, googlePlaceId);

        return Ok(foundExperience);
    }
}