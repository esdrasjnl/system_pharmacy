using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios.Contrato
{
    public interface IClienteRepositorio
    {
        Task<List<Cliente>> Lista();
        Task<Cliente> Obtener(Expression<Func<Cliente, bool>> filtro = null);
        Task<Cliente> Crear(Cliente entidad);
        Task<bool> Editar(Cliente entidad);
        Task<bool> Eliminar(Cliente entidad);
        Task<IQueryable<Cliente>> Consultar(Expression<Func<Cliente, bool>> filtro = null);
    }
}
