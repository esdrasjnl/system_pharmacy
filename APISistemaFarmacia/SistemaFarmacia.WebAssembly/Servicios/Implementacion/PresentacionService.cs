using SistemaFarmacia.DTO;
using SistemaFarmacia.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace SistemaFarmacia.WebAssembly.Servicios.Implementacion
{
    public class PresentacionService: IPresentacionService
    {
        private readonly HttpClient _http;

        public PresentacionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseDTO<PresentacionDTO>> Crear(PresentacionDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/presentacion/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<PresentacionDTO>>();

            return response;
        }

        public async Task<bool> Editar(PresentacionDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/presentacion/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/presentacion/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }

        public async Task<ResponseDTO<List<PresentacionDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<PresentacionDTO>>>("api/presentacion/Lista");
            return result;
        }
    }
}
