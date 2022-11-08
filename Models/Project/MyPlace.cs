using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace rexfinder_api.Models;

public class MyPlace
{
    [JsonIgnore]
    public int MyPlaceId { get; set; }
    public bool Visited { get; set; }

    public int UserId { get; set; }

    [Required]
    public string CreatedOn { get; set; }

    [Required]
    public string GooglePlaceId { get; set; }
}