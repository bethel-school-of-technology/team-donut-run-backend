using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace rexfinder_api.Models;

public class MyPlace
{
    //these items are set by our app
    // [JsonIgnore]
    [Required]
    public int MyPlaceId { get; set; }
    public bool Visited { get; set; }

    [Required]
    public int UserId { get; set; }

    public UserV1? User { get; set; }

    [Required]
    public string CreatedOn { get; set; }

    //this is coming from the front end from the google places api
    [Required]
    public string GooglePlaceId { get; set; }
}