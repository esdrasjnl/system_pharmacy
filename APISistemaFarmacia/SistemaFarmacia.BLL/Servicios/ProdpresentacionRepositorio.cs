using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DAL.DBContext;
using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios
{
    public class ProdpresentacionRepositorio : IProdpresentacionRepositorio
    {
        private readonly DbfarmaciaContext _dbContext;

        public ProdpresentacionRepositorio(DbfarmaciaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Prodpresentacion>> Consultar(Expression<Func<Prodpresentacion, bool>> filtro = null)
        {
            IQueryable<Prodpresentacion> queryEntidad = filtro == null ? _dbContext.Prodpresentacions : _dbContext.Prodpresentacions.Where(filtro);
            return queryEntidad;
        }

        public async Task<Prodpresentacion> Crear(Prodpresentacion entidad)
        {
            try
            {
                _dbContext.Set<Prodpresentacion>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Prodpresentacion entidad)
        {
            try
            {
                _dbContext.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Prodpresentacion entidad)
        {
            try
            {
                _dbContext.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Prodpresentacion> Obtener(Expression<Func<Prodpresentacion, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Prodpresentacions.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
