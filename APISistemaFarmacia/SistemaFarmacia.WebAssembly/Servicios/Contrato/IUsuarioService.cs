using SistemaFarmacia.DTO;
using SistemaFarmacia.WebAssembly.Utilidades;

namespace SistemaFarmacia.WebAssembly.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<ResponseDTO<List<UsuarioDTO>>> Lista();
        Task<ResponseDTO<UsuarioDTO>> IniciarSesion(string correo, string clave);
        Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO entidad);
        Task<bool> Editar(UsuarioDTO entidad);
        Task<bool> Eliminar(int id);
    }
}
