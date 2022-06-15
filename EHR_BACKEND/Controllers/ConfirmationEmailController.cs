using EasyHouseRent.Helpers;
using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmationEmailController : ControllerBase
    {
        BaseData db = new BaseData();
        Usuarios user = new Usuarios();
        private readonly IConfiguration conf;
        public ConfirmationEmailController(IConfiguration config)
        {
            conf = config;
        }
        
        [HttpPost]
        public ActionResult<object> Post([FromQuery] Usuarios user)
        {
            string sql = $"SELECT email FROM usuarios WHERE email = '{user.email}';";
            string secret = this.conf.GetValue<string>("Secret");
            var jwt = new JWT(secret);
            var token = jwt.CreateTokenEmail(db.executeSql(sql));
            return Ok(new { state = true, message = "Token For Created Email", token });
        }

        [HttpPost("/verifyEmail")]
        public bool PostEmail ([FromQuery] string email)
        {
            string sql = $"SELECT email FROM usuarios where email = '{email}';";
            return user.ConfirmationEmail(sql);
        }
    }
}
