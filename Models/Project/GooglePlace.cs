using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace rexfinder_api.Models;

public class GooglePlace
{
    //I'm honestly not sure we need this but I wrote it justincase.  Also everything is a string till we get better information from the google places API.

    [JsonIgnore]
    [Required]
    public string GooglePlaceId { get; set; }
    public string PlacePhotos { get; set; }
    public string PlaceType { get; set; }
    public string PlaceName { get; set; }
    public string PlaceAddress { get; set; }
    public string PlaceHours { get; set; }
    public string PlaceWebSite { get; set; }
    public string PlacePhoneNumber { get; set; }
    public string PlaceRatings { get; set; }
    public string PlacePriceLevel { get; set; }
}