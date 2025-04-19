using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.Entidades;

namespace LogicaNegocio.Interfaces
{
    public interface iClienteLN
    {
        List<TbiblioCliente> ObtenerClientes();
        TbiblioCliente ObtenerClienteXID(int pIdCliente);
        bool InsCliente(TbiblioCliente pCliente);
        bool ModCliente(TbiblioCliente pCliente);
        bool DelCliente(TbiblioCliente pCliente);
    }
}
