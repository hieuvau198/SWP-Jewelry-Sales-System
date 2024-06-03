using JewelSystemBE.Data;
using JewelSystemBE.Model;
using BCrypt.Net;

namespace JewelSystemBE.Service.ServiceUser
{
    public class UserService : IUserService
    {
        private readonly JewelDbContext _jewelDbContext;

        public UserService(JewelDbContext jewelDbContext)
        {
            this._jewelDbContext = jewelDbContext;
        }

        public bool AddUser(User user)
        {
            if (user == null)
            {
                // If user object is null, return false indicating failure
                return false;
            }

            var existingUser = _jewelDbContext.Users.FirstOrDefault(u => u.Username == user.Username);
            if (existingUser != null)
            {
                // Username already exists, return false indicating failure
                return false;
            }

            try
            {
                // Add the user to the context and save changes
                _jewelDbContext.Users.Add(user);
                _jewelDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine($"Error adding user: {ex.Message}");
                return false;
            }
        }


        public List<User> GetUsers()
        {
            return _jewelDbContext.Users.OrderByDescending(x => x.Username).ToList();
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
