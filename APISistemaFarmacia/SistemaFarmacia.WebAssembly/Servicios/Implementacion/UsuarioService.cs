﻿using SistemaFarmacia.DTO;
using SistemaFarmacia.WebAssembly.Servicios.Contrato;
using SistemaFarmacia.WebAssembly.Utilidades;
using System.Net.Http.Json;

namespace SistemaFarmacia.WebAssembly.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO entidad)
        {
            var result = await _http.PostAsJsonAsync("api/usuario/Guardar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
            return response!;
        }

        public async Task<bool> Editar(UsuarioDTO entidad)
        {
            var result = await _http.PutAsJsonAsync("api/usuario/Editar", entidad);
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();

            return response!.status;
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/usuario/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseDTO<string>>();
            return response!.status;
        }

        public async Task<ResponseDTO<UsuarioDTO>> IniciarSesion(string correo, string clave)
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"api/usuario/IniciarSesion?correo={correo}&clave={clave}");
            return result!;

            /*
            var result = await _http.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"api/usuario/IniciarSesion?correo={request.Correo}&clave={request.Password}");
            return result!;*/
        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>("api/usuario/Lista");
            return result!;
        }
    }
}
