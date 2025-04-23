using Gestion_De_Bibliotecas_Programacion06_UI.Models;
using Newtonsoft.Json;
using System.Text;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Prestamo
{
    public class srvPrestamo : IsrvPrestamo
    {
        private static string gBaseUrl;
        private static string gToken;

        public srvPrestamo()
        {
            var appConfig = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            gBaseUrl = appConfig.GetSection("ConfigApi:baseUrl").Value;
        }

        public async Task<string> Autenticar(Usuario pLogin)
        {
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                var credenciales = new Usuario() { usuario = pLogin.usuario, contrasena = pLogin.contrasena };
                var contenido = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PostAsync("api/Autenticacion/validarUsuario/", contenido);
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    var resultado = JsonConvert.DeserializeObject<resultadoToken>(respuesta);
                    gToken = resultado.token;
                }
                else
                {
                    gToken = "";
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return gToken;
        }

        public async Task<List<mPrestamo>> obtenerPrestamo()
        {
            List<mPrestamo> lObjRespuesta = new List<mPrestamo>();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.GetAsync("Prestamo/obtenerPrestamos");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjRespuesta = JsonConvert.DeserializeObject<List<mPrestamo>>(respuesta);
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public async Task<mPrestamo> obtenerPrestamoXId(int pIdPrestamo)
        {
            mPrestamo lObjRespuesta = new mPrestamo();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.GetAsync($"Prestamo/obtenerPrestamoXID/{pIdPrestamo}");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjRespuesta = JsonConvert.DeserializeObject<mPrestamo>(respuesta);
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public async Task<bool> agregaPrestamo(mPrestamo pPrestamo)
        {
            mPrestamo lObjResultado = new mPrestamo();
            bool lObjRespuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var contenido = new StringContent(JsonConvert.SerializeObject(pPrestamo), Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PostAsync("Prestamo/insPrestamo/", contenido);
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mPrestamo>(respuesta);
                    if (lObjResultado.TnIdPrestamo != null)
                    {
                        lObjRespuesta = true;
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public async Task<bool> modificaPrestamo(mPrestamo pPrestamo)
        {
            mPrestamo lObjResultado = new mPrestamo();
            bool lObjRespuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var contenido = new StringContent(JsonConvert.SerializeObject(pPrestamo), Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PostAsync("Prestamo/modPrestamo/", contenido);
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mPrestamo>(respuesta);
                    if (lObjResultado.TnIdPrestamo != null)
                    {
                        lObjRespuesta = true;
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public async Task<bool> eliminaPrestamo(int pIdPrestamo)
        {
            mPrestamo lObjResultado = new mPrestamo();
            bool lObjRespuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.DeleteAsync($"Prestamo/delPrestamo/{pIdPrestamo}");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mPrestamo>(respuesta);
                    if (lObjResultado.TnIdPrestamo != null)
                    {
                        lObjRespuesta = true;
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

    }
}
