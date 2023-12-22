using System;
using System.Collections.Generic;

namespace sql_oriented_app.Models;

public partial class Modelo
{
    public int Idmodelo { get; set; }

    public int? Idmarca { get; set; }

    public string? NombreModelo { get; set; }

    public virtual Marca? IdmarcaNavigation { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
