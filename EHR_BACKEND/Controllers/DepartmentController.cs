using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        BaseData db = new BaseData();
        Departamento departamento = new Departamento();

        [HttpGet]
        public List<object> Get()
        {
            string sql = "SELECT * FROM departamento WHERE nombre != 'desconocido'";
            return db.ConvertDataTabletoString(sql);
        }
    }
}
