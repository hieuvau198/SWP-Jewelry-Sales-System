
using JewelBO;

namespace JewelRepository.RepositoryAuth
{
    public interface IAuthRepository
    {
        string AuthenticateUser(string username, string password);
        Boolean RegisterUser(User user);

        //for token
        User GetUserByUsername(string username);
        string GenerateJwtToken(User user, string role);
    }
}
