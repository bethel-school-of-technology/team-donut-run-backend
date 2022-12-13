
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace rexfinder_api.Models;

public class UserV1
{
    // [JsonIgnore] // may need to take this out if it gives any trouble?
    public int UserId { get; set; }

    [Required]
    public string? Username { get; set; }

    // Maybe we make email the primary way to sign in, just in case we want to add some additional functionality later to send emails to users?
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    // What does this save? User input or default based on geolocation from the frontend?
    public string? Location { get; set; }

    //Adding properties needed to reset password if forgotten
    public string ResetToken { get; set; }
    public DateTime? ResetTokenExpires { get; set; }

    // ADD IN V2??
    // public string? PhotoUrl { get; set; }

    [JsonIgnore]
    public List<MyPlace>? MyPlaces { get; set; }

    [JsonIgnore]
    public List<Experiences> Experiences { get; set; }


}