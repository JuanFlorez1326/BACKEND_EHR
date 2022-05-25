using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model.Entities
{
    public class Oferta
    {
        private int _idoferta;
        public int idoferta { set { _idoferta = value; } get { return _idoferta; } }

        private int _idanuncio;
        public int idanuncio { set { _idanuncio = value; } get { return _idanuncio; } }
        
        private int _idusuario;
        public int idusuario { set { _idusuario = value; } get { return _idusuario; } }
    }
}
