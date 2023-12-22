using System;
using System.Collections.Generic;

namespace sql_oriented_app.Models;

public partial class Sucursale
{
    public int Idsucursal { get; set; }

    public string? NombreSucursal { get; set; }

    public virtual ICollection<Vendedore> Vendedores { get; set; } = new List<Vendedore>();
}
