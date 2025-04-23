using Gestion_De_Bibliotecas_Programacion06_UI.Models;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Autor
{
    public interface IsrvAutor
    {
        Task<string> Autenticar(Usuario pLogin);
        Task<List<mAutor>> obtenerAutor();
        Task<mAutor> obtenerAutorXId(int pIdAutor);
        Task<bool> agregaAutor(mAutor pAutor);
        Task<bool> modificaAutor(mAutor pAutor);
        Task<bool> eliminaAutor(int pIdAutor);
    }
}
