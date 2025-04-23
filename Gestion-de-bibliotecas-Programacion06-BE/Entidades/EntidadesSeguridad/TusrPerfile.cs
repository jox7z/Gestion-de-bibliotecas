using System;
using System.Collections.Generic;

namespace AccesoDatos.EntidadesSeguridad;

public partial class TusrPerfile
{
    public int TnPerfil { get; set; }

    public string TcNomPerfil { get; set; } = null!;

    public virtual ICollection<TusrUsuario> TcUsuarios { get; set; } = new List<TusrUsuario>();
}
