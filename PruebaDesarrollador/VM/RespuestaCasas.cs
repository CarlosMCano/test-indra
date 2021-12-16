using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesarrollador.VM
{
    public class RespuestaCasas
    {
        public RespuestaCasas()
        {
            entrada = new List<int>();
            salida = new List<int>();
        }
        public List<int> entrada { get; set; }
        public List<int> salida { get; set; }
        public int dias { get; set; }
    }
}
