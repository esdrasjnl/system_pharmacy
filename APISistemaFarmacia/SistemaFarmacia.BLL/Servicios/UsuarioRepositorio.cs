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
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        private readonly DbfarmaciaContext _dbContext;

        public UsuarioRepositorio(DbfarmaciaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null)
        {
            IQueryable<Usuario> queryEntidad = filtro == null ? _dbContext.Usuarios : _dbContext.Usuarios.Where(filtro);
            return queryEntidad;
        }

        public async Task<Usuario> Crear(Usuario entidad)
        {
            try
            {
                _dbContext.Set<Usuario>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Usuario entidad)
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

        public async Task<bool> Eliminar(Usuario entidad)
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

        public async Task<List<Usuario>> Lista()
        {
            try
            {
                return await _dbContext.Usuarios.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> Obtener(Expression<Func<Usuario, bool>> filtro = null)
        {
            try
            {
                // return await _dbContext.Usuarios.Where(filtro).FirstOrDefaultAsync();
                return await _dbContext.Usuarios
            
            .Where(filtro)
            //.Include(u => u.IdRolNavigation) // 🔹 Cargar la relación Rol
            .FirstOrDefaultAsync();

            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> ObtenerPorId(int id)
        {
            //   return await _dbcontext.Venta.FirstOrDefaultAsync(c => c.IdVenta == id);
            return await _dbContext.Usuarios
          .Include(v => v.IdRolNavigation)
          //.ThenInclude(dv => dv.IdProductoNavigation) // Asegúrate de incluir los productos
         // .Include(v => v.IdClienteNavigation)
          .FirstOrDefaultAsync(c => c.IdUsuario == id);


            //return await _dbcontext.Venta.Include(v => v.DetalleVenta).ThenInclude(dv => dv.IdProductoNavigation).FirstOrDefaultAsync

        }
    }
}
