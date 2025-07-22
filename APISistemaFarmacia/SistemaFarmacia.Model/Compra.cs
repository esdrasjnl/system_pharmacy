using System;
using System.Collections.Generic;

namespace SistemaFarmacia.Model;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int? IdProveedor { get; set; }

    public string? NumeroDocumentoCompra { get; set; }

    public string? TipoPago { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedor? IdProveedorNavigation { get; set; }
}
