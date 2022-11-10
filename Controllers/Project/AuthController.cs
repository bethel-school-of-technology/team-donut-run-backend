using rexfinder_api.Repositories;
using rexfinder_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace rexfinder_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;

    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService service)
    {
        _logger = logger;
        _authService = service;
    }

    // POST / create a new user
    [HttpPost]
    [Route("signup")]
    public ActionResult CreateNewUser(UserV1 user)
    {
        if (user == null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        _authService.CreateUser(user);
        return NoContent();
    }

    // POST / using response to sign in
    [HttpPost]
    [Route("signin")]
    public ActionResult<string> SignIn(SignInRequestV1 request)
    {
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password) || request == null || !ModelState.IsValid)
        {
            return BadRequest();
        }

        var token = _authService.SignIn(request);

        if (string.IsNullOrWhiteSpace(token) || token == null)
        {
            return Unauthorized();
        }

        return Ok(token);
    }
}