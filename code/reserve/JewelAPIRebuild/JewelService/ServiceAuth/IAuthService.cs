using JewelBO;

namespace JewelService.ServiceAuth
{
    public interface IAuthService
    {
        Boolean AuthenticateUser(string username, string password);
        Boolean RegisterUser(User user);

        //for token
        User GetUserByUsername(string username);
        string GenerateJwtToken(string username);
    }
}
