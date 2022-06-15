using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace EHR_BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StructureController : ControllerBase
    {
        BaseData db = new BaseData();

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

        [HttpGet("AboutUs")]
        public IEnumerable<Anuncios> GetImagesAds([FromQuery] string value)
        {
            string sql = $"SELECT url1 FROM anuncios LIMIT 8;";
            DataTable dt = db.getTable(sql);
            List<Anuncios> listImagesAds = new List<Anuncios>();
            listImagesAds = (from DataRow dr in dt.Rows
                             select new Anuncios()
                             {
                                 url1 = dr["url1"].ToString(),

                             }).ToList();

            return listImagesAds;
        }
    }
}