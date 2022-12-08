using rexfinder_api.Models;
using rexfinder_api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace rexfinder_api.Controllers;

[ApiController]
[Route("api/[controller]")]

// I renamed this UserController from UserV1Controller
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserV1Repository _userRepository;

    public UserController(ILogger<UserController> logger, IUserV1Repository repository)
    {
        _logger = logger;
        _userRepository = repository;
    }

    // GET / get all users
    [HttpGet]
    public ActionResult<IEnumerable<UserV1>> GetUsers()
    {
        return Ok(_userRepository.GetAllUsers());
    }

    // GET / get one user by user id
    [HttpGet]
    [Route("{userId:int}")]
    public ActionResult<UserV1> GetUserById(int userId)
    {
        var user = _userRepository.GetUserById(userId);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    // GET / get current user
    [HttpGet]
    [Route("current")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<UserV1> GetCurrentUser()
    {

        if (HttpContext.User == null)
        {
            return Unauthorized();
        }

        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");

        var userId = Int32.Parse(userIdClaim.Value);

        var user = _userRepository.GetUserById(userId);

        if (user == null)
        {
            return Unauthorized();
        }

        return Ok(user);
    }

    // PUT / edit user by user id
    [HttpPut]
    [Route("current/edit")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<UserV1> UpdateUser(int userId, UpdateRequest editUser)
    {
        if (HttpContext.User == null)
        {
            return Unauthorized("Unable to find user, returns null");
        }

        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");

        var claimId = Int32.Parse(userIdClaim.Value);

        if (!ModelState.IsValid || editUser == null)
        {
            return BadRequest();
        }

        _userRepository.UpdateUser(claimId, editUser);
        // return Ok(new { message = "User updated" });


        var user = _userRepository.GetUserById(claimId);

        return Ok(user);

    }

    // DELETE / user by user id
    // This may not need auth since it's just for testing?
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpDelete]
    [Route("{userId:int}")]
    public ActionResult DeleteUser(int userId)
    {
        _userRepository.DeleteUserById(userId);
        return NoContent();
    }
}



