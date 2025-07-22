using SistemaFarmacia.DTO;
using SistemaFarmacia.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace SistemaFarmacia.WebAssembly.Servicios.Implementacion
{
    public class CotizacionService: ICotizacionService
    {
        private readonly HttpClient _http;
        public CotizacionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseDTO<List<CotizacionDTO>>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<CotizacionDTO>>>($"api/cotizacion/Historial?buscarPor={buscarPor}&numeroVenta={numeroVenta}&fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            return result!;
        }

        public async Task<CotizacionDTO> ObtenerPorId(int id)
        {
            // throw new NotImplementedException();
            // var result = await _http.GetFromJsonAsync<ResponseDTO<List<ReporteDTO>>>($"api/venta/Reporte?fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            //return result!;
            var result = await _http.GetFromJsonAsync<CotizacionDTO>($"api/cotizacion/ObtenerPorId?id={id}");
            return result!;
        }

        public async Task<ResponseDTO<CotizacionDTO>> Registrar(CotizacionDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/cotizacion/Registrar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<CotizacionDTO>>();
            return response!;
        }

        public async Task<ResponseDTO<List<ReporteCotizacionDTO>>> Reporte(string fechaInicio, string fechaFin)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ReporteCotizacionDTO>>>($"api/cotizacion/Reporte?fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            return result!;
        }
    }
}
