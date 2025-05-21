using APIProjectBackend.Entities;
using APIProjectBackend.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIProjectBackend.Service
{
    public class AuthService: IAuthService
    {
        private readonly DbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(DbContext context, IConfiguration configuration) 
        {
            _context = context;
            _configuration = configuration;
        }

        public User? Login(string correo, string password)
        {
            return _context.Set<User>().FirstOrDefault(u => u.Correo == correo && u.Password == password);
        }

        public string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Correo),
                new Claim("nombre", user.Nombre)
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(jwtSettings["ExpiresInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}