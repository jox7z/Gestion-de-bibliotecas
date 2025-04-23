using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DBContext;
using AccesoDatos.EntidadesSeguridad;
using AccesoDatos.Interfaces;
using Entidades.EntidadesSeguridad;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Implementacion
{
    public class SeguridadAD: iSeguridadAD
    {
        private SEGContext gObjCnnSeg;
        private readonly string gCnnBD;

        public SeguridadAD(SEGContext lObjCnnSeg, string lCnnBD)
        {
            gObjCnnSeg = lObjCnnSeg;
            gCnnBD = lCnnBD;
        }

        public TusrUsuario obtenerUsuario(string pLogin)
        {
            TusrUsuario lObjRespuesta = new TusrUsuario();
            try
            {
                lObjRespuesta = gObjCnnSeg.TusrUsuarios.ToList().Find(us => us.TcUsuario == pLogin);
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
                using (SEGContext lObjCnn = new SEGContext(gCnnBD))
                {
                    var lCmd = lObjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "PA_recPerfilesXUsuario";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@TC_Usuario", pLogin));
                    lCmd.Connection.Open();
                    var lDatos = lCmd.ExecuteReader();
                    while (lDatos.Read())
                    {
                        TusrPerfilesXUsuario lDatoUsuario = new TusrPerfilesXUsuario();
                        lDatoUsuario.TnPerfil = Convert.ToInt32(lDatos["TN_Perfil"].ToString());
                        lDatoUsuario.TcUsuario = lDatos["TC_Usuario"].ToString();
                        lObjRespuesta.Add(lDatoUsuario);
                    }
                    if (lCmd.Connection.State == System.Data.ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }
    }
}
