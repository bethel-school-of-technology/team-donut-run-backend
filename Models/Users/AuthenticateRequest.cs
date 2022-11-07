namespace WebApi.Models.Users;

using System.ComponentModel.DataAnnotations;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}

// This defines the model for the INCOMING authentication request