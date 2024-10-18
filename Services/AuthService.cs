using Microsoft.IdentityModel.Tokens;
using NotificacaoColetaApi.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NotificacaoColetaApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public AuthService(JwtSecurityTokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }

        public string GenerateJWTToken()
        {
            var key = Encoding.UTF8.GetBytes("15c6b2f21c4b157880b49dd375cfea9e15c6b2f21c4b157880b49dd375cfea9e");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Coleta-Api"),
                new Claim(ClaimTypes.Role, "application"),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddDays(1)
            };

            var token = _tokenHandler.CreateToken(tokenDescriptor);

            return _tokenHandler.WriteToken(token);
        }
    }
}