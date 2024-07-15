using JewelBO;
using JewelRepository.RepositoryAuth;

namespace JewelService.ServiceAuth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        public string AuthenticateUser(string username, string password)
        {
            return _authRepository.AuthenticateUser(username, password);
        }

        public bool RegisterUser(User user)
        {
            return (_authRepository.RegisterUser(user));
        }

        public User GetUserByUsername(string username)
        {
            return _authRepository.GetUserByUsername(username);
        }
        public string GenerateJwtToken(User user, string role)
        {
            return _authRepository.GenerateJwtToken(user, role);
        }
    }
}
