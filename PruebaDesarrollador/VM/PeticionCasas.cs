using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesarrollador.VM
{
    public class PeticionCasas
    {
        public PeticionCasas()
        {
            lstCasas = new List<int>();
        }
        public List<int> lstCasas { get; set; }
        public int dias { get; set; }

    }
}
