using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnionMarket.Models;

namespace UnionMarket.Service
{
    public class GenerateJwtToken
    {
        private readonly IConfiguration _config;


        public GenerateJwtToken(IConfiguration config)
        {
            _config = config;
        }


        public static string Generate(string username,string roleName,Guid id)
        {
            var claims = new[]
            {
               
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,roleName)
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mySuperSecretKekhgkkgkkgkkhkghkgkhky12345"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                issuer: "yourIssuer",
                audience: "yourAudience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
