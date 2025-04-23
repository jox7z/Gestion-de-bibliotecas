using System;
using System.Collections.Generic;
using AccesoDatos.DBContext;
using AccesoDatos.Entidades;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Implementacion
{
    public class LibroLN : iLibroLN
    {
        public static GBContext lObjGBCnn = new GBContext("");
        private readonly iLibroAD gObjLibroAD = new LibroAD(lObjGBCnn);

        public List<TbiblioLibro> ObtenerLibros()
        {
            List<TbiblioLibro> lObjRespuesta = new List<TbiblioLibro>();

            try
            {
                lObjRespuesta = gObjLibroAD.ObtenerLibros();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public TbiblioLibro ObtenerLibroXID(int pIdLibro)
        {
            TbiblioLibro lObjRespuesta = new TbiblioLibro();

            try
            {
                lObjRespuesta = gObjLibroAD.ObtenerLibroXID(pIdLibro);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool InsLibro(TbiblioLibro pLibro)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjLibroAD.InsLibro(pLibro);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool ModLibro(TbiblioLibro pLibro)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjLibroAD.ModLibro(pLibro);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool DelLibro(TbiblioLibro pLibro)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjLibroAD.DelLibro(pLibro);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }
    }
}
