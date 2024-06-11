using JewelSystemBE.Model;

namespace JewelSystemBE.Service.ServiceAuth
{
    public interface IAuthService
    {
        string AuthenticateUser(string username, string password);
        Boolean RegisterUser(User user);

        //for token
        User GetUserByUsername(string username);
        string GenerateJwtToken(User user, string role);
    }
}
