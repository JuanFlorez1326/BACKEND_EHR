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
    [ApiController]
    [Route("api/[controller]")]
    public class AdvertisementController : ControllerBase
    {

        BaseData db = new BaseData(); 
        Anuncios anuncios = new Anuncios(); 
        // GET: api/<AdController>
        [HttpGet]
        public List<object> Get([FromQuery] Anuncios Ad)
        {
            string sql = $"SELECT * FROM anuncios";
            return db.ConvertDataTabletoString(sql);
        }

        // GET api/<AdController>/5
        [HttpGet("{id}")]
        public List<object> GetAd(int id)
        {
            string sql = $"SELECT * FROM anuncios WHERE idanuncio = '{id}'";
            return db.ConvertDataTabletoString(sql);
        }

        // POST api/<AdController>
        [HttpPost]
        public string Post([FromBody] Anuncios Ad)
        {
            string sql = "INSERT INTO anuncios (idusuario,titulo,direccion,descripcion,modalidad,zona,edificacion,habitaciones,garaje,precio,fecha,url1,url2,url3,url4,estado) VALUES ('" + Ad.idusuario + "','" + Ad.titulo + "','" + Ad.direccion + "','" + Ad.descripcion + "','" + Ad.modalidad + "','" + Ad.zona + "','" + Ad.edificacion + "','" + Ad.habitaciones + "','" + Ad.garaje + "','" + Ad.precio + "','" + Ad.fecha + "','" + Ad.url1 + "','" + Ad.url2 + "','" + Ad.url3 + "','" + Ad.url4 + "', '" + Ad.estado + "');";
            return db.executeSql(sql);
        }

        // PUT api/<AdController>/5
        [HttpPut("{id}")]
        public string Put([FromBody] Anuncios ad)
        {
            string sql = "UPDATE anuncios SET titulo = '" + ad.titulo + "', direccion = '" + ad.direccion + "', descripcion = '" + ad.descripcion + "', direccion ='" + ad.direccion + "', modalidad ='" + ad.modalidad + "', zona ='" + ad.zona + "', edificacion ='" + ad.edificacion + "', habitaciones ='" + ad.habitaciones + "', garaje ='" + ad.garaje + "', precio ='" + ad.precio + "', fecha ='" + ad.fecha + "', url1 ='" + ad.url1 + "', url2 ='" + ad.url2 + "', url3 ='" + ad.url3 + "', url4 ='" + ad.url4 + "', estado ='" + ad.estado + "'  WHERE idanuncio = '" + ad.idanuncio + "'";
            return db.executeSql(sql);
        }

        // DELETE api/<AdController>/5
        [HttpDelete("{id}")]
        public string Delete([FromBody] Anuncios ad)
        {
            string sql = $"DELETE FROM anuncios WHERE idanuncio =" + ad.idanuncio;
            return db.executeSql(sql);
        }
    }
}