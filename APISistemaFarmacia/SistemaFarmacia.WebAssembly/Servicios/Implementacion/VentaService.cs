﻿using SistemaFarmacia.DTO;
using SistemaFarmacia.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace SistemaFarmacia.WebAssembly.Servicios.Implementacion
{
    public class VentaService : IVentaService
    {
        private readonly HttpClient _http;

        public VentaService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<List<VentaDTO>>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<VentaDTO>>>($"api/venta/Historial?buscarPor={buscarPor}&numeroVenta={numeroVenta}&fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            return result!;
        }

        public async Task<VentaDTO> ObtenerPorId(int id)
        {
           // throw new NotImplementedException();
            // var result = await _http.GetFromJsonAsync<ResponseDTO<List<ReporteDTO>>>($"api/venta/Reporte?fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            //return result!;
            var result = await _http.GetFromJsonAsync<VentaDTO>($"api/venta/ObtenerPorId?id={id}");
            return result!;
        }

        public async Task<ResponseDTO<VentaDTO>> Registrar(VentaDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/venta/Registrar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();
            return response!;
        }

        public async Task<ResponseDTO<List<ReporteDTO>>> Reporte(string fechaInicio, string fechaFin)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<ReporteDTO>>>($"api/venta/Reporte?fechaInicio={fechaInicio}&fechaFin={fechaFin}");
            return result!;
        }
    }
}
