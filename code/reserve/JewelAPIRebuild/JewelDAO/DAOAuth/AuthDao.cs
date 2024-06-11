using JewelBO;
using JewelDAL;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JewelDAO.DAOAuth
{
    public class AuthDao : IAuthDao
    {
        private readonly JewelDbContext _jewelDbContext;
        private readonly IConfiguration _configuration;

        public AuthDao(JewelDbContext jewelDbContext, IConfiguration configuration)
        {
            this._jewelDbContext = jewelDbContext;
            _configuration = configuration;
        }

        public bool AuthenticateUser(string username, string password)
        {
            var user = _jewelDbContext.Users.SingleOrDefault(
                u => u.Username == username);
            if (user == null)
            {
                return false;
            }
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
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
        string IAuthDao.GenerateJwtToken(string username)
        {
            var user = GetUserByUsername(username);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
