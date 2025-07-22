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
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios
{
    public class RolRepositorio: IRolRepositorio
    {
        private readonly DbfarmaciaContext _dbContext;

        public RolRepositorio(DbfarmaciaContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Rol>> Lista()
        {
            try
            {
                return await _dbContext.Rols.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
