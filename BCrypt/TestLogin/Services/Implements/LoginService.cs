using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestLogin.Models;
using TestLogin.Payload.Request;
using TestLogin.Payload.Response;

namespace TestLogin.Services.Implements
{
    public class LoginService : ILoginService
    {
        private readonly TestDbContext _context;
        private readonly IConfiguration _configuration;
        public LoginService(TestDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        private string GenerateToken(Account account)
        {
            //Tao tung claim cua tai khoan
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                 new Claim(ClaimTypes.Name, account.Username),
                new Claim(ClaimTypes.GivenName, account.FirstName),
                new Claim(ClaimTypes.Surname, account.LastName),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, account.Role)
            };
            var jwtKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtKey), SecurityAlgorithms.HmacSha256Signature),
                Issuer = jwtIssuer,
                Audience = jwtAudience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(jwtToken);
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var account = await _context.Account
                .SingleOrDefaultAsync(account => account.Email == loginRequest.Email);
            string passwordHashed = BCrypt.Net.BCrypt.HashPassword(account.Password);   
            if (account != null && BCrypt.Net.BCrypt.Verify(loginRequest.Password, account.Password))
            {
                var loginResponse = new LoginResponse
                {
                    Username = account.Username,
                    Email = account.Email,
                    Role = account.Role,
                    Firstname = account.FirstName,
                    LastName = account.LastName,
                    Token = GenerateToken(account)
                };
                return loginResponse;
            }
            return null;
        }
    }
}
