using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios.Contrato
{
    public interface ICotizacionRepositorio
    {
        Task<Cotizacion> Registrar(Cotizacion entidad);
        Task<List<Cotizacion>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);
        Task<List<DetalleCotizacion>> Reporte(string FechaInicio, string FechaFin);
        Task<Cotizacion> ObtenerPorId(int id);
    }
}
