
using JewelBO;
using JewelDAL;
using JewelRepository.RepositoryAuth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JewelService.ServiceAuth
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        public bool AuthenticateUser(string username, string password)
        {
            return _authRepository.AuthenticateUser(username, password);
        }

        public bool RegisterUser(User user)
        {
            return (_authRepository.RegisterUser(user));
        }

        // auth with token
        

        public User GetUserByUsername(string username)
        {
            return _authRepository.GetUserByUsername(username);
        }
        public string GenerateJwtToken(string username)
        {
            return _authRepository.GenerateJwtToken(username);
        }
    }
}
