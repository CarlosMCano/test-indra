using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesarrollador.VM
{
    public class RespuestaEnvioPaquetes
    {
        public RespuestaEnvioPaquetes()
        {
            salidaPaquetes = new List<int>();
        }
        public List<int> salidaPaquetes { get; set; }
    }
}
