using Gestion_De_Bibliotecas_Programacion06_UI.Models;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Autor;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IsrvCliente gApiCliente;

        public ClienteController(IsrvCliente lApiCliente)
        {
            gApiCliente = lApiCliente;
        }

        public async Task<ActionResult> obtenerCliente()
        {
            List<mCliente> lObjRespuesta = new List<mCliente>();
            try
            {
                lObjRespuesta = await gApiCliente.obtenerCliente();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        public async Task<ActionResult> agregaCliente()
        {
            return View();
        }

        public async Task<ActionResult> modificaCliente(int pIdCliente)
        {
            mCliente lObjRespuesta = new mCliente();
            try
            {
                lObjRespuesta = await gApiCliente.obtenerClienteXId(pIdCliente);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        public async Task<ActionResult> eliminaCliente(int pIdCliente)
        {
            mCliente lObjRespuesta = new mCliente();
            try
            {
                lObjRespuesta = await gApiCliente.obtenerClienteXId(pIdCliente);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        public async Task<ActionResult> detalleCliente(int pIdCliente)
        {
            mCliente lObjRespuesta = new mCliente();
            try
            {
                lObjRespuesta = await gApiCliente.obtenerClienteXId(pIdCliente);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View(lObjRespuesta);
        }

        /***********************ACCIONES DE INS-MOD-DEL ****************************************/

        public async Task<ActionResult> insCliente(mCliente pCliente)
        {
            List<mCliente> lObjRespuesta = new List<mCliente>();
            try
            {
                if (await gApiCliente.agregaCliente(pCliente))
                {
                    //mensaje de exitoso
                }
                else
                {
                    //mensaje de no exitoso
                }
                lObjRespuesta = await gApiCliente.obtenerCliente();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerCliente", lObjRespuesta);
        }

        public async Task<ActionResult> modCliente(mCliente pCliente)
        {
            List<mCliente> lObjRespuesta = new List<mCliente>();
            try
            {
                if (await gApiCliente.modificaCliente(pCliente))
                {
                    //mensaje de exitoso
                }
                else
                {
                    //mensaje de no exitoso
                }
                lObjRespuesta = await gApiCliente.obtenerCliente();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerCliente", lObjRespuesta);
        }

        public async Task<ActionResult> delCliente(mCliente pCliente)
        {
            List<mCliente> lObjRespuesta = new List<mCliente>();
            try
            {
                if (await gApiCliente.eliminaCliente(pCliente.TnIdCliente))
                {
                    //mensaje de exitoso
                }
                else
                {
                    //mensaje de no exitoso
                }
                lObjRespuesta = await gApiCliente.obtenerCliente();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return View("obtenerCliente", lObjRespuesta);
        }

    }
}
