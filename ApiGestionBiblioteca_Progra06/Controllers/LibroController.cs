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

    public class LibroController : ControllerBase
    {
        public IConfiguration lConfiguracion;
        private readonly ILibroLN gObjLibroLN_ENT = new LibroLN();

        public LibroController(IConfiguration lConfig)
        {
            lConfiguracion = lConfig;
        }

        [Route("[action]")]
        [HttpGet]
        public List<TbiblioLibro> obtenerLibros()
        {
            List<TbiblioLibro> lObjRespuesta = new List<TbiblioLibro>();
            try
            {
                lObjRespuesta = gObjLibroLN_ENT.ObtenerLibros();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        [Route("[action]/{pIdLibro}")]
        [HttpGet]
        public TbiblioLibro obtenerLibroXID(int pIdLibro)
        {
            TbiblioLibro lObjRespuesta = new TbiblioLibro();
            try
            {
                lObjRespuesta = gObjLibroLN_ENT.ObtenerLibroXID(pIdLibro);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insLibro([FromBody] TbiblioLibro pLibro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gObjLibroLN_ENT.InsLibro(pLibro);
                    return Ok(pLibro);
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
        public IActionResult modLibro([FromBody] TbiblioLibro pLibro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gObjLibroLN_ENT.ModLibro(pLibro);
                    return Ok(pLibro);
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

        [Route("[action]/{pIdLibro}")]
        [HttpDelete]
        [HttpPost]
        public IActionResult delLibro(int pIdLibro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var regExiste = gObjLibroLN_ENT.ObtenerLibroXID(pIdLibro);
                    if (regExiste != null)
                    {
                        gObjLibroLN_ENT.DelLibro(regExiste);
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
