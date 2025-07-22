
using SistemaFarmacia.DTO;

namespace SistemaFarmacia.WebAssembly.Servicios.Contrato
{
    public interface ICategoriaService
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista();
        Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO entidad);
        Task<bool> Editar(CategoriaDTO entidad);
        Task<bool> Eliminar(int id);
        
    }
}