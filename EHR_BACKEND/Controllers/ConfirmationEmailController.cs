using EasyHouseRent.Helpers;
using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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


        [HttpGet]

        public bool Get([FromQuery] string email)
        {
            string sql = $"SELECT email FROM usuarios where email = '{email}';";
            return user.ConfirmationEmail(sql);
        }
        
        // GET api/<ConfirmationEmailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConfirmationEmailController>
        [HttpPost]
        public ActionResult<object> Post([FromQuery] Usuarios user)
        {
            string sql = $"SELECT email FROM usuarios WHERE email = '{user.email}';";

            string secret = this.conf.GetValue<string>("Secret");
            var jwt = new JWT(secret);
            var token = jwt.CreateTokenEmail(db.executeSql(sql));
            return Ok(new { state = true, message = "Token For Created Email", token });
        }

        // PUT api/<ConfirmationEmailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConfirmationEmailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
