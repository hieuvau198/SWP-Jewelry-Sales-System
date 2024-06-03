using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceUser
{
    public interface IUserService
    {
        List<User> GetUsers();

        Boolean AddUser(User user);
        Boolean RemoveUser(string userId);
        Boolean UpdateUser(User user);
    }
}
