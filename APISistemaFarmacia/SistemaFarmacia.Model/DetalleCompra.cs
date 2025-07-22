using System;
using System.Collections.Generic;

namespace SistemaFarmacia.Model;

public partial class DetalleCompra
{
    public int IdDetalleCompra { get; set; }

    public int? IdCompra { get; set; }

    public int? IdProducto { get; set; }

    public int? CantidadInventario { get; set; }

    public int? CantidadReporte { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public virtual Compra? IdCompraNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
