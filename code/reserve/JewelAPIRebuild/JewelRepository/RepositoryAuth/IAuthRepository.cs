

using JewelBO;

namespace JewelRepository.RepositoryAuth
{
    public interface IAuthRepository
    {
        Boolean AuthenticateUser(string username, string password);
        Boolean RegisterUser(User user);

        //for token
        User GetUserByUsername(string username);
        string GenerateJwtToken(string username);
    }
}
