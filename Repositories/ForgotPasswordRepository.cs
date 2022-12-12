using rexfinder_api.Models;
using rexfinder_api.Migrations;
using rexfinder_api.Helpers;
using System.Security.Cryptography;
using bcrypt = BCrypt.Net.BCrypt;

namespace rexfinder_api.Repositories;

public class ForgotPasswordRepository : IForgotPasswordRepository
{

    private readonly MyPlacesDbContext _context;
    private readonly IEmailRepository _emailRepository;


    public ForgotPasswordRepository(MyPlacesDbContext context, IEmailRepository emailRepository)
    {
        _context = context;
        _emailRepository = emailRepository;
    }

    //Modified version of "Forgot Password" Feature from:
    //https://jasonwatmore.com/post/2022/02/26/net-6-boilerplate-api-tutorial-with-
    //email-sign-up-verification-authentication-forgot-password#validate-reset-token-request-cs

    public void ForgotPassword(ForgotPasswordRequest model, string origin)
    {
        var user = _context.Users.SingleOrDefault(x => x.Email == model.Email);

        // always return ok response to prevent email enumeration
        if (user == null) return;

        // create reset token that expires after 1 day
        user.ResetToken = generateResetToken();
        user.ResetTokenExpires = DateTime.UtcNow.AddDays(1);

        _context.Users.Update(user);
        _context.SaveChanges();

        // send email
        sendPasswordResetEmail(user, origin);
    }

    private string generateResetToken()
    {
        // token is a cryptographically strong random sequence of values
        var token = Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

        // ensure token is unique by checking against db
        var tokenIsUnique = !_context.Users.Any(x => x.ResetToken == token);
        if (!tokenIsUnique)
            return generateResetToken();

        return token;
    }

    private void sendPasswordResetEmail(UserV1 user, string origin)
    {
        string message;
        if (!string.IsNullOrEmpty(origin))

        {
            origin = "http://localhost:8100";
            var resetUrl = $"{origin}/reset-password?token={user.ResetToken}";
            message = $@"<p>Please click the below link to reset your password, the link will be valid for 1 day:</p>
                            <p><a href=""{resetUrl}"">{resetUrl}</a></p>";
        }
        else
        {
            message = $@"<p>Please use the below token to reset your password with the <code>/accounts/reset-password</code> api route:</p>
                            <p><code>{user.ResetToken}</code></p>";
        }

        _emailRepository.Send(
            to: user.Email,
            subject: "Sign-up Verification API - Reset Password",
            html: $@"<h4>Reset Password Email</h4>
                        {message}"
        );
    }

    public void ValidateResetToken(ValidateResetTokenRequest model)
    {
        getAccountByResetToken(model.Token);
    }
    public void ResetPassword(ResetPasswordRequest model)
    {
        var user = getAccountByResetToken(model.Token);

        // update password and remove reset token
        user.Password = bcrypt.HashPassword(model.Password);
        user.ResetToken = null;
        user.ResetTokenExpires = null;


        _context.Users.Update(user);
        _context.SaveChanges();
    }

    private UserV1 getAccountByResetToken(string token)
    {
        //verify that provided token matches database and that 
        //expired time is later than current time.
        var user = _context.Users.SingleOrDefault(x =>
            x.ResetToken == token && x.ResetTokenExpires > DateTime.UtcNow);
        if (user == null) throw new AppException("Invalid token");
        return user;
    }
}