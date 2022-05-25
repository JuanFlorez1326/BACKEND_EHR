using EasyHouseRent;
using EasyHouseRent.Model;
using EHR_BACKEND.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EHR_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        BaseData _db = new BaseData();
        private readonly IConfiguration _configuration;
        public object AdapterTable { get; private set; }




        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // POST api/<LoginController>
        [HttpPost]
        public ActionResult Post([FromBody] LoginData loginData)
        {
            var secretKey = _configuration.GetValue<string>("Secrect");
            var key = Encoding.ASCII.GetBytes(secretKey);
            var claims = new ClaimsIdentity();

            string sql = $"SELECT idusuario, nombre, apellidos, edad, email,telefono, foto FROM usuarios where email = '{loginData.email}' and contraseña = '{loginData.password}'";
            List<object> result = _db.ConvertDataTabletoString(sql);

            if (result.Count == 0)
            {

                return BadRequest(new { isAuth = false });
            }
            else
            {
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1"));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(createdToken);

                result.Add( new { token = token });

                return Ok(result);

            }

        }
    }
}
