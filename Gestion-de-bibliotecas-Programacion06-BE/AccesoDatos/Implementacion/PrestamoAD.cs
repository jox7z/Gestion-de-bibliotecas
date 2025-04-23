using AccesoDatos.DBContext;
using AccesoDatos.Entidades;
using AccesoDatos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class PrestamoAD : iPrestamoAD
    {
        private GBContext gObjCnnGB;

        public PrestamoAD(GBContext lObjCnnGB)
        {
            gObjCnnGB = lObjCnnGB;
        }

        public List<TbiblioPrestamo> ObtenerPrestamos()
        {
            List<TbiblioPrestamo> lObjRespuesta = new List<TbiblioPrestamo>();

            try
            {
                lObjRespuesta = gObjCnnGB.TbiblioPrestamos
                    .Include(p => p.TnIdClienteNavigation)
                    .Include(p => p.TnIdLibroNavigation)
                    .ToList();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public TbiblioPrestamo ObtenerPrestamoXID(int pIdPrestamo)
        {
            TbiblioPrestamo lObjRespuesta = new TbiblioPrestamo();

            try
            {
                lObjRespuesta = gObjCnnGB.TbiblioPrestamos
                    .Include(p => p.TnIdClienteNavigation)
                    .Include(p => p.TnIdLibroNavigation)
                    .ToList()
                    .Find(p => p.TnIdPrestamo == pIdPrestamo);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool InsPrestamo(TbiblioPrestamo pPrestamo)
        {
            bool lObjRespuesta = false;

            try
            {
                var lRegExiste = gObjCnnGB.TbiblioPrestamos.Find(pPrestamo.TnIdPrestamo);

                if (lRegExiste == null)
                {
                    gObjCnnGB.TbiblioPrestamos.Add(pPrestamo);
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

        public bool ModPrestamo(TbiblioPrestamo pPrestamo)
        {
            bool lObjRespuesta = false;

            try
            {
                var lRegExiste = gObjCnnGB.TbiblioPrestamos.Find(pPrestamo.TnIdPrestamo);

                if (lRegExiste != null)
                {
                    gObjCnnGB.Entry(lRegExiste).CurrentValues.SetValues(pPrestamo);
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

        public bool DelPrestamo(TbiblioPrestamo pPrestamo)
        {
            bool lObjRespuesta = false;

            try
            {
                var lRegExiste = gObjCnnGB.TbiblioPrestamos.Find(pPrestamo.TnIdPrestamo);

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