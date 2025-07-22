using SistemaFarmacia.DTO;

namespace SistemaFarmacia.WebAssembly.Servicios.Contrato
{
    public interface ICompraService
    {
        Task<ResponseDTO<CompraDTO>> Registrar(CompraDTO entidad);
        Task<ResponseDTO<List<CompraDTO>>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);
        Task<ResponseDTO<List<ReporteCompraDTO>>> Reporte(string fechaInicio, string fechaFin);
        Task<CompraDTO> ObtenerPorId(int id);
    }
}
