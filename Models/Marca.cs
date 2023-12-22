using System;
using System.Collections.Generic;

namespace sql_oriented_app.Models;

public partial class Marca
{
    public int Idmarca { get; set; }

    public string? NombreMarca { get; set; }

    public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
}
