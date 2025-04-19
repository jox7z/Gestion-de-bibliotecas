using System;
using System.Collections.Generic;

namespace AccesoDatos.Entidades;

public partial class TbiblioLibro
{
    public int TnIdLibro { get; set; }

    public int? TnIdAutor { get; set; }

    public string TcTitulo { get; set; } = null!;

    public string TcEditorial { get; set; } = null!;

    public string TcCategoria { get; set; } = null!;

    public virtual ICollection<TbiblioPrestamo> TbiblioPrestamos { get; set; } = new List<TbiblioPrestamo>();

    public virtual TbiblioAutor? TnIdAutorNavigation { get; set; }
}
