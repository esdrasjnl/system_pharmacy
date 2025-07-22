using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El campo {o} es requerido")]
        public string? Codigo { get; set; }

        [Required(ErrorMessage ="El campo {o} es requerido")]
        public string? Nombre { get; set; }
       
        public int? IdCategoria { get; set; }

        public string? DescripcionCategoria { get; set; }

        public int? Stock { get; set; }

        public string? Imagen { get; set; }

        public decimal? pcosto { get; set; }

        public decimal? Ppublico { get; set; }

        public decimal? Ptendero { get; set; }

        public decimal? Prutero { get; set; }

        public decimal? Pmayorista { get; set; }

        public decimal? Pespecial { get; set; }

        public bool? EsActivo { get; set; }
    }
}
