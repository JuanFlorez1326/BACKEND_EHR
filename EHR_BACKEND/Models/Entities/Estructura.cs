using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model.Entities
{
    public class Estructura
    {
        private int _idestructura = 0;
        public int idestructura { get { return _idestructura; } set { _idestructura = value; } }

        private string _nombre {set; get;}
        public string nombre { get { return _nombre;} set { _nombre = value; } }

    }
}
