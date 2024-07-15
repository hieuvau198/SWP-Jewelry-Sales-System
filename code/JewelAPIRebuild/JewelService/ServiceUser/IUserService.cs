using JewelBO;

namespace JewelService.ServiceUser
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUser(string userId);
        User AddUser(User user);
        Boolean RemoveUser(string userId);
        Boolean UpdateUser(User user);
    }
}
