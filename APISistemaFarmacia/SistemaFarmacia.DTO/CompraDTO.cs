using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.DTO
{
    public class CompraDTO
    {
        public int IdCompra { get; set; }

        public int? IdProveedor { get; set; }

        public string? NombreProveedor { get; set; }

        public string? NumeroDocumentoCompra { get; set; }

        public string? TipoPago { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public decimal? Total { get; set; }

        public string? TotalTexto
        {

            get
            {
                decimal? sum = 0;
                if (detalleCompra != null && detalleCompra.Count > 0)
                    sum = detalleCompra.Sum(p => p.Total);

                return sum.ToString();
            }
        }

        public virtual List<DetalleCompraDTO>? detalleCompra { get; set; }

        public virtual ProveedorDTO? IdProveedorNavigation { get; set; }
    }
}
