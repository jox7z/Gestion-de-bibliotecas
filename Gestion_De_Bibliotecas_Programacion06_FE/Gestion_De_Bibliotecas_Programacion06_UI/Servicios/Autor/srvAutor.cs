using Gestion_De_Bibliotecas_Programacion06_UI.Models;
using Newtonsoft.Json;
using System.Text;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Autor
{
    public class srvAutor : IsrvAutor
    {
        private static string gBaseUrl;
        private static string gToken;

        public srvAutor()
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

        public async Task<List<mAutor>> obtenerAutor()
        {
            List<mAutor> lObjRespuesta = new List<mAutor>();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.GetAsync("Autor/obtenerAutores");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjRespuesta = JsonConvert.DeserializeObject<List<mAutor>>(respuesta);
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public async Task<mAutor> obtenerAutorXId(int pIdAutor)
        {
            mAutor lObjRespuesta = new mAutor();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.GetAsync($"Autor/obtenerAutoresXID/{pIdAutor}");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjRespuesta = JsonConvert.DeserializeObject<mAutor>(respuesta);
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public async Task<bool> agregaAutor(mAutor pAutor)
        {
            mAutor lObjResultado = new mAutor();
            bool lObjRespuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var contenido = new StringContent(JsonConvert.SerializeObject(pAutor), Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PostAsync("Autor/insAutor/", contenido);
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mAutor>(respuesta);
                    if (lObjResultado.TnIdAutor != null)
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

        public async Task<bool> modificaAutor(mAutor pAutor)
        {
            mAutor lObjResultado = new mAutor();
            bool lObjRespuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var contenido = new StringContent(JsonConvert.SerializeObject(pAutor), Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PostAsync("Autor/modAutor/", contenido);
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mAutor>(respuesta);
                    if (lObjResultado.TnIdAutor != null)
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

        public async Task<bool> eliminaAutor(int pIdAutor)
        {
            mAutor lObjResultado = new mAutor();
            bool lObjRespuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.DeleteAsync($"Autor/delAutor/{pIdAutor}");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mAutor>(respuesta);
                    if (lObjResultado.TnIdAutor != null)
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
