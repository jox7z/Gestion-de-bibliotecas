using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Entidades;

namespace LogicaNegocio.Interfaces
{
    public interface iAutorLN
    {
        List<TbiblioAutor> ObtenerAutores();
        TbiblioAutor ObtenerAutoresXID(int pIdAutor);
        bool insAutor(TbiblioAutor pAutor);
        bool modAutor(TbiblioAutor pAutor);
        bool delAutor(TbiblioAutor pAutor);

    }
}
