using System;
using System.Collections.Generic;
using AccesoDatos.DBContext;
using AccesoDatos.Entidades;
using AccesoDatos.Implementacion;
using AccesoDatos.Interfaces;
using LogicaNegocio.Interfaces;

namespace LogicaNegocio.Implementacion
{
    public class ClienteLN : iClienteLN
    {
        public static GBContext lObjGBCnn = new GBContext();
        private readonly iClienteAD gObjClienteAD = new ClienteAD(lObjGBCnn);

        public List<TbiblioCliente> ObtenerClientes()
        {
            List<TbiblioCliente> lObjRespuesta = new List<TbiblioCliente>();

            try
            {
                lObjRespuesta = gObjClienteAD.ObtenerClientes();
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public TbiblioCliente ObtenerClienteXID(int pIdCliente)
        {
            TbiblioCliente lObjRespuesta = new TbiblioCliente();

            try
            {
                lObjRespuesta = gObjClienteAD.ObtenerClienteXID(pIdCliente);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool InsCliente(TbiblioCliente pCliente)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjClienteAD.InsCliente(pCliente);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool ModCliente(TbiblioCliente pCliente)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjClienteAD.ModCliente(pCliente);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }

        public bool DelCliente(TbiblioCliente pCliente)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjClienteAD.DelCliente(pCliente);
            }
            catch (Exception lEx)
            {
                throw lEx;
            }

            return lObjRespuesta;
        }
    }
}
