using EasyHouseRent.Helpers;
using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using EHR_BACKEND.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;


namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PasswordController : ControllerBase
    {
        BaseData db = new BaseData();
        Usuarios user = new Usuarios();
        private readonly IConfiguration conf;
        public PasswordController(IConfiguration config)
        {
            conf = config;
        }

        [HttpPost]
        public ActionResult<object> Post([FromQuery] Usuarios user)
        {
            string sql = $"SELECT email FROM usuarios WHERE email = '{user.email}';";
            string secret = this.conf.GetValue<string>("Secrect");
            var jwt = new JWT(secret);
            var token = jwt.CreateTokenEmail(db.executeSql(sql));
            return Ok(new { state = true, token = token});
        }

        [HttpPost("/descodeToken")]
        public JwtSecurityToken descodeToken([FromQuery] string token)
        {
            string secret = this.conf.GetValue<string>("Secrect");
            var jwt = new JWT(secret);
            var decode = jwt.descodeToken(token);
            return decode;
        }

        [HttpPost("/getpassword")]
        public bool PostGetPassword([FromBody] Usuarios user)
        {
            string sql = $"SELECT contraseña FROM usuarios WHERE contraseña = '{user.contrasenna}';";
            return user.ConfirmationPassword(sql);
        }

        [HttpPut]
        [Authorize]
        public string Put([FromBody] LoginData user)
        {
            string sql = $"update usuarios set contraseña = '{user.password}' where email = '{user.email}';";         
            return db.executeSql(sql);
        }

        [HttpPut("/confirmpassword")]
        public string PutPassword([FromBody] LoginData userData)
        {
            string sql = $"SELECT contraseña FROM usuarios WHERE contraseña = '{userData.validatePassword}' and email = '{userData.email}';";
            bool password = user.ConfirmationPassword(sql);
            if (password==true)
            {
                string sqlPassword = $"update usuarios set contraseña = '{userData.password}' where email = '{userData.email}';";
                return db.executeSql(sqlPassword);
            }
            else
            {
                return "Las contraseña no coinciden";
            }

        }
    }
}