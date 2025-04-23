using AccesoDatos.DBContext;
using AccesoDatos.Entidades;
using AccesoDatos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Implementacion
{
    public class AutorAD : iAutorAD
    {
        private GBContext gObjCnnGB;

        public AutorAD(GBContext lObjCnnGB)
        {
            gObjCnnGB = lObjCnnGB;
        }

        public List<TbiblioAutor> ObtenerAutores()
        {
            List<TbiblioAutor> lObjRespuesta = new List<TbiblioAutor>();

            try
            {
                lObjRespuesta = gObjCnnGB.TbiblioAutors.ToList();
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
                lObjRespuesta = gObjCnnGB.TbiblioAutors.ToList().Find(a=>a.TnIdAutor == pIdAutor);
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
                var lRegExiste = gObjCnnGB.TbiblioAutors.Find(pAutor.TnIdAutor);
                
                if (lRegExiste == null )
                {
                    gObjCnnGB.TbiblioAutors.Add(pAutor);
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


        public bool modAutor(TbiblioAutor pAutor)
        {
            bool lObjRespuesta = false;

            try
            {
                var lRegExiste = gObjCnnGB.TbiblioAutors.Find(pAutor.TnIdAutor);

                if (lRegExiste != null)
                {
                    gObjCnnGB.Entry(lRegExiste).CurrentValues.SetValues(pAutor);
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

        public bool delAutor(TbiblioAutor pAutor)
        {
            bool lObjRespuesta = false;

            try
            {
                var lRegExiste = gObjCnnGB.TbiblioAutors.Find(pAutor.TnIdAutor);

                if (lRegExiste != null)
                {
                    gObjCnnGB.Entry(lRegExiste).CurrentValues.SetValues(pAutor);
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
