using System;
using System.Collections.Generic;

namespace SistemaFarmacia.Model;

public partial class Presentacion
{
    public int IdPresentacion { get; set; }

    public string? Descripcion { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Prodpresentacion> Prodpresentacions { get; set; } = new List<Prodpresentacion>();
}
