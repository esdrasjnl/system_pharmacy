using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.DTO
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "El nit es obligatorio.")]
        public string? Nit { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El Tipo Cliente es obligatorio.")]
        public string? TipoCliente { get; set; }

        public string? Observaciones { get; set; }
    }
}
