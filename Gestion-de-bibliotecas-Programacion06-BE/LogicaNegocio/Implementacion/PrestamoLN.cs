using System;
using System.Collections.Generic;
using AccesoDatos.DBContext;
using AccesoDatos.Entidades;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Implementacion
{
    public class PrestamoLN : iPrestamoLN
    {
        public static GBContext lObjGBCnn = new GBContext("");
        private readonly iPrestamoAD gObjPrestamoAD = new PrestamoAD(lObjGBCnn);

        public List<TbiblioPrestamo> ObtenerPrestamos()
        {
            List<TbiblioPrestamo> lObjRespuesta = new List<TbiblioPrestamo>();

            try
            {
                lObjRespuesta = gObjPrestamoAD.ObtenerPrestamos();
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
                lObjRespuesta = gObjPrestamoAD.ObtenerPrestamoXID(pIdPrestamo);
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
                lObjRespuesta = gObjPrestamoAD.InsPrestamo(pPrestamo);
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
                lObjRespuesta = gObjPrestamoAD.ModPrestamo(pPrestamo);
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
                lObjRespuesta = gObjPrestamoAD.DelPrestamo(pPrestamo);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }
    }
}
