using SistemaFarmacia.DTO;

namespace SistemaFarmacia.WebAssembly.Servicios.Contrato
{
    public interface ICotizacionService
    {
        Task<ResponseDTO<CotizacionDTO>> Registrar(CotizacionDTO entidad);
        Task<ResponseDTO<List<CotizacionDTO>>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);
        Task<ResponseDTO<List<ReporteCotizacionDTO>>> Reporte(string fechaInicio, string fechaFin);
        Task<CotizacionDTO> ObtenerPorId(int id);
    }
}
