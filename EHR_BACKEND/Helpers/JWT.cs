using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasyHouseRent.Helpers
{
    public class JWT
    {
        private readonly byte[] secret;
        public JWT(string key)
        {
            this.secret = Encoding.ASCII.GetBytes(@key);
        }

        public string CreateTokenEmail(string @email)
        {
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, email));

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(this.secret), SecurityAlgorithms.HmacSha256Signature)
            };

            var returnToken = new JwtSecurityTokenHandler();
            var createdToken = returnToken.CreateToken(tokenDescription);

            return returnToken.WriteToken(createdToken);
        }

        public JwtSecurityToken descodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var decodeValue = handler.ReadJwtToken(token);
            return decodeValue;
        }

    }
}
