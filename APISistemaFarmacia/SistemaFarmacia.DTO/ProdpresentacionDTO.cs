using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.DTO
{
    public class ProdpresentacionDTO
    {
        public int IdProdpresentacion { get; set; }

        public int? IdProducto { get; set; }

        public int? IdPresentacion { get; set; }

        public string? DescripcionPresentacion { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public int? Cantidad { get; set; }

        public override string ToString()
        {
            return DescripcionPresentacion ?? base.ToString(); // Si DescripcionPresentacion es nula, se usa el valor predeterminado
        }
    }
}
