using Gestion_De_Bibliotecas_Programacion06_UI.Models;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Libro
{
    public interface IsrvLibro
    {
        Task<string> Autenticar(Usuario pLogin);
        Task<List<mLibro>> obtenerLibro();
        Task<mLibro> obtenerLibroXId(int pIdLibro);
        Task<bool> agregaLibro(mLibro pLibro);
        Task<bool> modificaLibro(mLibro pLibro);
        Task<bool> eliminaLibro(int pIdLibro);
    }
}
