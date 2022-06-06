﻿using EasyHouseRent.Model;
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
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        BaseData db = new BaseData(); 
        [HttpGet]
        public void Get([FromQuery]Usuarios user)
        {
        }

        // GET api/<UsersController>/5
        [HttpGet("GetUser")]
        public IEnumerable<Usuarios> GetUser([FromQuery]int idusuario)
        {
            string sql = $"SELECT idusuario,nombre,apellidos,email,telefono,foto FROM usuarios WHERE idusuario = '{idusuario}';";
            DataTable dt = db.getTable(sql);
            List<Usuarios> userList = new List<Usuarios>();
            userList = (from DataRow dr in dt.Rows
                         select new Usuarios()
                         {
                            idusuario = Convert.ToInt32(dr["idusuario"]),
                            nombre = dr["nombre"].ToString(),
                            apellidos = dr["apellidos"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            email = dr["email"].ToString(),
                            foto = dr["foto"].ToString()

                         }).ToList();

            return userList;
        }

        // POST api/<UsersController>
        [HttpPost]
        public string Post([FromBody] Usuarios user)
        {
            //Insertar usuario
            string sql = "INSERT INTO usuarios (nombre,apellidos,edad,telefono,email,contraseña,estado,departamento,municipio, foto) VALUES ('" + user.nombre + "','" + user.apellidos + "','" + user.edad + "','" + user.telefono + "','" + user.email + "','" + user.contrasenna + "','" + user.estado + "','" + user.departamento + "','" + user.municipio + "','"+user.foto+"' );";
            return db.executeSql(sql);
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public string Put([FromBody] Usuarios user)
        {
            //Actualizar datos del Usuario
            string sql = "UPDATE usuarios SET nombre = '" + user.nombre + "', apellidos = '" + user.apellidos + "', edad = '" + user.edad + "', telefono ='" + user.telefono + "', email ='" + user.email + "', contraseña ='" + user.contrasenna + "', estado ='" + user.estado + "', departamento ='" + user.departamento + "', municipio ='" + user.municipio + "', foto = '" + user.foto + "  WHERE idusuario = '" + user.idusuario + "'";
            return db.executeSql(sql); 
        }

        [HttpPost("ProfilePicture")]
        public string PutProfilePicture([FromBody] Usuarios user)
        {
            string sql = $"UPDATE usuarios SET foto = '{user.foto}' WHERE idusuario = {user.idusuario}";
            return db.executeSql(sql);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete]
        public string Delete([FromBody] Usuarios user)
        {
            //Eliminar Usuario
            string sql = "DELETE FROM usuarios WHERE idusuario = " + user.idusuario;
            return db.executeSql(sql); 
        }
    }
}
