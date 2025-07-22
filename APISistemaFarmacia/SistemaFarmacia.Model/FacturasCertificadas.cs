using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.Model
{
    public partial class FacturasCertificadas
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public string NombreArchivo { get; set; } = null!;
        public string RutaArchivo { get; set; } = null!;
        public DateTime FechaGeneracion { get; set; }
    }
}
