using SistemaFarmacia.DTO;

namespace SistemaFarmacia.WebAssembly.Servicios.Contrato
{
    public interface IRolService
    {
        Task<ResponseDTO<List<RolDTO>>> Lista();
    }
}
