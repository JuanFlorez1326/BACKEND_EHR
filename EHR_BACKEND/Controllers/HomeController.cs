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
    public class HomeController : ControllerBase
    {
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
                string sql = $"SELECT idanuncio,idusuario,titulo,direccion,descripcion,modalidad,zona,edificacion,habitaciones,garaje,precio,fecha,url1,url2,url3,url4,estado,ciudad FROM anuncios a WHERE zona LIKE '%{value}%' OR titulo LIKE '%{value}%' OR direccion LIKE '%{value}%';";
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
                              estado = dr["estado"].ToString(),
                              ciudad = dr["ciudad"].ToString()

                          }).ToList();

                return dataAd;
            }
        }

        [HttpGet("MostRecent")]
        public IEnumerable<Anuncios> GetMostRecent([FromQuery] string value)
        {
            string sql = $"SELECT idanuncio,idusuario,titulo,direccion,descripcion,modalidad,zona,edificacion,habitaciones,garaje,precio,fecha,url1,url2,url3,url4,estado,ciudad FROM anuncios ORDER BY idanuncio DESC LIMIT 20;";
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
                        estado = dr["estado"].ToString(),
                        ciudad = dr["ciudad"].ToString()

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
                                estado = dr["estado"].ToString(),
                                ciudad = dr["ciudad"].ToString()

                              }).ToList();

            return categoryList;
        }

        [HttpGet("Recommended")]
        public IEnumerable<Anuncios> GetAllAds([FromQuery] string ciudad, int idAd)
        {
            if(ciudad == "")
            {
                return null;
            }
            else
            {
                string sql = $"SELECT idanuncio,idusuario,titulo,direccion,descripcion,modalidad,zona,edificacion,habitaciones,garaje,precio,fecha,url1,url2,url3,url4,estado,ciudad FROM anuncios WHERE ciudad = '{ciudad}' AND idanuncio <> {idAd};";
                DataTable dt = db.getTable(sql);
                List<Anuncios> listRecommended = new List<Anuncios>();
                listRecommended = (from DataRow dr in dt.Rows
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
                                    estado = dr["estado"].ToString(),
                                    ciudad = dr["ciudad"].ToString()
                                    
                                }).ToList();
                return listRecommended; 
            }
        }

        [HttpGet("Random")]
        public IEnumerable<Anuncios> GetRandom([FromQuery] string value)
        {
            string sql = $"SELECT idanuncio,idusuario,titulo,direccion,descripcion,modalidad,zona,edificacion,habitaciones,garaje,precio,fecha,url1,url2,url3,url4,estado,ciudad FROM anuncios ORDER BY RAND() LIMIT 5;";
            DataTable dt = db.getTable(sql);
            List<Anuncios> listRecommended = new List<Anuncios>();
            listRecommended = (from DataRow dr in dt.Rows
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
                                estado = dr["estado"].ToString(),
                                ciudad = dr["ciudad"].ToString()
                                
                            }).ToList();

            return listRecommended; 
        }
    }
}