using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios.Contrato
{
    public interface IProdpresentacionRepositorio
    {
        Task<Prodpresentacion> Obtener(Expression<Func<Prodpresentacion, bool>> filtro = null);
        Task<Prodpresentacion> Crear(Prodpresentacion entidad);
        Task<bool> Editar(Prodpresentacion entidad);
        Task<bool> Eliminar(Prodpresentacion entidad);
        Task<IQueryable<Prodpresentacion>> Consultar(Expression<Func<Prodpresentacion, bool>> filtro = null);
    }
}
