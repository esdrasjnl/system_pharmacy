using System;
using System.Collections.Generic;

namespace SistemaFarmacia.Model;

public partial class DetalleCotizacion
{
    public int IdDetalleCotizacion { get; set; }

    public int? IdCotizacion { get; set; }

    public int? IdProducto { get; set; }

    public int? CantidadInventario { get; set; }

    public int? CantidadReporte { get; set; }

    public decimal? Precio { get; set; }

    public decimal? Total { get; set; }

    public virtual Cotizacion? IdCotizacionNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
