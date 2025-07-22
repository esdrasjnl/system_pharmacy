using SistemaFarmacia.DTO;
using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios.Contrato
{
    public interface IUsuarioRepositorio
    {
        Task<List<Usuario>> Lista();
        Task<Usuario> Obtener(Expression<Func<Usuario, bool>> filtro = null);
        Task<Usuario> Crear(Usuario entidad);
        Task<bool> Editar(Usuario entidad);
        Task<bool> Eliminar(Usuario entidad);
        Task<IQueryable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null);
        Task<Usuario> ObtenerPorId(int id);
    }
}
