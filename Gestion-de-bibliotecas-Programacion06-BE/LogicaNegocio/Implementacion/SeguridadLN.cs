using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DBContext;
using AccesoDatos.EntidadesSeguridad;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using Entidades.EntidadesSeguridad;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Implementacion
{
    public class SeguridadLN: iSeguridadLN
    {
        private readonly iSeguridadAD gObjSegAD;
        public static SEGContext lObjSegCnn = new SEGContext("");

        public SeguridadLN(string lCnnBD)
        {
            gObjSegAD = new SeguridadAD(lObjSegCnn, lCnnBD);
        }

        public TusrUsuario obtenerUsuario(string pLogin)
        {
            TusrUsuario lObjRespuesta = new TusrUsuario();
            try
            {
                lObjRespuesta = gObjSegAD.obtenerUsuario(pLogin);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public List<TusrPerfilesXUsuario> obtenerPerfilesXUsuario(string pLogin)
        {
            List<TusrPerfilesXUsuario> lObjRespuesta = new List<TusrPerfilesXUsuario>();
            try
            {
                lObjRespuesta = gObjSegAD.obtenerPerfilesXUsuario(pLogin);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }
    }
}
