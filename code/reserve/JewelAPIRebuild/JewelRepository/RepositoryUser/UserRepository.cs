

using JewelBO;
using JewelDAO.DAOUser;

namespace JewelRepository.RepositoryUser
{
    public class UserRepository : IUserRepository
    {
        private IUserDao _userDao;
        public UserRepository(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public bool AddUser(User user)
        {
            return _userDao.AddUser(user);
        }

        public User GetUser(string userId)
        {
            return _userDao.GetUser(userId);
        }

        public List<User> GetUsers()
        {
            return _userDao.GetUsers();
        }

        public bool RemoveUser(string userId)
        {
            return (_userDao.RemoveUser(userId));
        }

        public bool UpdateUser(User user)
        {
            return _userDao.UpdateUser(user);
        }
    }
}
