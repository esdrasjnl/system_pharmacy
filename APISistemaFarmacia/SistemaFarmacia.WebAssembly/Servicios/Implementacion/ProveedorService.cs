using SistemaFarmacia.DTO;
using SistemaFarmacia.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace SistemaFarmacia.WebAssembly.Servicios.Implementacion
{
    public class ProveedorService : IProveedorService
    {
        private readonly HttpClient _http;

        public ProveedorService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseDTO<ProveedorDTO>> Crear(ProveedorDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/proveedor/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<ProveedorDTO>>();
            return response!;
        }

        public async Task<bool> Editar(ProveedorDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/proveedor/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<ProveedorDTO>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/proveedor/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }

        public async Task<ResponseDTO<List<ProveedorDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ProveedorDTO>>>("api/proveedor/Lista");
            return result!;
        }
    }
}
