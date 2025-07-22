using System;
using System.Collections.Generic;

namespace SistemaFarmacia.Model;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public int? IdCategoria { get; set; }

    public int? Stock { get; set; }

    public string? Imagen { get; set; }

    public decimal? Pcosto { get; set; }

    public decimal? Ppublico { get; set; }

    public decimal? Ptendero { get; set; }

    public decimal? Prutero { get; set; }

    public decimal? Pmayorista { get; set; }

    public decimal? Pespecial { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleCotizacion> DetalleCotizacions { get; set; } = new List<DetalleCotizacion>();

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
