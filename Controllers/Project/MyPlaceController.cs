// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rexfinder_api.Models;
using rexfinder_api.Repositories;

namespace rexfinder_api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MyPlaceController : ControllerBase
{
    private readonly ILogger<MyPlaceController> _logger;
    private readonly IMyPlaceRepository _myPlaceRepository;

    public MyPlaceController(ILogger<MyPlaceController> logger, IMyPlaceRepository repository)
    {
        _logger = logger;
        _myPlaceRepository = repository;
    }

    // [HttpGet]
    // public ActionResult<IEnumerable<MyPlace>> GetAllMyPlaces()
    // {
    //     return Ok(_myPlaceRepository.GetAllMyPlaces());
    // }

    [HttpGet]
    [Route("{myPlaceId:int}")]
    public ActionResult<MyPlace> GetMyPlaceById(int myPlaceId)
    {
        var myPlace = _myPlaceRepository.GetMyPlaceById(myPlaceId);
        if (myPlace == null)
        {
            return NotFound();
        }

        return Ok(myPlace);
    }

    [HttpPost]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<MyPlace> CreateMyPlace(MyPlace newMyPlace)
    {
        if (HttpContext.User == null)
        {
            return Unauthorized();
        }

        // var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        // var userId = int.Parse(userIdClaim.Value);
        // newMyPlace.UserId = userId;
        var userId = 1;

        if (userId == null)
        {
            return Unauthorized();
        }

        if (!ModelState.IsValid || newMyPlace == null)
        {
            return BadRequest();
        }

        var createdMyPlace = _myPlaceRepository.CreateMyPlace(newMyPlace);
        return Created(nameof(GetMyPlaceById), createdMyPlace);
    }

    [HttpPut]
    [Route("{myPlaceId:int}")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<MyPlace> UpdateMyPlace(MyPlace updatedMyPlace)
    {
        if (HttpContext.User == null)
        {
            return Unauthorized();
        }

        // var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        // var userId = int.Parse(userIdClaim.Value);
        var userId = 1;

        if (!ModelState.IsValid || updatedMyPlace == null)
        {
            return BadRequest();
        }

        if (userId == updatedMyPlace.UserId)
        {
            return Ok(_myPlaceRepository.UpdateMyPlace(updatedMyPlace));
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpDelete]
    [Route("{myPlaceId:int}")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult DeleteMyPlace(int myPlaceId)
    {
        if (HttpContext.User == null)
        {
            return Unauthorized();
        }

        // var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        // var userId = int.Parse(userIdClaim.Value);
        var userId = 1;
        var myPlaceToDelete = _myPlaceRepository.GetMyPlaceById(myPlaceId);

        if (userId == null)
        {
            return Unauthorized();
        }

        if (userId == myPlaceToDelete.UserId)
        {
            _myPlaceRepository.DeleteMyPlaceById(myPlaceId);
            return NoContent();
        }
        else
        {
            return Unauthorized();
        }
    }
}