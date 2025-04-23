using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Entidades;

namespace AccesoDatos.Interfaces
{
    public interface iPrestamoAD
    {
        List<TbiblioPrestamo> ObtenerPrestamos();
        TbiblioPrestamo ObtenerPrestamoXID(int pIdPrestamo);
        bool InsPrestamo(TbiblioPrestamo pPrestamo);
        bool ModPrestamo(TbiblioPrestamo pPrestamo);
        bool DelPrestamo(TbiblioPrestamo pPrestamo);

    }
}
