
using JewelBO;
using JewelDAO.DAOAuth;

namespace JewelRepository.RepositoryAuth
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IAuthDao _authDao;
        public AuthRepository(IAuthDao authDao)
        {
            _authDao = authDao;
        }
        public string AuthenticateUser(string username, string password)
        {
            return _authDao.AuthenticateUser(username, password);
        }

        public string GenerateJwtToken(User user, string role)
        {
            return _authDao.GenerateJwtToken(user, role);
        }

        public User GetUserByUsername(string username)
        {
            return _authDao.GetUserByUsername(username);
        }

        public bool RegisterUser(User user)
        {
            return (_authDao.RegisterUser(user));
        }
    }
}
