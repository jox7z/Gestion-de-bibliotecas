using System;
using System.Collections.Generic;

namespace AccesoDatos.EntidadesSeguridad;

public partial class TusrUsuario
{
    public string TcUsuario { get; set; } = null!;

    public string TcContrasena { get; set; } = null!;

    public virtual ICollection<TusrPerfile> TnPerfils { get; set; } = new List<TusrPerfile>();
}
