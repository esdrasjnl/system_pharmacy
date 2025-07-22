using System;
using System.Collections.Generic;

namespace SistemaFarmacia.Model;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NombreCompleto { get; set; }

    public string? Nit { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? TipoCliente { get; set; }

    public string? Observaciones { get; set; }

    public bool? EsActivo { get; set; }

    public virtual ICollection<Cotizacion> Cotizacions { get; set; } = new List<Cotizacion>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
