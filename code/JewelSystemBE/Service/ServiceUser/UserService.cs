using JewelSystemBE.Data;
using JewelSystemBE.Model;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;

namespace JewelSystemBE.Service.ServiceUser
{
    public class UserService : IUserService
    {
        private readonly JewelDbContext _jewelDbContext;

        public UserService(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public User AddUser(User user)
        {
            if (user == null)
            {
                // If user object is null, return false indicating failure
                return null;
            }

            var existingUser = _jewelDbContext.Users.FirstOrDefault(u => u.Username == user.Username);
            if (existingUser != null)
            {
                // Username already exists, return false indicating failure
                return null;
            }

            try
            {
                // Add the user to the context and save changes
                _jewelDbContext.Users.Add(user);
                _jewelDbContext.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error adding user: {ex.Message}");
                return null;
            }
        }


        public List<User> GetUsers()
        {
           List<User> results = _jewelDbContext.Users.OrderByDescending(x => x.Username).ToList();
           if(!results.IsNullOrEmpty())
            {
                foreach(var user in results)
                {
                    user.Password = null;
                }
            }
            return results;
        }

        public User GetUser(string userId)
        {
            User result = _jewelDbContext.Users.Find(userId);
            if(result != null)
            { result.Password = null; }    
            return result;
        }

        public bool RemoveUser(string userId)
        {
            if(userId == null)
            { return false; }
            User user = _jewelDbContext.Users.Find(userId);
            if (user != null)
            {
                // Remove the user from the context and save changes
                _jewelDbContext.Users.Remove(user);
                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateUser(User user)
        {
            var foundUser = _jewelDbContext.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (foundUser != null)
            {
                // Update properties of the foundUser entity with values from the user parameter
                foundUser.Username = user.Username;
                foundUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                foundUser.Fullname = user.Fullname;
                foundUser.Email = user.Email;
                foundUser.Role = user.Role;

                _jewelDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
