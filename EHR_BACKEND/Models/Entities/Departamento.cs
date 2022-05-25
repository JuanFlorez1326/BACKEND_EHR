using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EasyHouseRent.Model.Entities
{
    public class Departamento
    {
        BaseData db = new BaseData();
        private int _iddepartamento = 0;
        public int iddepartamento { get { return _iddepartamento; } set { _iddepartamento = value; } }
        private string _nombre = "";
        public string nombre { get { return _nombre; } set { _nombre = value; } }
    }
}
