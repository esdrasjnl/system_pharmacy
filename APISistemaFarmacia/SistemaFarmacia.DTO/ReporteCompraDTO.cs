using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.DTO
{
    public class ReporteCompraDTO
    {
        public string? NumeroDocumentoCompra { get; set; }
        public string? TipoPago { get; set; }
        public string? FechaRegistro { get; set; }
        public string? TotalCompra { get; set; }
        public string? Producto { get; set; }
        public string? Cantidad { get; set; }
        public string? Precio { get; set; }
        public string? Total { get; set; }
    }
}
