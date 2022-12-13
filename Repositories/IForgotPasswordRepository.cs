using rexfinder_api.Models;

namespace rexfinder_api.Repositories;

public interface IForgotPasswordRepository
{
    void ForgotPassword(ForgotPasswordRequest model, string origin);
    void ValidateResetToken(ValidateResetTokenRequest model);
    void ResetPassword(ResetPasswordRequest model);

}