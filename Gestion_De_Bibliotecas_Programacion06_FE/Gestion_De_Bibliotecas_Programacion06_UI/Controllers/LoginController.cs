using Gestion_De_Bibliotecas_Programacion06_UI.Models;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Autor;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Cliente;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Libro;
using Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Prestamo;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IsrvAutor gApiAutor;
        private readonly IsrvCliente gApiCliente;
        private readonly IsrvLibro gApiLibro;
        private readonly IsrvPrestamo gApiPrestamo;

        public LoginController(IsrvAutor lApiAutor, IsrvCliente lApiCliente, IsrvLibro lApiLibro, IsrvPrestamo lApiPrestamo)
        { 
            gApiAutor = lApiAutor;
            gApiCliente = lApiCliente;
            gApiLibro = lApiLibro;
            gApiPrestamo = lApiPrestamo;
        }

        public async Task<ActionResult> Login()
        {
            return View();
        }

        public async Task<ActionResult> errorGeneral()
        {
            return View();
        }

        public async Task<ActionResult> accesoUsuario(Usuario pLogin)
        {
            string token = await gApiAutor.Autenticar(pLogin);
            string token2 = await gApiCliente.Autenticar(pLogin);
            string token3 = await gApiLibro.Autenticar(pLogin);
            string token4 = await gApiPrestamo.Autenticar(pLogin);
            if (token != null)
            {
                if (token != "")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("errorGeneral");
                }
            }
            else
            {
                return View("errorGeneral");
            }
            if (token2 != null)
            {
                if (token != "")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("errorGeneral");
                }
            }
            else
            {
                return View("errorGeneral");
            }
            if (token3 != null)
            {
                if (token != "")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("errorGeneral");
                }
            }
            else
            {
                return View("errorGeneral");
            }
            if (token4 != null)
            {
                if (token != "")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("errorGeneral");
                }
            }
            else
            {
                return View("errorGeneral");
            }
        }

        public async Task<ActionResult> retornarLogin()
        {
            return View("Login");
        }
    }
}
