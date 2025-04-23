using AccesoDatos.Entidades;
using AccesoDatos.Interfaces;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiGestionBiblioteca_Progra06.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]

    public class AutorController : ControllerBase
    {
        public IConfiguration lConfiguracion;
        private readonly iAutorLN gObjAutorLN_ENT = new AutorLN();

        public AutorController(IConfiguration lConfig)
        {
            lConfiguracion = lConfig;
            string lCadenaConexion = lConfig.GetConnectionString("AWCnn");
        }

        [Route("[action]")]
        [HttpGet]
        public List<TbiblioAutor> obtenerAutores()
        {
            List<TbiblioAutor> lObjRespuesta = new List<TbiblioAutor>();
            try
            {
                lObjRespuesta = gObjAutorLN_ENT.ObtenerAutores();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        [Route("[action]/{pIdAutor}")]
        [HttpGet]
        public TbiblioAutor obtenerAutoresXID(int pIdAutor)
        {
            TbiblioAutor lObjRespuesta = new TbiblioAutor();
            try
            {
                lObjRespuesta = gObjAutorLN_ENT.ObtenerAutoresXID(pIdAutor);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insAutor([FromBody] TbiblioAutor pAutor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gObjAutorLN_ENT.insAutor(pAutor);
                    return Ok(pAutor);
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
        public IActionResult modAutor([FromBody] TbiblioAutor pAutor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gObjAutorLN_ENT.modAutor(pAutor);
                    return Ok(pAutor);
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

        [Route("[action]/{pIdAutor}")]
        [HttpDelete]
        [HttpPost]
        public IActionResult delAutor(int pIdAutor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var regExiste = gObjAutorLN_ENT.ObtenerAutoresXID(pIdAutor);
                    if (regExiste != null)
                    {
                        gObjAutorLN_ENT.delAutor(regExiste);
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
