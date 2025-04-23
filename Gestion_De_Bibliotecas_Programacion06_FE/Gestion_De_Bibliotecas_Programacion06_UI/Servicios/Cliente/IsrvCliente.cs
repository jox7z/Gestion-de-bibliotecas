using Gestion_De_Bibliotecas_Programacion06_UI.Models;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Cliente
{
    public interface IsrvCliente
    {
        Task<string> Autenticar(Usuario pLogin);
        Task<List<mCliente>> obtenerCliente();
        Task<mCliente> obtenerClienteXId(int pIdCliente);
        Task<bool> agregaCliente(mCliente pCliente);
        Task<bool> modificaCliente(mCliente pCliente);
        Task<bool> eliminaCliente(int pIdCliente);
    }
}
