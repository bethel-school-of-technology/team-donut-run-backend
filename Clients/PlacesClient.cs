
namespace rexfinder_api.Clients;

// private static HttpClient placesClient = new()
// {
//     BaseAddress = new Uri("https://geocode.maps.co/search?"),
// };

// public class PlacesClient : IGooglePlacesClient
// {
//     public async Task<LatLongResponse?> GetLatLong(string zip)
//     {
//         using var httpClient = new HttpClient
//         {
//             BaseAddress = new Uri("https://geocode.maps.co/search?")
//         };

//         return await httpClient.GetFromJsonAsync<LatLongResponse>($"postalcode={zip}&country=US");
//     }
// }

// public interface IGooglePlacesClient
// {
//     Task<LatLongResponse?> GetLatLong(string zip);
// }