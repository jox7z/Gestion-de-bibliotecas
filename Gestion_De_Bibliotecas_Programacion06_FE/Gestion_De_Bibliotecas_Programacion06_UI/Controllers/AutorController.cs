using Gestion_De_Bibliotecas_Programacion06_UI.Models;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Autor;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Controllers
{
    public class AutorController : Controller
    {
        private readonly IsrvAutor gApiAutor;

        public AutorController(IsrvAutor lApiAutor)
        {
            gApiAutor = lApiAutor;
        }

        public async Task<ActionResult> obtenerAutor()
        {
            List<mAutor> lObjRespuesta = new List<mAutor>();
            try
            {
                lObjRespuesta = await gApiAutor.obtenerAutor();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        public async Task<ActionResult> agregaAutor()
        {
            return View();
        }

        public async Task<ActionResult> modificaAutor(int pIdAutor)
        {
            mAutor lObjRespuesta = new mAutor();
            try
            {
                lObjRespuesta = await gApiAutor.obtenerAutorXId(pIdAutor);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        public async Task<ActionResult> eliminaAutor(int pIdAutor)
        {
            mAutor lObjRespuesta = new  ();
            try
            {
                lObjRespuesta = await gApiAutor.obtenerAutorXId(pIdAutor);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        public async Task<ActionResult> detalleAutor(int pIdAutor)
        {
            mAutor lObjRespuesta = new mAutor();
            try
            {
                lObjRespuesta = await gApiAutor.obtenerAutorXId(pIdAutor);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        /***********************ACCIONES DE INS-MOD-DEL ****************************************/

        public async Task<ActionResult> insAutor(mAutor pAutor)
        {
            List<mAutor> lObjRespuesta = new List<mAutor>();
            try
            {
                if (await gApiAutor.agregaAutor(pAutor))
                {
                    //mensaje de exitoso
                }
                else
                {
                    //mensaje de no exitoso
                }
                lObjRespuesta = await gApiAutor.obtenerAutor();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerAutor", lObjRespuesta);
        }

        public async Task<ActionResult> modAutor(mAutor pAutor)
        {
            List<mAutor> lObjRespuesta = new List<mAutor>();
            try
            {
                if (await gApiAutor.modificaAutor(pAutor))
                {
                    //mensaje de exitoso
                }
                else
                {
                    //mensaje de no exitoso
                }
                lObjRespuesta = await gApiAutor.obtenerAutor();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerAutor", lObjRespuesta);
        }

        public async Task<ActionResult> delAutor(mAutor pAutor)
        {
            List<mAutor> lObjRespuesta = new List<mAutor>();
            try
            {
                if (await gApiAutor.eliminaAutor(pAutor.TnIdAutor))
                {
                    //mensaje de exitoso
                }
                else
                {
                    //mensaje de no exitoso
                }
                lObjRespuesta = await gApiAutor.obtenerAutor();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerAutor", lObjRespuesta);
        }
    }
}
