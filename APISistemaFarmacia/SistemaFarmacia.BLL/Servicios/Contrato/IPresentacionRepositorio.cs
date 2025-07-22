using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios.Contrato
{
    public interface IPresentacionRepositorio
    {
        Task<List<Presentacion>> Lista();
        Task<Presentacion> Obtener(Expression<Func<Presentacion, bool>> filtro = null);
        Task<Presentacion> Crear(Presentacion entidad);
        Task<bool> Editar(Presentacion entidad);
        Task<bool> Eliminar(Presentacion entidad);
        Task<IQueryable<Presentacion>> Consultar(Expression<Func<Presentacion, bool>> filtro = null);
    }
}
