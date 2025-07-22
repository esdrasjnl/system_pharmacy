using SistemaFarmacia.DTO;

namespace SistemaFarmacia.WebAssembly.Servicios.Contrato
{
    public interface IPresentacionService
    {
        Task<ResponseDTO<List<PresentacionDTO>>> Lista();
        Task<ResponseDTO<PresentacionDTO>> Crear(PresentacionDTO entidad);
        Task<bool> Editar(PresentacionDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
