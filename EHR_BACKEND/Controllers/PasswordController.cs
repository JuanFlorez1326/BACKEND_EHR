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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PasswordController : ControllerBase
    {
        BaseData db = new BaseData();
        private readonly IConfiguration conf;
        public PasswordController(IConfiguration config)
        {
            conf = config;
        }

        // GET: api/<PasswordController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PasswordController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PasswordController>
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

        // PUT api/<PasswordController>/5
        [HttpPut]
        [Authorize]
        public string Put([FromBody] LoginData user)
        {
            string sql = $"update usuarios set contraseña = '{user.password}' where email = '{user.email}';";
            
            return db.executeSql(sql);
        }

        // DELETE api/<PasswordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
