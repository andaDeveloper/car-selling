using System;
using System.Collections.Generic;

namespace sql_oriented_app.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string? Nombre { get; set; }

    public string? Password { get; set; }

    public string? Cargo { get; set; }

    public virtual ICollection<Vendedore> Vendedores { get; set; } = new List<Vendedore>();
}
