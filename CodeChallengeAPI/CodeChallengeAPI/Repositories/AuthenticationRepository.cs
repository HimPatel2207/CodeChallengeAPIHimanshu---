using CodeChallenge.Repository.CompanyDatabase;
using CodeChallengeAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CodeChallengeAPI.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly CodeChallengeGlasslewisContext _context;
        private IConfiguration _config;

        public AuthenticationRepository(CodeChallengeGlasslewisContext DBContext, IConfiguration config)
        {
            _context = DBContext;
            _config = config;
        }

        public UserDetails AuthenticateUser(string userName, string password)
        {
            UserDetails userLoginDetails = new UserDetails();

            var user = _context.User.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

            if (user != null)
            {
                userLoginDetails.UserName = user.UserName;
                userLoginDetails.Usertype = "Admin";
                userLoginDetails.AccessToken = GenerateToken(userName, "Admin");
            }

            return userLoginDetails;
        }

        private string GenerateToken(string userName, string type)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Typ, type),
            };
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}