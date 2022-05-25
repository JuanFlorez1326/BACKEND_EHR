using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        BaseData db = new BaseData();
        Departamento departamento = new Departamento();

        // GET: api/<DepartmentController>
        [HttpGet]
        public List<object> Get()
        {
            string sql = "SELECT * FROM departamento WHERE nombre != 'desconocido'";
            return db.ConvertDataTabletoString(sql);
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
