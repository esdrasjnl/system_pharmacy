using System;
using System.Collections.Generic;

namespace SistemaFarmacia.Model;

public partial class DetalleVenta
{
    public int IdDetalleVenta { get; set; }

    public int? IdVenta { get; set; }

    public int? IdProducto { get; set; }

    public int? CantidadInventario { get; set; }

    public int? CantidadReporte { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Venta? IdVentaNavigation { get; set; }
}
