using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.DTO
{
    public class ProveedorDTO
    {
        public int IdProveedor { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El nit es obligatorio.")]
        public string? Nit { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Celular { get; set; }

        public string? Cuenta { get; set; }

    }
}
