using System;
using System.Collections.Generic;

namespace sql_oriented_app.Models;

public partial class Vendedor
{
    public int Idvendedor { get; set; }

    public string? NombreVendedor { get; set; }

    public int? Idusuario { get; set; }

    public int? Idsucursal { get; set; }

    public virtual Sucursal? IdsucursalNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
