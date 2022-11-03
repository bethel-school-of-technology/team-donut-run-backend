using System.ComponentModel.DataAnnotations;

namespace rexfinder_api.Models;

public class MyPlaces
{

    //these items are set by our app
    public int MyPlaceId { get; set; }
    public bool Visited { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public string CreatedOn { get; set; } = DateTime.Now.ToString();

    //below items are a local copy of the data from the google places API, a local cache if you will.  We should pull the most current data from google places API but having a local cache helps for speed and if google places API doesn't respond
    [Required]
    public string GooglePlacesId { get; set; }

    public string PlaceImage { get; set; }
    public string PlaceName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string StarRating { get; set; }
}