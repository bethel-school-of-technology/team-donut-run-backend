using rexfinder_api.Models;

namespace rexfinder_api.Repositories;

public interface IUserV1Service {

    IEnumerable<UserV1> GetAllUsers();
    UserV1 GetUserById(int userId);
    UserV1 UpdateUser(UserV1 newUser);
    void DeleteUserById(int userId);
}
