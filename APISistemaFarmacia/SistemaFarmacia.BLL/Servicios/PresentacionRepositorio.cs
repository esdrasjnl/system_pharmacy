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
    public class PresentacionRepositorio : IPresentacionRepositorio
    {
        private readonly DbfarmaciaContext _dbContext;

        public PresentacionRepositorio(DbfarmaciaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Presentacion>> Consultar(Expression<Func<Presentacion, bool>> filtro = null)
        {
            IQueryable<Presentacion> queryEntidad = filtro == null ? _dbContext.Presentacions : _dbContext.Presentacions.Where(filtro);
            return queryEntidad;
        }

        public async Task<Presentacion> Crear(Presentacion entidad)
        {
            try
            {
                _dbContext.Set<Presentacion>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Presentacion entidad)
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

        public async Task<bool> Eliminar(Presentacion entidad)
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

        public async Task<List<Presentacion>> Lista()
        {
            try
            {
                return await _dbContext.Presentacions.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Presentacion> Obtener(Expression<Func<Presentacion, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Presentacions.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
