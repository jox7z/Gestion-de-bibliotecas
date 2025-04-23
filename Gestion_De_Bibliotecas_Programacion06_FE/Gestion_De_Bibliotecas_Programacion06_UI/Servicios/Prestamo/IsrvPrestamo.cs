using Gestion_De_Bibliotecas_Programacion06_UI.Models;

namespace Gestion_De_Bibliotecas_Programacion06_UI.Servicios.Prestamo
{
    public interface IsrvPrestamo
    {
        Task<string> Autenticar(Usuario pLogin);
        Task<List<mPrestamo>> obtenerPrestamo();
        Task<mPrestamo> obtenerPrestamoXId(int pIdPrestamo);
        Task<bool> agregaPrestamo(mPrestamo pPrestamo);
        Task<bool> modificaPrestamo(mPrestamo pPrestamo);
        Task<bool> eliminaPrestamo(int pIdPrestamo);
    }
}
