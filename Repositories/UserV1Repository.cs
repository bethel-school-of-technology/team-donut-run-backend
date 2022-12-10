using rexfinder_api.Models;
using rexfinder_api.Migrations;

namespace rexfinder_api.Repositories;

public class UserV1Repository : IUserV1Repository
{

    private readonly MyPlacesDbContext _context;
    

    public UserV1Repository(MyPlacesDbContext context)
    {
        _context = context;
    }


    public IEnumerable<UserV1> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public UserV1 GetUserById(int userId)
    {
        return _context.Users.SingleOrDefault(c => c.UserId == userId);
    }

    public void UpdateUser(int userId, UpdateRequest editUser)
    {
        var originalUser = GetUserById(userId);

        // copy model to user and save

            originalUser.Username = editUser.Username;
            originalUser.Email = editUser.Email;
            originalUser.FirstName = editUser.FirstName;
            originalUser.LastName = editUser.LastName;
            originalUser.Location = editUser.Location;

        _context.Users.Update(originalUser);
        _context.SaveChanges();

    }
    public void DeleteUserById(int userId)
    {
        var user = _context.Users.Find(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
