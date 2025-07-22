using SistemaFarmacia.DTO;

namespace SistemaFarmacia.WebAssembly.Servicios.Contrato
{
    public interface IProdpresentacionService
    {
        Task<ResponseDTO<List<ProdpresentacionDTO>>> Lista();
        Task<ResponseDTO<ProdpresentacionDTO>> Crear(ProdpresentacionDTO entidad);
        Task<bool> Editar(ProdpresentacionDTO entidad);
        Task<bool> Eliminar(int id);

    }
}
