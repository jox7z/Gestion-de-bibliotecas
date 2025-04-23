using Gestion_De_Bibliotecas_Programacion06_UI.Models;
using Newtonsoft.Json;
using System.Text;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Libro
{
    public class srvLibro : IsrvLibro
    {
        private static string gBaseUrl;
        private static string gToken;

        public srvLibro()
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

        public async Task<List<mLibro>> obtenerLibro()
        {
            List<mLibro> lObjRespuesta = new List<mLibro>();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.GetAsync("Libro/obtenerLibros");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjRespuesta = JsonConvert.DeserializeObject<List<mLibro>>(respuesta);
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public async Task<mLibro> obtenerLibroXId(int pIdLibro)
        {
            mLibro lObjRespuesta = new mLibro();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.GetAsync($"Libro/obtenerLibroXID/{pIdLibro}");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjRespuesta = JsonConvert.DeserializeObject<mLibro>(respuesta);
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public async Task<bool> agregaLibro(mLibro pLibro)
        {
            mLibro lObjResultado = new mLibro();
            bool lObjRespuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var contenido = new StringContent(JsonConvert.SerializeObject(pLibro), Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PostAsync("Libro/insLibro/", contenido);
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mLibro>(respuesta);
                    if (lObjResultado.TnIdLibro != null)
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

        public async Task<bool> modificaLibro(mLibro pLibro)
        {
            mLibro lObjResultado = new mLibro();
            bool lObjRespuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var contenido = new StringContent(JsonConvert.SerializeObject(pLibro), Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PostAsync("Libro/modLibro/", contenido);
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mLibro>(respuesta);
                    if (lObjResultado.TnIdLibro != null)
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

        public async Task<bool> eliminaLibro(int pIdLibro)
        {
            mLibro lObjResultado = new mLibro();
            bool lObjRespuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.DeleteAsync($"Libro/delLibro/{pIdLibro}");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mLibro>(respuesta);
                    if (lObjResultado.TnIdLibro != null)
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
