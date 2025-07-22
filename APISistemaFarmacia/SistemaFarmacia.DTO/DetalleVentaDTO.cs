using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.DTO
{
    public class DetalleVentaDTO
    {
        public int IdProducto { get; set; }
        public string? DescripcionProducto { get; set; }
        public string? Codigo { get; set; }
        public string? Presenta { get; set; }
        public int? CantidadInventario { get; set; }
        public int? CantidadReporte { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
    }
}
