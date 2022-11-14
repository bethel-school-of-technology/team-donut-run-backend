using rexfinder_api.Models;
using rexfinder_api.Migrations;

namespace rexfinder_api.Repositories;

public class UserV1Service : IUserV1Service
{

    private readonly MyPlacesDbContext _context;

    public UserV1Service(MyPlacesDbContext context)
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

    public UserV1 UpdateUser(UserV1 newUser)
    {
        var originalUser = _context!.Users.Find(newUser.UserId);
        if (originalUser != null)
        {
            //Not sure if this is where we update Username and Password.
            //Testing other fields first.
            originalUser.Email = newUser.Email;
            originalUser.FirstName = newUser.FirstName;
            originalUser.LastName = newUser.LastName;
            originalUser.Location = newUser.Location;
            _context.SaveChanges();
        }
        return originalUser;
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
