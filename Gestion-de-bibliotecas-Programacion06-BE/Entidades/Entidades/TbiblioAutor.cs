using System;
using System.Collections.Generic;

namespace AccesoDatos.Entidades;

public partial class TbiblioAutor
{
    public int TnIdAutor { get; set; }

    public string TcNombre { get; set; } = null!;

    public string TcNacionalidad { get; set; } = null!;

    public virtual ICollection<TbiblioLibro> TbiblioLibros { get; set; } = new List<TbiblioLibro>();
}
