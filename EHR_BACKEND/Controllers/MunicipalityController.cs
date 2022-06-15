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
    public class MunicipalityController : ControllerBase
    {
        BaseData db = new BaseData();
        Municipios municipios = new Municipios(); 

        [HttpGet]
        public List<object> Get()
        {
            string sql = "SELECT * FROM municipios WHERE nombre != 'desconocido'";
            return db.ConvertDataTabletoString(sql);
        }

        [HttpGet("{iddepartamento}")]
        public List<object> Get([FromQuery]int iddepartamento)
        {
            string sql = $"select m.* FROM municipios m INNER JOIN departamento d on m.departamento=d.iddepartamento where d.iddepartamento = {iddepartamento}";
            return db.ConvertDataTabletoString(sql);
        }
    }
}