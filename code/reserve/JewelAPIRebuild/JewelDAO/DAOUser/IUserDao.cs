using JewelBO;

namespace JewelDAO.DAOUser
{
    public interface IUserDao
    {
        List<User> GetUsers();
        User GetUser(string userId);
        Boolean AddUser(User user);
        Boolean RemoveUser(string userId);
        Boolean UpdateUser(User user);
    }
}
