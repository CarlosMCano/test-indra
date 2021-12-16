using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesarrollador.VM
{
    public class PeticionEnvioPaquetes
    {
        public PeticionEnvioPaquetes()
        {
            lstPaquetes = new List<int>();
        }
        public List<int> lstPaquetes { get; set; }
        public int tamanioCamion { get; set; }
    }
}
