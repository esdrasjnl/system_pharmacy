using SistemaFarmacia.DTO;

namespace SistemaFarmacia.WebAssembly.Servicios.Contrato
{
    public interface IDashBoardService
    {
        Task<ResponseDTO<DashBoardDTO>> Resumen();
    }
}
