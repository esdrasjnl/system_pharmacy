using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios.Contrato
{
    public interface IDashBoardRepositorio
    {
        Task<int> TotalVentasUltimaSemana();
        Task<string> TotalIngresosUltimaSemana();
        Task<int> TotalProductos();
        Task<Dictionary<string, int>> VentasUltimaSemana();
    }
}
