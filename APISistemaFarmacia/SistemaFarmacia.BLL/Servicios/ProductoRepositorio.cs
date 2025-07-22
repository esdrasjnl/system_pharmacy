using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DAL.DBContext;
using SistemaFarmacia.DAL.Repositorios.Contrato;
using SistemaFarmacia.DTO;
using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly DbfarmaciaContext _dbContext;

        public ProductoRepositorio(DbfarmaciaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IQueryable<Producto>> Consultar(Expression<Func<Producto, bool>> filtro = null)
        {
            /*
            IQueryable<Producto> queryEntidad = _dbContext.Productos.Where(p => p.EsActivo == true); // Filtra por productos activos

            
            if (filtro != null)
            {
                queryEntidad = queryEntidad.Where(filtro);
            }

            return queryEntidad;
            */
             IQueryable<Producto> queryEntidad = filtro == null ? _dbContext.Productos : _dbContext.Productos.Where(filtro);
            return queryEntidad;
        }
        public async Task<IQueryable<Producto>> ConsultarVenta(Expression<Func<Producto, bool>> filtro = null)
        {
            
            IQueryable<Producto> queryEntidad = _dbContext.Productos.Where(p => p.EsActivo == true); // Filtra por productos activos

            
            if (filtro != null)
            {
                queryEntidad = queryEntidad.Where(filtro);
            }

            return queryEntidad;
            
            
        }

        public async Task<Producto> Crear(Producto entidad)
        {
            try
            {
                _dbContext.Set<Producto>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Producto entidad)
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

        public async Task<bool> Eliminar(Producto entidad)
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

        public async Task<Producto> Obtener(Expression<Func<Producto, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Productos.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Producto>> Lista()
        {
            try
            {
                return await _dbContext.Productos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
