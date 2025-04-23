using System;
using System.Collections.Generic;

namespace AccesoDatos.Entidades;

public partial class TbiblioPrestamo
{
    public int TnIdPrestamo { get; set; }

    public int? TnIdLibro { get; set; }

    public int? TnIdCliente { get; set; }

    public DateTime TfFecPrestamo { get; set; }

    public DateTime TfFecDevolucion { get; set; }

    public virtual TbiblioCliente? TnIdClienteNavigation { get; set; }

    public virtual TbiblioLibro? TnIdLibroNavigation { get; set; }
}
