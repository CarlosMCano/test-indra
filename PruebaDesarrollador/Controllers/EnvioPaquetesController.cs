using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaDesarrollador.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesarrollador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioPaquetesController : ControllerBase
    {

        [HttpPost("[action]")]
        public ActionResult<List<int>> AsignarPaquetes(PeticionEnvioPaquetes datos)
        {
            List<int> respuesta = new List<int>();
            

            try
            {
                int tamanoCamionReserva = datos.tamanioCamion - 30;

                for (int i = 0; i < datos.lstPaquetes.Count; i++)
                {
                    for (int j = datos.lstPaquetes.Count - 1; j >= 0; j--)
                    {
                        if (j != i)
                        {
                            if (datos.lstPaquetes[i] + datos.lstPaquetes[j] == tamanoCamionReserva)
                            {
                                respuesta.Add(datos.lstPaquetes[i]);
                                respuesta.Add(datos.lstPaquetes[j]);
                                return Ok(respuesta);
                            }
                        }

                    }
                }

                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
