using rexfinder_api.Models;

namespace rexfinder_api.Repositories;

public interface IAuthService
{
    UserV1 CreateUser(UserV1 user);

    string SignIn(SignInRequestV1 request);
}