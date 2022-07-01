using EasyHouseRent.Helpers;
using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using EHR_BACKEND.Models;
using EHR_BACKEND.Models.Entities;
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

        [HttpPut("confirmpassword")]
        public string PutPassword([FromBody] DataPassworUpdate userdata)
        {
            string sql = $"SELECT contraseña FROM usuarios WHERE contraseña = '{userdata.validatePassword}' and email = '{userdata.email}';";
            bool passwordresult = user.ConfirmationPassword(sql);
            if (passwordresult==true)
            {
                string sqlPassword = $"update usuarios set contraseña = '{userdata.password}' where email = '{userdata.email}';";
                return db.executeSql(sqlPassword);
            }
            else
            {
                return "Las contraseña no coinciden";
            }

        }
    }
}