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

        [HttpPost]
        public ActionResult Post([FromBody] LoginData loginData)
        {
            var secretKey = _configuration.GetValue<string>("Secrect");
            var key = Encoding.ASCII.GetBytes(secretKey);
            var claims = new ClaimsIdentity();
            string sql = $"SELECT u.idusuario, u.nombre, u.apellidos, u.edad, u.email, u.telefono, u.foto, d.nombre as nombreDepartamento, m.nombre as nombreMunicipio FROM usuarios u inner join departamento d on u.departamento = d.iddepartamento inner join municipios m on u.municipio = m.idmunicipio where email = '{loginData.email}' and contraseña = '{loginData.password}'";
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