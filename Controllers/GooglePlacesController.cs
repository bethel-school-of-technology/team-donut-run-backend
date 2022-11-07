using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace rexfinder_api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GooglePlacesController : ControllerBase
{
    // private readonly IGooglePlacesClient _googlePlacesClient;

    // public GooglePlacesController(IGooglePlacesClient googlePlacesClient)
    // {
    //     _googlePlacesClient = googlePlacesClient;
    // }

    // [HttpGet("postalcode={zip}&country=US")]
    // public async Task<IActionResult> LatLong(string zip)
    // {
    //     var latLong = await _googlePlacesClient.GetLatLong
    // }

    // public async Task<IActionResult> Index() 
    // {
    //     var lat = "";
    //     var lng = "";
    //     var doSomething = "";

    //     using (var httpClient = new HttpClient())
    //     {
    //         using (var response = await httpClient.GetAsync("https://geocode.maps.co/search?postalcode=37064&country=US")) {
    //             string apiResponse = await response.Content.ReadAsStringAsync();

    //             doSomething = 

    //         }
    //     }
    // }

    private static HttpClient geocodeClient = new()
    {
        BaseAddress = new Uri("https://geocode.maps.co/search?"),
    };

    [HttpGet]
    static async Task GetAsync(HttpClient httpClient)
    {
        using HttpResponseMessage response = await httpClient.GetAsync("postalcode=37064&country=US");

        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(jsonResponse);

        // return jsonResponse;

        // var json = await httpClient.GetStringAsync("https://geocode.maps.co/search?postalcode=37064&country=US");

        // return json;
    }

    // [HttpGet]
    // static async Task<string> GetAsync(HttpClient httpClient)
    // {
    //     // using HttpResponseMessage response = await httpClient.GetAsync("postalcode=37064&country=US");

    //     // response.EnsureSuccessStatusCode();

    //     // var jsonResponse = await response.Content.ReadAsStringAsync();
        
    //     // return jsonResponse;

    //     var json = await httpClient.GetStringAsync("https://geocode.maps.co/search?postalcode=37064&country=US");

    //     return json;
    // }
}


// RESOURCE DOCS: https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient