using Gestion_De_Bibliotecas_Programacion06_UI.Models;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Autor;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Prestamo;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly IsrvPrestamo gApiPrestamo;

        public PrestamoController(IsrvPrestamo lApiPrestamo)
        {
            gApiPrestamo = lApiPrestamo;
        }


        public async Task<ActionResult> obtenerPrestamo()
        {
            List<mPrestamo> lObjRespuesta = new List<mPrestamo>();
            try
            {
                lObjRespuesta = await gApiPrestamo.obtenerPrestamo();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        public async Task<ActionResult> agregaPrestamo()
        {
            return View();
        }

        public async Task<ActionResult> modificaPrestamo(int pIdPrestamo)
        {
            mPrestamo lObjRespuesta = new mPrestamo();
            try
            {
                lObjRespuesta = await gApiPrestamo.obtenerPrestamoXId(pIdPrestamo);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        public async Task<ActionResult> eliminaPrestamo(int pIdPrestamo)
        {
            mPrestamo lObjRespuesta = new mPrestamo();
            try
            {
                lObjRespuesta = await gApiPrestamo.obtenerPrestamoXId(pIdPrestamo);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        public async Task<ActionResult> detallePrestamo(int pIdPrestamo)
        {
            mPrestamo lObjRespuesta = new mPrestamo();
            try
            {
                lObjRespuesta = await gApiPrestamo.obtenerPrestamoXId(pIdPrestamo);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        /*********************** ACCIONES DE INS-MOD-DEL ****************************************/

        public async Task<ActionResult> insPrestamo(mPrestamo pPrestamo)
        {
            List<mPrestamo> lObjRespuesta = new List<mPrestamo>();
            try
            {
                if (await gApiPrestamo.agregaPrestamo(pPrestamo))
                {
                    // mensaje de exitoso
                }
                else
                {
                    // mensaje de no exitoso
                }
                lObjRespuesta = await gApiPrestamo.obtenerPrestamo();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerPrestamo", lObjRespuesta);
        }

        public async Task<ActionResult> modPrestamo(mPrestamo pPrestamo)
        {
            List<mPrestamo> lObjRespuesta = new List<mPrestamo>();
            try
            {
                if (await gApiPrestamo.modificaPrestamo(pPrestamo))
                {
                    // mensaje de exitoso
                }
                else
                {
                    // mensaje de no exitoso
                }
                lObjRespuesta = await gApiPrestamo.obtenerPrestamo();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerPrestamo", lObjRespuesta);
        }

        public async Task<ActionResult> delPrestamo(mPrestamo pPrestamo)
        {
            List<mPrestamo> lObjRespuesta = new List<mPrestamo>();
            try
            {
                if (await gApiPrestamo.eliminaPrestamo(pPrestamo.TnIdPrestamo))
                {
                    // mensaje de exitoso
                }
                else
                {
                    // mensaje de no exitoso
                }
                lObjRespuesta = await gApiPrestamo.obtenerPrestamo();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerPrestamo", lObjRespuesta);
        }

    }
}
