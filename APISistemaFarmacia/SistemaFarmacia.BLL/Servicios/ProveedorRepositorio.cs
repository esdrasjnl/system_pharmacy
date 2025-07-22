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
    public class ProveedorRepositorio : IProveedorRepositorio
    {
        private readonly DbfarmaciaContext _dbContext;

        public ProveedorRepositorio(DbfarmaciaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Proveedor>> Consultar(Expression<Func<Proveedor, bool>> filtro = null)
        {
            IQueryable<Proveedor> queryEntidad = filtro == null ? _dbContext.Proveedors : _dbContext.Proveedors.Where(filtro);
            return queryEntidad;
        }

        public async Task<Proveedor> Crear(Proveedor entidad)
        {
            try
            {
                _dbContext.Set<Proveedor>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Proveedor entidad)
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

        public async Task<bool> Eliminar(Proveedor entidad)
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

        public async Task<List<Proveedor>> Lista()
        {
            try
            {
                return await _dbContext.Proveedors.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Proveedor> Obtener(Expression<Func<Proveedor, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Proveedors.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
