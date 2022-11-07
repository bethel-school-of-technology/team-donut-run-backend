namespace WebApi.Entities;

using System.Text.Json.Serialization;
using rexfinder_api.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }

    [JsonIgnore]
    public List<RefreshToken> RefreshTokens { get; set; }

    public string Location { get; set; }
    public string Email { get; set; }

    public List<MyPlace> MyPlaces { get; set; }
}