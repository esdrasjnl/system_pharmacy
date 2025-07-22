using SistemaFarmacia.DTO;
using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios.Contrato
{
    public interface IVentaRepositorio
    {
        Task<Venta> Registrar(Venta entidad);
        Task<List<Venta>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);
        Task<List<DetalleVenta>> Reporte(string FechaInicio, string FechaFin);
        Task<Venta> ObtenerPorId(int id);
        Task<VentaDTO> Obtener(int ventaId);


    }
}
