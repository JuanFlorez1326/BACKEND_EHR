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