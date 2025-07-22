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
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Lista();
        Task<Categoria> Obtener(Expression<Func<Categoria, bool>> filtro = null);
        Task<Categoria> Crear(Categoria entidad);
        Task<bool> Editar(Categoria entidad);
        Task<bool> Eliminar(Categoria entidad);
        Task<IQueryable<Categoria>> Consultar(Expression<Func<Categoria, bool>> filtro = null);
        Task<Categoria> ObtenerPorId(int id);
    }
}
