using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.EntidadesSeguridad;
using Entidades.EntidadesSeguridad;

namespace LogicaNegocio.Interfaces
{
    public interface iSeguridadLN
    {
        TusrUsuario obtenerUsuario(string pLogin);
        List<TusrPerfilesXUsuario> obtenerPerfilesXUsuario(string pLogin);
    }
}
