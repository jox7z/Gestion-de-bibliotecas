using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Entidades;

namespace LogicaNegocio.Interfaces
{
    public interface iLibroLN
    {
        List<TbiblioLibro> ObtenerLibros();
        TbiblioLibro ObtenerLibroXID(int pIdLibro);
        bool InsLibro(TbiblioLibro pLibro);
        bool ModLibro(TbiblioLibro pLibro);
        bool DelLibro(TbiblioLibro pLibro);
    }
}
