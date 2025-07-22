using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.DTO
{
    public class PresentacionDTO
    {
        public int IdPresentacion { get; set; }
        public string? Descripcion { get; set; }

        public override bool Equals(object o)
        {
            var other = o as PresentacionDTO;
            return other?.IdPresentacion == IdPresentacion;
        }
        public override int GetHashCode() => IdPresentacion.GetHashCode();
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
