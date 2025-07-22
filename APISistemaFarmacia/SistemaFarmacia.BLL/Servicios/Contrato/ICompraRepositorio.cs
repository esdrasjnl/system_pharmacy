using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios.Contrato
{
    public  interface ICompraRepositorio
    {
        Task<Compra> Registrar(Compra entidad);
        Task<List<Compra>> Historial(string buscarPor, string numeroCompra, string fechaInicio, string fechaFin);
        Task<List<DetalleCompra>> Reporte(string FechaInicio, string FechaFin);
        Task<Compra> ObtenerPorId(int id);
    }
}
