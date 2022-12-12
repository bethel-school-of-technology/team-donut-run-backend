using System.ComponentModel.DataAnnotations;

namespace rexfinder_api.Models;

public class ValidateResetTokenRequest
{
    [Required]
    public string Token { get; set; }
}