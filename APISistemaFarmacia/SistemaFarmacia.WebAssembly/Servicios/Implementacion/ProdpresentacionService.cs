using SistemaFarmacia.DTO;
using SistemaFarmacia.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace SistemaFarmacia.WebAssembly.Servicios.Implementacion
{
    public class ProdpresentacionService : IProdpresentacionService
    {
        private readonly HttpClient _http;

        public ProdpresentacionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseDTO<ProdpresentacionDTO>> Crear(ProdpresentacionDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/prodpresentacion/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<ProdpresentacionDTO>>();


            return response;

        }

        public async Task<bool> Editar(ProdpresentacionDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/prodpresentacion/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<bool>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/prodpresentacion/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }





        public async Task<ResponseDTO<List<ProdpresentacionDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ProdpresentacionDTO>>>("api/prodpresentacion/Lista");
            return result!;
        }
    }
}
