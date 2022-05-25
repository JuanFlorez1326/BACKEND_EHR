using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model.Entities
{
    public class Anuncios
    {
        BaseData db = new BaseData();
        private int _idanuncio = 0;
        public int idanuncio { get { return _idanuncio; } set { _idanuncio = value; } }
        private int _idusuario = 0;
        public int idusuario { get { return _idusuario; } set { _idusuario = value; } }
        private string _titulo = "";
        public string titulo { get { return _titulo; } set { _titulo = value; } }
        private string _descripcion = "";
        public string descripcion { get { return _descripcion; } set { _descripcion = value; } }
        private int _puntuacion = 0;
        public int puntuacion { get { return _puntuacion; } set { _puntuacion = value; } }
        private string _direccion = "";
        public string direccion { get { return _direccion; } set { _direccion = value; } }
        private string _estado = "";
        public string estado { get { return _estado; } set { _estado = value; } }
        private int _tipoEstructura = 0;
        public int tipoEstructura { get { return _tipoEstructura; } set { _tipoEstructura = value; } }
        private float _precio = 0;
        public float precio { get { return _precio; } set { _precio = value; } }
        private string _fecha = "";
        public string fecha { get { return _fecha; } set { _fecha = value; } }
        private string _certificado = "";
        public string certificado { get { return _certificado; } set { _certificado = value; } }
        private string _zona = "";
        public string zona { get { return _zona; } set { _zona = value; } }
        private string _url1 = "";
        public string url1 { get { return _url1; } set { _url1 = value; } }
        private string _url2 = "";
        public string url2 { get { return _url2; } set { _url2 = value; } }
        private string _url3 = "";
        public string url3 { get { return _url3; } set { _url3 = value; } }
        private string _url4 = "";
        public string url4 { get { return _url4; } set { _url4 = value; } }
        private string _modalidad = "";
        public string modalidad { get { return _modalidad; } set { _modalidad = value; } }
        private string _edificacion = "";
        public string edificacion { get { return _edificacion; } set { _edificacion = value; } }
        private int _habitaciones = 0;
        public int habitaciones { get { return _habitaciones; } set { _habitaciones = value; } }
        private string _garaje = "";
        public string garaje { get { return _garaje; } set { _garaje = value; } }
    }
}