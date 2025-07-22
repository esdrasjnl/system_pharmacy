using SistemaFarmacia.DTO;
using SistemaFarmacia.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace SistemaFarmacia.WebAssembly.Servicios.Implementacion
{
    public class CompraService : ICompraService
    {
        private readonly HttpClient _http;

        public CompraService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseDTO<List<CompraDTO>>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<CompraDTO>>>($"api/compra/Historial?buscarPor={buscarPor}&numeroVenta={numeroVenta}&fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            return result!;
        }

        public async Task<CompraDTO> ObtenerPorId(int id)
        {
            var result = await _http.GetFromJsonAsync<CompraDTO>($"api/compra/ObtenerPorId?id={id}");
            return result!;
        }

        public async Task<ResponseDTO<CompraDTO>> Registrar(CompraDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/compra/Registrar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<CompraDTO>>();
            return response!;
        }

        

        public async Task<ResponseDTO<List<ReporteCompraDTO>>> Reporte(string fechaInicio, string fechaFin)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ReporteCompraDTO>>>($"api/compra/Reporte?fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            return result!;
        }
    }
}
