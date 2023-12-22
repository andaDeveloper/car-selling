using System;
using System.Collections.Generic;

namespace sql_oriented_app.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
