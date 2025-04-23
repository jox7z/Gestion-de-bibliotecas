using AccesoDatos.Entidades;

namespace AccesoDatos.Interfaces
{
    public interface iAutorAD 
    {
        List<TbiblioAutor> ObtenerAutores();

        public TbiblioAutor ObtenerAutoresXID(int pIdAutor);

        public bool insAutor(TbiblioAutor pAutor);

        public bool modAutor(TbiblioAutor pAutor);

        public bool delAutor(TbiblioAutor pAutor);
    }
}
