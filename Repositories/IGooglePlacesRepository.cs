using rexfinder_api.Models;

namespace rexfinder_api.Repositories;

public interface IGooglePlacesRepository
{
    // private readonly IHttpClientFactory _clientFactory;

    // public IHttpClientFactory(IHttpClientFactory clientFactory) {
    //     _clientFactory = clientFactory;
    // }

    // protected override async Task OnInitializedAsync()
    // {
    //     var request = new HttpRequestMessage(HttpMethod.Get,"https://geocode.maps.co/search?postalcode=37064&country=US");

    //     var client = _clientFactory.CreateClient();

    //     HttpResponseMessage response = await client.SendAsync(request);
    // }


}

/*Need to deserialize the JSON response?

public class GitHubRelease
{
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }
    [JsonProperty(PropertyName = "published_at")]
    public string PublishedAt { get; set; }
}





*/
