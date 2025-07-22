using SistemaFarmacia.DTO;

namespace SistemaFarmacia.WebAssembly.Servicios.Contrato
{
    public interface IProductoService
    {
        Task<ResponseDTO<List<ProductoDTO>>> Lista();

        Task<ResponseDTO<List<ProductoDTO>>> ListaVenta();
        Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO entidad);
        Task<bool> Editar(ProductoDTO entidad);
        Task<bool> Eliminar(int id);

      
        
    }
}
