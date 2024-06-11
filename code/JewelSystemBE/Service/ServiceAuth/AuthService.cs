using JewelSystemBE.Model;
using JewelSystemBE.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JewelSystemBE.Service.ServiceAuth
{
    public class AuthService : IAuthService
    {
        private readonly JewelDbContext _jewelDbContext;
        private readonly IConfiguration _configuration;

        public AuthService(JewelDbContext jewelDbContext, IConfiguration configuration)
        {
            this._jewelDbContext = jewelDbContext;
            _configuration = configuration;
        }

        public string AuthenticateUser(string username, string password)
        {
            var user = _jewelDbContext.Users.SingleOrDefault(
                u => u.Username == username);
            if (user == null)
            {
                return "Wrong Username";
            }
            if(BCrypt.Net.BCrypt.Verify(password, user.Password))
            { return user.Role; }
            return "Wrong Password.";
        }

        public bool RegisterUser(User user)
        {
            bool userExists = _jewelDbContext.Users.Any(
                u => u.Username == user.Username || 
                u.Email == user.Email);
            if (userExists)
            {
                return false;
            }

            user.UserId = Guid.NewGuid().ToString();
            _jewelDbContext.Users.Add(user);
            _jewelDbContext.SaveChanges();

            return true;
        }

        // auth with token
        

        public User GetUserByUsername(string username)
        {
            return _jewelDbContext.Users.SingleOrDefault(u => u.Username == username);
        }
        public string GenerateJwtToken(User user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim("fullName", user.Fullname),
            new Claim("email", user.Email),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
