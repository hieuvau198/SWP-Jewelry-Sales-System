

using JewelBO;

namespace JewelRepository.RepositoryUser
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(string userId);
        User AddUser(User user);
        Boolean RemoveUser(string userId);
        Boolean UpdateUser(User user);
    }
}
