using SistemaFarmacia.DTO;
using SistemaFarmacia.WebAssembly.Utilidades;

namespace SistemaFarmacia.WebAssembly.Servicios.Contrato
{
    public interface IClienteService
    {
        Task<ResponseDTO<List<ClienteDTO>>> Lista();
        Task<ResponseDTO<ClienteDTO>> Crear(ClienteDTO entidad);
        Task<bool> Editar(ClienteDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
