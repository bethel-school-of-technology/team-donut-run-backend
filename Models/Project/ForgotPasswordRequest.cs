using System.ComponentModel.DataAnnotations;

namespace rexfinder_api.Models;

public class ForgotPasswordRequest{
    [Required]
    [EmailAddress]

    public string Email {get ; set;}
}
