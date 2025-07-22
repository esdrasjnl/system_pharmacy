using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using SistemaFarmacia.DTO;

namespace SistemaFarmacia.BLL.Servicios.Contrato
{
    public interface IProductoRepositorio
    {
        Task<List<Producto>> Lista();
        Task<Producto> Obtener(Expression<Func<Producto, bool>> filtro = null);
        Task<Producto> Crear(Producto entidad);
        Task<bool> Editar(Producto entidad);
        Task<bool> Eliminar(Producto entidad);
        Task<IQueryable<Producto>> Consultar(Expression<Func<Producto, bool>> filtro = null);
        Task<IQueryable<Producto>> ConsultarVenta(Expression<Func<Producto, bool>> filtro = null);
    }
}
