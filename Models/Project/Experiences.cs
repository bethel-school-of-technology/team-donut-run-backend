using System.ComponentModel.DataAnnotations;

namespace rexfinder_api.Models;

public class Experiences
{
    [Required]
    public int ExperienceId { get; set; }

    [Required]
    public int UserId { get; set; }
    public UserV1 User { get; set; }

    [Required]
    public string ExperienceTitle { get; set; }
    public string ExperienceNotes { get; set; }
    public bool Completed { get; set; }
    public string ExperienceUserLocation { get; set; }

    //this is coming from the front end from the google places api
    [Required]
    public string FirstGooglePlaceId { get; set; }
    public string SecondGooglePlaceId { get; set; }
    public string ThirdGooglePlaceId { get; set; }
}