using System;
using System.Collections.Generic;

namespace sql_oriented_app.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string? Nombre { get; set; }

    public string? Contra { get; set; }

    public int? Cargo { get; set; }

    public virtual ICollection<Vendedor> Vendedors { get; set; } = new List<Vendedor>();
}
