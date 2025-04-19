using AccesoDatos.DBContext;
using AccesoDatos.Entidades;
using AccesoDatos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoDatos.Implementacion
{
    public class ClienteAD : iClienteAD
    {
        private GBContext gObjCnnGB;

        public ClienteAD(GBContext lObjCnnGB)
        {
            gObjCnnGB = lObjCnnGB;
        }

        public List<TbiblioCliente> ObtenerClientes()
        {
            List<TbiblioCliente> lObjRespuesta = new List<TbiblioCliente>();

            try
            {
                lObjRespuesta = gObjCnnGB.TbiblioClientes.ToList();
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
                lObjRespuesta = gObjCnnGB.TbiblioClientes.ToList().Find(c => c.TnIdCliente == pIdCliente);
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
                var lRegExiste = gObjCnnGB.TbiblioClientes.Find(pCliente.TnIdCliente);

                if (lRegExiste == null)
                {
                    gObjCnnGB.TbiblioClientes.Add(pCliente);
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

        public bool ModCliente(TbiblioCliente pCliente)
        {
            bool lObjRespuesta = false;

            try
            {
                var lRegExiste = gObjCnnGB.TbiblioClientes.Find(pCliente.TnIdCliente);

                if (lRegExiste != null)
                {
                    gObjCnnGB.Entry(lRegExiste).CurrentValues.SetValues(pCliente);
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

        public bool DelCliente(TbiblioCliente pCliente)
        {
            bool lObjRespuesta = false;

            try
            {
                var lRegExiste = gObjCnnGB.TbiblioClientes.Find(pCliente.TnIdCliente);

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
