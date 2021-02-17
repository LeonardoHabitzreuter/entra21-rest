using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Common;
using Domain.Users;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(User user)
        {
            var privateKey = Environment.GetEnvironmentVariable("private_key", EnvironmentVariableTarget.Process);
            if (string.IsNullOrEmpty(privateKey))
            {
                privateKey = Environment.GetEnvironmentVariable("private_key", EnvironmentVariableTarget.Process);
            }
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(privateKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Profile.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}