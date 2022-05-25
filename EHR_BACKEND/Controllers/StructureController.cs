using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EHR_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StructureController : ControllerBase
    {
        BaseData db = new BaseData();
        // GET: api/<AdFiltersController>
        [HttpGet]
        public IEnumerable<Estructura> GetStructure([FromQuery] Estructura struc)
        {
            string sql = "SELECT * FROM estructura ";
            DataTable dt = db.getTable(sql);
            List<Estructura> listStructure = new List<Estructura>();
            listStructure = (from DataRow dr in dt.Rows
                         select new Estructura()
                         {
                             idestructura = Convert.ToInt32(dr["idestructura"]),
                             nombre = dr["nombre"].ToString(),
                         }).ToList();

            return listStructure;
        }

        // GET api/<AdFiltersController>/5
        [HttpGet("AboutUs")]
        public IEnumerable<Anuncios> GetImagesAds([FromQuery] string value)
        {
            string sql = $"SELECT url1 FROM anuncios LIMIT 5;";
            DataTable dt = db.getTable(sql);
            List<Anuncios> listImagesAds = new List<Anuncios>();
            listImagesAds = (from DataRow dr in dt.Rows
                             select new Anuncios()
                             {
                                 url1 = dr["url1"].ToString(),

                             }).ToList();

            return listImagesAds;
        }

        // POST api/<AdFiltersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdFiltersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdFiltersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
