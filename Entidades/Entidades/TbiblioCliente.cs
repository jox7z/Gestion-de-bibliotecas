using System;
using System.Collections.Generic;

namespace AccesoDatos.Entidades;

public partial class TbiblioCliente
{
    public int TnIdCliente { get; set; }

    public string TcNombre { get; set; } = null!;

    public string TcAp1 { get; set; } = null!;

    public string? TcAp2 { get; set; }

    public string? TcNumTelefono { get; set; }

    public string? TcCorreoElectronico { get; set; }

    public virtual ICollection<TbiblioPrestamo> TbiblioPrestamos { get; set; } = new List<TbiblioPrestamo>();
}
