using AccesoDatos.Entidades;
using AccesoDatos.Interfaces;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGestionBiblioteca_Progra06.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClienteController : ControllerBase
    {
        public IConfiguration lConfiguracion;
        private readonly iClienteLN gObjClienteLN_ENT = new ClienteLN();

        public ClienteController(IConfiguration lConfig)
        {
            lConfiguracion = lConfig;
        }

        [Route("[action]")]
        [HttpGet]
        public List<TbiblioCliente> obtenerClientes()
        {
            List<TbiblioCliente> lObjRespuesta = new List<TbiblioCliente>();
            try
            {
                lObjRespuesta = gObjClienteLN_ENT.ObtenerClientes();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        [Route("[action]/{pIdCliente}")]
        [HttpGet]
        public TbiblioCliente obtenerClienteXID(int pIdCliente)
        {
            TbiblioCliente lObjRespuesta = new TbiblioCliente();
            try
            {
                lObjRespuesta = gObjClienteLN_ENT.ObtenerClienteXID(pIdCliente);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insCliente([FromBody] TbiblioCliente pCliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gObjClienteLN_ENT.InsCliente(pCliente);
                    return Ok(pCliente);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult modCliente([FromBody] TbiblioCliente pCliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gObjClienteLN_ENT.ModCliente(pCliente);
                    return Ok(pCliente);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }

        [Route("[action]/{pIdCliente}")]
        [HttpDelete]
        [HttpPost]
        public IActionResult delCliente(int pIdCliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var regExiste = gObjClienteLN_ENT.ObtenerClienteXID(pIdCliente);
                    if (regExiste != null)
                    {
                        gObjClienteLN_ENT.DelCliente(regExiste);
                        return Ok(regExiste);
                    }
                    else
                    {
                        return BadRequest();
                    }

                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception lEx)
            {
                throw lEx;
            }
        }
    }
}
