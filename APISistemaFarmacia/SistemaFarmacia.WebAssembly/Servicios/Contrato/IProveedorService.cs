using SistemaFarmacia.DTO;

namespace SistemaFarmacia.WebAssembly.Servicios.Contrato
{
    public interface IProveedorService
    {
        Task<ResponseDTO<List<ProveedorDTO>>> Lista();
        Task<ResponseDTO<ProveedorDTO>> Crear(ProveedorDTO entidad);
        Task<bool> Editar(ProveedorDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
