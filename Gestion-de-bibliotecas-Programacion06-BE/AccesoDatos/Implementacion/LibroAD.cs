using AccesoDatos.DBContext;
using AccesoDatos.Entidades;
using AccesoDatos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class LibroAD : iLibroAD
    {
        private GBContext gObjCnnGB;

        public LibroAD(GBContext lObjCnnGB)
        {
            gObjCnnGB = lObjCnnGB;
        }

        public List<TbiblioLibro> ObtenerLibros()
        {
            List<TbiblioLibro> lObjRespuesta = new List<TbiblioLibro>();

            try
            {
                lObjRespuesta = gObjCnnGB.TbiblioLibros.ToList();
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
                lObjRespuesta = gObjCnnGB.TbiblioLibros .ToList().Find(l => l.TnIdLibro == pIdLibro);
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
                var lRegExiste = gObjCnnGB.TbiblioLibros.Find(pLibro.TnIdLibro);

                if (lRegExiste == null)
                {
                    gObjCnnGB.TbiblioLibros.Add(pLibro);
                    gObjCnnGB.SaveChanges();
                    lObjRespuesta = true;
                }
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
                var lRegExiste = gObjCnnGB.TbiblioLibros.Find(pLibro.TnIdLibro);

                if (lRegExiste != null)
                {
                    gObjCnnGB.Entry(lRegExiste).CurrentValues.SetValues(pLibro);
                    gObjCnnGB.Entry(lRegExiste).State = EntityState.Modified;
                    gObjCnnGB.SaveChanges();
                    lObjRespuesta = true;
                }
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
                var lRegExiste = gObjCnnGB.TbiblioLibros.Find(pLibro.TnIdLibro);

                if (lRegExiste != null)
                {
                    gObjCnnGB.Entry(lRegExiste).State = EntityState.Deleted;
                    gObjCnnGB.SaveChanges();
                    lObjRespuesta = true;
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