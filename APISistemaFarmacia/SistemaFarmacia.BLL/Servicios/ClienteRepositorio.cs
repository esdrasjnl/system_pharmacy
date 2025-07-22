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
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly DbfarmaciaContext _dbContext;

        public ClienteRepositorio(DbfarmaciaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Cliente>> Consultar(Expression<Func<Cliente, bool>> filtro = null)
        {
            IQueryable<Cliente> queryEntidad = filtro == null ? _dbContext.Clientes : _dbContext.Clientes.Where(filtro);
            return queryEntidad;
        }

        public async Task<Cliente> Crear(Cliente entidad)
        {
            try
            {
                _dbContext.Set<Cliente>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Cliente entidad)
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

        public async Task<bool> Eliminar(Cliente entidad)
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

        public async Task<List<Cliente>> Lista()
        {
            try
            {
                return await _dbContext.Clientes.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Cliente> Obtener(Expression<Func<Cliente, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Clientes.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
