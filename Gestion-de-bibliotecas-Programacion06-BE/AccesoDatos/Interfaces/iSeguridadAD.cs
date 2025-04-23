using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.EntidadesSeguridad;
using Entidades.EntidadesSeguridad;

namespace AccesoDatos.Interfaces
{
    public interface iSeguridadAD
    {
        List<TusrPerfilesXUsuario> obtenerPerfilesXUsuario(string pLogin);
        TusrUsuario obtenerUsuario(string pLogin);
    }
}
