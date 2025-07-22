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
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly DbfarmaciaContext _dbContext;

        public CategoriaRepositorio(DbfarmaciaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Categoria>> Consultar(Expression<Func<Categoria, bool>> filtro = null)
        {
            IQueryable<Categoria> queryEntidad = filtro == null ? _dbContext.Categoria : _dbContext.Categoria.Where(filtro);
            return queryEntidad;
        }

        public async Task<Categoria> Crear(Categoria entidad)
        {
            try
            {
                _dbContext.Set<Categoria>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Categoria entidad)
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

        public async Task<bool> Eliminar(Categoria entidad)
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

        public async Task<List<Categoria>> Lista()
        {
            try
            {
                return await _dbContext.Categoria.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Categoria> Obtener(Expression<Func<Categoria, bool>> filtro = null)
        {
            try
            {
                return await _dbContext.Categoria.Where(filtro).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }








        public async Task<Categoria> ObtenerPorId(int id)
        {
            return await _dbContext.Categoria.FirstOrDefaultAsync(c => c.IdCategoria == id);
        }


    }
}
