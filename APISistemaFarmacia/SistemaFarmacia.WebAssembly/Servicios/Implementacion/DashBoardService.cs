﻿using SistemaFarmacia.DTO;
using SistemaFarmacia.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace SistemaFarmacia.WebAssembly.Servicios.Implementacion
{
    public class DashBoardService: IDashBoardService
    {
        private readonly HttpClient _http;

        public DashBoardService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseDTO<DashBoardDTO>> Resumen()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<DashBoardDTO>>("api/dashboard/Resumen");
            return result!;
        }
    }
}
