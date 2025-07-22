using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.DTO
{
    public class CotizacionDTO
    {
        public int IdCotizacion { get; set; }
        public int? IdCliente { get; set; }
        public string? NombreCliente { get; set; }
        public string? NumeroDocumentoCotizacion { get; set; }
        public string? TipoPago { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public decimal? Total { get; set; }
        public string? TotalTexto
        {

            get
            {
                decimal? sum = 0;
                if (Detallecotizacion.Count > 0)
                    sum = Detallecotizacion.Sum(p => p.Total);

                return sum.ToString();
            }
        }
        public virtual List<DetalleCotizacionDTO>? Detallecotizacion { get; set; }

        public virtual ClienteDTO? IdClienteNavigation { get; set; }
    }
}
