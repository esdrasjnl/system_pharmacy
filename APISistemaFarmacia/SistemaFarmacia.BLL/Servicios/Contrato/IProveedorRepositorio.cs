using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios.Contrato
{
    public interface IProveedorRepositorio
    {
        Task<List<Proveedor>> Lista();
        Task<Proveedor> Obtener(Expression<Func<Proveedor, bool>> filtro = null);
        Task<Proveedor> Crear(Proveedor entidad);
        Task<bool> Editar(Proveedor entidad);
        Task<bool> Eliminar(Proveedor entidad);
        Task<IQueryable<Proveedor>> Consultar(Expression<Func<Proveedor, bool>> filtro = null);
    }
}
