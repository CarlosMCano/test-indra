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
    public class CasasController : ControllerBase
    {
        [HttpPost("[action]")]
        public ActionResult<RespuestaCasas> EstadoCeldas(PeticionCasas datos)
        {

            RespuestaCasas response = new RespuestaCasas();
            List<int> listaTemporal = new List<int>();
            try
            {
                // Validaciones minimas para continuar con el proceso
                if (!validacionesIniciales(datos))
                    return response;


                response.dias = datos.dias;
                response.entrada = datos.lstCasas;

                for (int j = 1; j <= datos.dias; j++)
                {
                    listaTemporal = listaTemporal.Count == 0 ? datos.lstCasas : response.salida;
                    response.salida = new List<int>();

                    for (int i = 0; i < listaTemporal.Count; i++)
                    {
                        // Se valida si es la primer posicion ya que al tener solamente una celda adyacente
                        // se puede asumir que el vecino faltante siempre tendrá un estado inactivo
                        if (i == 0)
                        {
                            if (listaTemporal[i + 1] == 0)
                            {
                                response.salida.Add(0);
                            }
                            else
                            {
                                response.salida.Add(1);
                            }
                        }
                        // Se valida si es la ultima posicion ya que al tener solamente una celda adyacente
                        // se puede asumir que el vecino faltante siempre tendrá un estado inactivo
                        else if (i == (listaTemporal.Count - 1))
                        {
                            if (listaTemporal[i - 1] == 0)
                            {
                                response.salida.Add(0);
                            }
                            else
                            {
                                response.salida.Add(1);
                            }
                        }
                        else
                        {
                            if (listaTemporal[i - 1] == listaTemporal[i + 1])
                            {
                                response.salida.Add(0);
                            }
                            else
                            {
                                response.salida.Add(1);
                            }
                        }
                    }
                }


                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private bool validacionesIniciales(PeticionCasas datos)
        {
            try
            {
                if (datos == null)
                    return false;

                if (datos.lstCasas.Count == 0)
                    return false;

                if (datos.lstCasas.Any(x => x != 1 && x != 0))
                    return false;

                if (datos.dias < 0)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
