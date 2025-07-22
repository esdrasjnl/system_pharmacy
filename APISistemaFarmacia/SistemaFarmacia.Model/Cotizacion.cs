using System;
using System.Collections.Generic;

namespace SistemaFarmacia.Model;

public partial class Cotizacion
{
    public int IdCotizacion { get; set; }

    public int? IdCliente { get; set; }

    public string? NumeroDocumentoCotizacion { get; set; }

    public string? TipoPago { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleCotizacion> DetalleCotizacions { get; set; } = new List<DetalleCotizacion>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
