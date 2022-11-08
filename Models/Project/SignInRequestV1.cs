using System.ComponentModel.DataAnnotations;

namespace rexfinder_api.Models;

// Used in POST requests (via JSON body) to send a sign in request for the user

public class SignInRequestV1
{
    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Password { get; set; }
}