﻿using Microsoft.JSInterop;

namespace SistemaFarmacia.WebAssembly.Utilidades
{
    public static class Extensiones
    {
        public static async Task GenerarArchivo(this IJSRuntime js, string nombre, byte[] arrayBytes)
        {
            await js.InvokeAsync<object>("DescargarArchivo", nombre, Convert.ToBase64String(arrayBytes));
        }
    }
}
