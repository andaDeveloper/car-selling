using System;
using System.Collections.Generic;

namespace sql_oriented_app.Models;

public partial class Venta
{
    public int Idventa { get; set; }

    public int? Idcliente { get; set; }

    public int? Idmodelo { get; set; }

    public int? Idvendedor { get; set; }

    public DateOnly? FechaVenta { get; set; }

    public double? Monto { get; set; }

    public virtual Cliente? IdclienteNavigation { get; set; }

    public virtual Modelo? IdmodeloNavigation { get; set; }

    public virtual Vendedore? IdvendedorNavigation { get; set; }
}
