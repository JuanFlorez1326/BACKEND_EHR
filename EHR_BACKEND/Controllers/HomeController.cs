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
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        BaseData db = new BaseData();
        [HttpGet]
        public IEnumerable<Anuncios> GetAd([FromQuery] string value)
        {
            if(value == null)
            {
                return null;
            }
            else
            {
                string sql = $"SELECT idanuncio,idusuario,titulo,direccion,descripcion,modalidad,zona,edificacion,habitaciones,garaje,precio,fecha,url1,url2,url3,url4,estado FROM anuncios a WHERE zona LIKE '%{value}%' OR titulo LIKE '%{value}%' OR direccion LIKE '%{value}%';";
                DataTable dt = db.getTable(sql);
                List<Anuncios> dataAd = new List<Anuncios>();
                dataAd = (from DataRow dr in dt.Rows
                          select new Anuncios()
                          {
                              idanuncio = Convert.ToInt32(dr["idanuncio"]),
                              idusuario = Convert.ToInt32(dr["idusuario"]),
                              titulo = dr["titulo"].ToString(),
                              direccion = dr["direccion"].ToString(),
                              descripcion = dr["descripcion"].ToString(),
                              modalidad = dr["modalidad"].ToString(),
                              zona = dr["zona"].ToString(),
                              edificacion = dr["edificacion"].ToString(),
                              habitaciones = Convert.ToInt32(dr["habitaciones"]),
                              garaje = dr["garaje"].ToString(),
                              precio = Convert.ToInt64(dr["precio"]),
                              fecha = dr["fecha"].ToString(),
                              url1 = dr["url1"].ToString(),
                              url2 = dr["url2"].ToString(),
                              url3 = dr["url3"].ToString(),
                              url4 = dr["url4"].ToString(),
                              estado = dr["estado"].ToString()

                          }).ToList();

                return dataAd;
            }
        }

        //GET api/<HomeController>/5
        [HttpGet("MostRecent")]
        public IEnumerable<Anuncios> GetMostRecent([FromQuery] string value)
        {
            string sql = $"SELECT idanuncio,idusuario,titulo,direccion,descripcion,modalidad,zona,edificacion,habitaciones,garaje,precio,fecha,url1,url2,url3,url4,estado FROM anuncios ORDER BY idanuncio DESC LIMIT 20;";
            DataTable dt = db.getTable(sql);
            List<Anuncios> mostRecentList = new List<Anuncios>();
            mostRecentList = (from DataRow dr in dt.Rows
                      select new Anuncios()
                      {
                          idanuncio = Convert.ToInt32(dr["idanuncio"]),
                          idusuario = Convert.ToInt32(dr["idusuario"]),
                          titulo = dr["titulo"].ToString(),
                          direccion = dr["direccion"].ToString(),
                          descripcion = dr["descripcion"].ToString(),
                          modalidad = dr["modalidad"].ToString(),
                          zona = dr["zona"].ToString(),
                          edificacion = dr["edificacion"].ToString(),
                          habitaciones = Convert.ToInt32(dr["habitaciones"]),
                          garaje = dr["garaje"].ToString(),
                          precio = Convert.ToInt64(dr["precio"]),
                          fecha = dr["fecha"].ToString(),
                          url1 = dr["url1"].ToString(),
                          url2 = dr["url2"].ToString(),
                          url3 = dr["url3"].ToString(),
                          url4 = dr["url4"].ToString(),
                          estado = dr["estado"].ToString()

                      }).ToList();

            return mostRecentList;
        }

        [HttpGet("Edification")]
        public IEnumerable<Anuncios> GetCategories([FromQuery] string edification)
        {
            string sql = $"SELECT a.* FROM anuncios a WHERE a.edificacion = '{edification}' ";
            DataTable dt = db.getTable(sql);
            List<Anuncios> categoryList = new List<Anuncios>();
            categoryList = (from DataRow dr in dt.Rows
                              select new Anuncios()
                              {
                                  idanuncio = Convert.ToInt32(dr["idanuncio"]),
                                  idusuario = Convert.ToInt32(dr["idusuario"]),
                                  titulo = dr["titulo"].ToString(),
                                  direccion = dr["direccion"].ToString(),
                                  descripcion = dr["descripcion"].ToString(),
                                  modalidad = dr["modalidad"].ToString(),
                                  zona = dr["zona"].ToString(),
                                  edificacion = dr["edificacion"].ToString(),
                                  habitaciones = Convert.ToInt32(dr["habitaciones"]),
                                  garaje = dr["garaje"].ToString(),
                                  precio = Convert.ToInt64(dr["precio"]),
                                  fecha = dr["fecha"].ToString(),
                                  url1 = dr["url1"].ToString(),
                                  url2 = dr["url2"].ToString(),
                                  url3 = dr["url3"].ToString(),
                                  url4 = dr["url4"].ToString(),
                                  estado = dr["estado"].ToString()

                              }).ToList();

            return categoryList;
        }


        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromQuery] string value)
        {    
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //POST api/<HomeController/BusquedaFiltro>/value
        [HttpPost("BusquedaFiltro{id}")]
        public void filterPost([FromBody] string value)
        {
        }
    }
}
