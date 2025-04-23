using System.Text;
using Gestion_De_Bibliotecas_Programacion06_UI.Models;
using Newtonsoft.Json;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Cliente
{
    public class srvCliente : IsrvCliente
    {
        private static string gBaseUrl;
        private static string gToken;

        public srvCliente()
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

        public async Task<List<mCliente>> obtenerCliente()
        {
            List<mCliente> lObjRespuesta = new List<mCliente>();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.GetAsync("Cliente/obtenerClientes");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjRespuesta = JsonConvert.DeserializeObject<List<mCliente>>(respuesta);
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public async Task<mCliente> obtenerClienteXId(int pIdCliente)
        {
            mCliente lObjRespuesta = new mCliente();
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.GetAsync($"Cliente/obtenerClienteXID/{pIdCliente}");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjRespuesta = JsonConvert.DeserializeObject<mCliente>(respuesta);
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public async Task<bool> agregaCliente(mCliente pCliente)
        {
            mCliente lObjResultado = new mCliente();
            bool lObjRespuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var contenido = new StringContent(JsonConvert.SerializeObject(pCliente), Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PostAsync("Cliente/insCliente/", contenido);
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mCliente>(respuesta);
                    if (lObjResultado.TnIdCliente != null)
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

        public async Task<bool> modificaCliente(mCliente pCliente)
        {
            mCliente lObjResultado = new mCliente();
            bool lObjRespuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var contenido = new StringContent(JsonConvert.SerializeObject(pCliente), Encoding.UTF8, "application/json");
                var ejecucion = await cliente.PostAsync("Cliente/modCliente/", contenido);
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mCliente>(respuesta);
                    if (lObjResultado.TnIdCliente != null)
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

        public async Task<bool> eliminaCliente(int pIdCliente)
        {
            mCliente lObjResultado = new mCliente();
            bool lObjRespuesta = false;
            try
            {
                var cliente = new HttpClient();
                cliente.BaseAddress = new Uri(gBaseUrl);
                cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", gToken);
                var ejecucion = await cliente.DeleteAsync($"Cliente/delCliente/{pIdCliente}");
                if (ejecucion.IsSuccessStatusCode)
                {
                    var respuesta = await ejecucion.Content.ReadAsStringAsync();
                    lObjResultado = JsonConvert.DeserializeObject<mCliente>(respuesta);
                    if (lObjResultado.TnIdCliente != null)
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
