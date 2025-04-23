using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.DBContext;
using AccesoDatos.Entidades;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using LogicaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogicaNegocio.Implementacion
{
    public class AutorLN : iAutorLN
    {
        public static GBContext lObjGBCnn = new GBContext("");

        private  readonly iAutorAD gObjAutorAD = new AutorAD(lObjGBCnn);

        public List<TbiblioAutor> ObtenerAutores()
        {
            List<TbiblioAutor> lObjRespuesta = new List<TbiblioAutor>();

            try
            {
                lObjRespuesta = gObjAutorAD.ObtenerAutores();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public TbiblioAutor ObtenerAutoresXID(int pIdAutor)
        {
            TbiblioAutor lObjRespuesta = new TbiblioAutor();
            try
            {
                lObjRespuesta = gObjAutorAD.ObtenerAutoresXID(pIdAutor);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;

        }

        public bool insAutor(TbiblioAutor pAutor)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjAutorAD.insAutor(pAutor);

            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }


        public bool modAutor(TbiblioAutor pAutor)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjAutorAD.modAutor(pAutor);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool delAutor(TbiblioAutor pAutor)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjAutorAD.delAutor(pAutor);

            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

    }
}
