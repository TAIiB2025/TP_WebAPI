using BLL;
using BLL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL_Memory
{
    public class AutoryzacjaService : IAutoryzacjaService
    {
        private readonly IConfiguration _configuration;

        public AutoryzacjaService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoggedUserDTO Login(LoginDTO loginDTO)
        {
            if(loginDTO.Login.Trim().ToLower() != "admin" || loginDTO.Password != "Password")
            {
                throw new ApplicationException("Podano niepoprawną nazwę użytkownika lub hasło");
            }

            var jwtSettings = _configuration.GetSection("JWT");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(),
                Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiresInMinutes"])),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return new LoggedUserDTO(tokenString);
        }
    }
}
