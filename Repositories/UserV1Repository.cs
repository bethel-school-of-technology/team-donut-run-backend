using rexfinder_api.Models;
using rexfinder_api.Migrations;
using bcrypt = BCrypt.Net.BCrypt;

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
    //Original UpdateUser method
    // public UserV1 UpdateUser(UserV1 newUser)
    // {
    //     var originalUser = _context!.Users.Find(newUser.UserId);

    //     if (originalUser != null)
    //     {
    //         // //Hash password if password is entered.
    //         if (!string.IsNullOrEmpty(newUser.Password))
    //         originalUser.Password = bcrypt.HashPassword(newUser.Password);
            
            // originalUser.UserId = newUser.UserId;
            // originalUser.Username = newUser.Username;
            // originalUser.Email = newUser.Email;
            // originalUser.FirstName = newUser.FirstName;
            // originalUser.LastName = newUser.LastName;
            // originalUser.Location = newUser.Location;
            // originalUser.MyPlaces = newUser.MyPlaces;
    //         _context.SaveChanges();
    //     }
    //     return originalUser;
    // }

    public void UpdateUser(int userId, UpdateRequest editUser)
    {
        var originalUser = GetUserById(userId);
       
        // validate (Not using in Version 1)
        // if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
        //     throw new AppException("User with the email '" + model.Email + "' already exists");

        // hash password if it was entered
        if (!string.IsNullOrEmpty(editUser.Password))
            // Where is the rest of the if statement {} code? 

            originalUser.Password = bcrypt.HashPassword(editUser.Password);
            // I don't think we can do this because it sets the new password to be the actual hashed password (instead of what the user entered)

        // copy model to user and save

        //AutoMapper not used in version 1
        // _mapper.Map(model, user);

            originalUser.Username = editUser.Username;
            originalUser.Email = editUser.Email;
            originalUser.FirstName = editUser.FirstName;
            originalUser.LastName = editUser.LastName;
            originalUser.Location = editUser.Location;

        _context.Users.Update(originalUser); // What does this do?
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
