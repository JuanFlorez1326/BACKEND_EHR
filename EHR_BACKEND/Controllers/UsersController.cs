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
    public class UsersController : ControllerBase
    {
        BaseData db = new BaseData(); 

        [HttpGet("GetUser")]
        public IEnumerable<Usuarios> GetUser([FromQuery]int idusuario)
        {
            string sql = $"SELECT u.idusuario,u.nombre,u.apellidos,u.email,u.telefono,u.foto,d.nombre AS depnombre,m.nombre AS munnombre FROM departamento d INNER JOIN usuarios u ON d.iddepartamento = u.departamento INNER JOIN municipios m ON u.municipio = m.idmunicipio  WHERE idusuario = {idusuario};";
            DataTable dt = db.getTable(sql);
            List<Usuarios> userList = new List<Usuarios>();
            List<Municipios> munList = new List<Municipios>();
            List<Departamento> depList = new List<Departamento>();

            munList = (from DataRow dr in dt.Rows
                        select new Municipios()
                        {
                            nombre = dr["munnombre"].ToString()

                        }).ToList();

            depList = (from DataRow dr in dt.Rows
                        select new Departamento()
                        {
                            nombre = dr["depnombre"].ToString()
                        }).ToList();

            userList = (from DataRow dr in dt.Rows
                        select new Usuarios()
                            {
                            idusuario = Convert.ToInt32(dr["idusuario"]),
                            nombre = dr["nombre"].ToString(),
                            apellidos = dr["apellidos"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            email = dr["email"].ToString(),
                            foto = dr["foto"].ToString(),
                            listDepartment = depList,
                            listMunicipality = munList

                        }).ToList();

            return userList;
        }

        [HttpPost]
        public string Post([FromBody] Usuarios user)
        {
            string sql = "INSERT INTO usuarios (nombre,apellidos,edad,telefono,email,contraseña,estado,departamento,municipio, foto) VALUES ('" + user.nombre + "','" + user.apellidos + "','" + user.edad + "','" + user.telefono + "','" + user.email + "','" + user.contrasenna + "','" + user.estado + "','" + user.departamento + "','" + user.municipio + "','"+user.foto+"' );";
            return db.executeSql(sql);
        }

        [HttpPut]
        public string Put([FromBody] Usuarios user)
        {
            string sql = "UPDATE usuarios SET nombre = '" + user.nombre + "', apellidos = '" + user.apellidos + "', edad = '" + user.edad + "', telefono ='" + user.telefono + "', email ='" + user.email + "'  WHERE idusuario = '" + user.idusuario + "';";
            return db.executeSql(sql); 
        }

        [HttpPost("ProfilePicture")]
        public string PutProfilePicture([FromBody] Usuarios user)
        {
            string sql = $"UPDATE usuarios SET foto = '{user.foto}' WHERE idusuario = {user.idusuario}";
            return db.executeSql(sql);
        }

        [HttpDelete]
        public string Delete([FromBody] Usuarios user)
        {
            string sql = "DELETE FROM usuarios WHERE idusuario = " + user.idusuario;
            return db.executeSql(sql); 
        }
    }
}