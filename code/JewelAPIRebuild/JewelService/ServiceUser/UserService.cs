
using JewelBO;
using JewelRepository.RepositoryUser;

namespace JewelService.ServiceUser
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }


        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public User GetUser(string userId)
        {
            return _userRepository.GetUser(userId);
        }

        public bool RemoveUser(string userId)
        {
            return (_userRepository.RemoveUser(userId));
        }

        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
    }
}
