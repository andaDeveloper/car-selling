using System;
using System.Collections.Generic;

namespace sql_oriented_app.Models;

public partial class Sucursal
{
    public int Idsucursal { get; set; }

    public string? NombreSucursal { get; set; }

    public virtual ICollection<Vendedor> Vendedors { get; set; } = new List<Vendedor>();
}
