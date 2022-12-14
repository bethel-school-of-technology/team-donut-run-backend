using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

    // GET / get all saved places for a user by user id
    [HttpGet]
    [Route("all/{userId:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<IEnumerable<MyPlace>> GetAllMyPlacesByUserId(int userId)
    {
        return Ok(_myPlaceRepository.GetAllMyPlacesByUserId(userId));
    }

    // GET / all current user's my places
    [HttpGet]
    [Route("user/current")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<IEnumerable<MyPlace>> GetCurrentUserMyPlaces(int userId)
    {
        if (HttpContext.User == null) {
            return Unauthorized();
        }
        
        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        
        userId = Int32.Parse(userIdClaim.Value);

        if (userId == null) {
            return Unauthorized();
        }

        var userMyPlaces = _myPlaceRepository.GetAllMyPlacesByUserId(userId);

        if (userMyPlaces == null) {
            return NotFound();
        }
        
        return Ok(userMyPlaces);
    }

    // GET / a single my place by my place id
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

    // GET / a single my place by user id and google place id
    [HttpGet]
    // [Route("find/{userId:int}/{googlePlaceId}")]
    [Route("find/current-user/{googlePlaceId}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<MyPlace> GetMyPlaceByUserIdGooglePlaceId(int userId, string googlePlaceId)
    {
        if (HttpContext.User == null) {
            return Unauthorized();
        }

        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        
        userId = Int32.Parse(userIdClaim.Value);

        if (userId == null) {
            return Unauthorized();
        }

        var foundPlace = _myPlaceRepository.GetMyPlaceByUserIdGoogleId(userId, googlePlaceId);

        // if (foundPlace == null)
        // {
        //     return NotFound();
        // }

        return Ok(foundPlace);
    }

    // POST / create a new saved place
    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<MyPlace> CreateMyPlace(MyPlace newMyPlace)
    {
        if (HttpContext.User == null)
        {
            return Unauthorized();
        }

        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        var userId = Int32.Parse(userIdClaim.Value);
        newMyPlace.UserId = userId;

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

    // PUT / update saved my place with visited boolean
    [HttpPut]
    [Route("edit/{myPlaceId:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<MyPlace> UpdateMyPlace(MyPlace updatedMyPlace)
    {
        if (HttpContext.User == null)
        {
            return Unauthorized();
        }

        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        var userId = Int32.Parse(userIdClaim.Value);

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

    // DELETE / delete saved my place
    [HttpDelete]
    [Route("{myPlaceId:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult DeleteMyPlace(int myPlaceId)
    {
        if (HttpContext.User == null)
        {
            return Unauthorized();
        }

        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        var userId = Int32.Parse(userIdClaim.Value);
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