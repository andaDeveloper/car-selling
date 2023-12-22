using System;
using System.Collections.Generic;

namespace sql_oriented_app.Models;

public partial class Vendedore
{
    public int Idvendedor { get; set; }

    public string? NombreVendedor { get; set; }

    public int? Idusuario { get; set; }

    public int? Idsucursal { get; set; }

    public virtual Sucursale? IdsucursalNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
