using rexfinder_api.Migrations;
using rexfinder_api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using bcrypt = BCrypt.Net.BCrypt;

namespace rexfinder_api.Repositories;

public class AuthService : IAuthService
{
    private static MyPlacesDbContext _context;

    private static IConfiguration _config;

    public AuthService(MyPlacesDbContext context, IConfiguration config) 
    {
        _context = context;
        _config = config;
    }

    // CREATE NEW USER (used with Post request)
    public UserV1 CreateUser(UserV1 user)
    {
        var passwordHash = bcrypt.HashPassword(user.Password);
        user.Password = passwordHash;

        _context.Add(user);
        _context.SaveChanges();
        return user;
        
    }

    // SIGN IN EXISTING USER (use with Post request)
    public string SignIn(SignInRequestV1 request)
    {
        var user = _context.Users.SingleOrDefault(u => u.Username == request.Username);

        var verified = false;

        if (user != null)
        {
            verified = bcrypt.Verify(request.Password, user.Password);
        }

        if (user == null || !verified)
        {
            return String.Empty;
        }

        return BuildToken(user);

    }

    private string BuildToken(UserV1 user)
    {
        var secret = _config.GetValue<String>("TokenSecret");
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var claims = new Claim[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
        new Claim("UserId", user.UserId.ToString()),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.Username ?? ""),
        new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName ?? ""),
        new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName ?? "")
        };

        // Create token
        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signingCredentials);

        // Encode token
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }

}

