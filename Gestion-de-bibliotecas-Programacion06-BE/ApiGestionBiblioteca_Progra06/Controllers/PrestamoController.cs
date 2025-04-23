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
    
    public class PrestamoController : ControllerBase
    {
        public IConfiguration lConfiguracion;
        private readonly iPrestamoLN gObjPrestamoLN_ENT = new PrestamoLN();

        public PrestamoController(IConfiguration lConfig)
        {
            lConfiguracion = lConfig;

            string lCadenaConexion = lConfig.GetConnectionString("AWCnn");
        }

        [Route("[action]")]
        [HttpGet]
        public List<TbiblioPrestamo> obtenerPrestamos()
        {
            List<TbiblioPrestamo> lObjRespuesta = new List<TbiblioPrestamo>();
            try
            {
                lObjRespuesta = gObjPrestamoLN_ENT.ObtenerPrestamos();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        [Route("[action]/{pIdPrestamo}")]
        [HttpGet]
        public TbiblioPrestamo obtenerPrestamoXID(int pIdPrestamo)
        {
            TbiblioPrestamo lObjRespuesta = new TbiblioPrestamo();
            try
            {
                lObjRespuesta = gObjPrestamoLN_ENT.ObtenerPrestamoXID(pIdPrestamo);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult insPrestamo([FromBody] TbiblioPrestamo pPrestamo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gObjPrestamoLN_ENT.InsPrestamo(pPrestamo);
                    return Ok(pPrestamo);
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
        public IActionResult modPrestamo([FromBody] TbiblioPrestamo pPrestamo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    gObjPrestamoLN_ENT.ModPrestamo(pPrestamo);
                    return Ok(pPrestamo);
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

        [Route("[action]/{pIdPrestamo}")]
        [HttpDelete]
        [HttpPost]
        public IActionResult delPrestamo(int pIdPrestamo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var regExiste = gObjPrestamoLN_ENT.ObtenerPrestamoXID(pIdPrestamo);
                    if (regExiste != null)
                    {
                        gObjPrestamoLN_ENT.DelPrestamo(regExiste);
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
