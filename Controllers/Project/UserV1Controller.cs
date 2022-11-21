using rexfinder_api.Models;
using rexfinder_api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace rexfinder_api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserV1Controller : ControllerBase
{
    private readonly ILogger<UserV1Controller> _logger;
    private readonly IUserV1Repository _userRepository;

    public UserV1Controller(ILogger<UserV1Controller> logger, IUserV1Repository repository)
    {
        _logger = logger;
        _userRepository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<object>> GetUsers()
    {
        return Ok(_userRepository.GetAllUsers());
    }

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

[HttpGet]
    [Route("current")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult<UserV1> GetCurrentUser()
    {

        if (HttpContext.User == null) {
            return Unauthorized();
        }
        
        var userIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
        
        var userId = Int32.Parse(userIdClaim.Value);

        var user = _userRepository.GetUserById(userId);

        if (user == null) {
            return Unauthorized();
        }

        return Ok(user);
    }
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpPut]
    [Route("{userId:int}")]
    //orignal method
    // public ActionResult<UserV1> UpdateUser(UserV1 user)
    // {
        // if (!ModelState.IsValid || user == null)
        // {
        //     return BadRequest();
        // }
    //     return Ok(_userRepository.UpdateUser(user));
    // }
    public IActionResult UpdateUser(int userId, UpdateRequest newUser)
    {
        if (!ModelState.IsValid || newUser == null)
        {
            return BadRequest();
        }
        _userRepository.UpdateUser(userId, newUser);
        return Ok(new { message = "User updated" });
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpDelete]
    [Route("{userId:int}")]
    public ActionResult DeleteUser(int userId)
    {
        _userRepository.DeleteUserById(userId);
        return NoContent();
    }
}



