using Gestion_De_Bibliotecas_Programacion06_UI.Models;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Autor;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Libro;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Controllers
{
    public class LibroController : Controller
    {
        private readonly IsrvLibro gApiLibro;

        public LibroController(IsrvLibro lApiLibro)
        {
            gApiLibro = lApiLibro;
        }


        public async Task<ActionResult> obtenerLibro()
        {
            List<mLibro> lObjRespuesta = new List<mLibro>();
            try
            {
                lObjRespuesta = await gApiLibro.obtenerLibro();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        public async Task<ActionResult> agregaLibro()
        {
            return View();
        }

        public async Task<ActionResult> modificaLibro(int pIdLibro)
        {
            mLibro lObjRespuesta = new mLibro();
            try
            {
                lObjRespuesta = await gApiLibro.obtenerLibroXId(pIdLibro);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        public async Task<ActionResult> eliminaLibro(int pIdLibro)
        {
            mLibro lObjRespuesta = new mLibro();
            try
            {
                lObjRespuesta = await gApiLibro.obtenerLibroXId(pIdLibro);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        public async Task<ActionResult> detalleLibro(int pIdLibro)
        {
            mLibro lObjRespuesta = new mLibro();
            try
            {
                lObjRespuesta = await gApiLibro.obtenerLibroXId(pIdLibro);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        /***********************ACCIONES DE INS-MOD-DEL ****************************************/

        public async Task<ActionResult> insLibro(mLibro pLibro)
        {
            List<mLibro> lObjRespuesta = new List<mLibro>();
            try
            {
                if (await gApiLibro.agregaLibro(pLibro))
                {
                    //mensaje de exitoso
                }
                else
                {
                    //mensaje de no exitoso
                }
                lObjRespuesta = await gApiLibro.obtenerLibro();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerLibro", lObjRespuesta);
        }

        public async Task<ActionResult> modLibro(mLibro pLibro)
        {
            List<mLibro> lObjRespuesta = new List<mLibro>();
            try
            {
                if (await gApiLibro.modificaLibro(pLibro))
                {
                    //mensaje de exitoso
                }
                else
                {
                    //mensaje de no exitoso
                }
                lObjRespuesta = await gApiLibro.obtenerLibro();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerLibro", lObjRespuesta);
        }

        public async Task<ActionResult> delLibro(mLibro pLibro)
        {
            List<mLibro> lObjRespuesta = new List<mLibro>();
            try
            {
                if (await gApiLibro.eliminaLibro(pLibro.TnIdLibro))
                {
                    //mensaje de exitoso
                }
                else
                {
                    //mensaje de no exitoso
                }
                lObjRespuesta = await gApiLibro.obtenerLibro();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerLibro", lObjRespuesta);
        }
    }
}
