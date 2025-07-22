using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaFarmacia.DAL.Repositorios.Contrato;
using SistemaFarmacia.DAL.Repositorios;
using SistemaFarmacia.Utility;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.BLL.Servicios;
using SistemaFarmacia.DAL.DBContext;

namespace SistemaFarmacia.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbfarmaciaContext>(Options =>
            {
                Options.UseSqlServer(configuration.GetConnectionString("cadenaSQL"));
            });
            
          //  services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
           // services.AddScoped<IVentaRepository, VentaRepository>();
            
            services.AddAutoMapper(typeof(AutoMapperProfile));
            
            
            services.AddScoped<IRolRepositorio, RolRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<IVentaRepositorio, VentaRepositorio>();
            services.AddScoped<IDashBoardRepositorio, DashBoardRepositorio>();
            services.AddScoped<IPresentacionRepositorio, PresentacionRepositorio>();
            services.AddScoped<IProdpresentacionRepositorio, ProdpresentacionRepositorio>();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IProveedorRepositorio, ProveedorRepositorio>();
            services.AddScoped<ICompraRepositorio, CompraRepositorio>();
            services.AddScoped<ICotizacionRepositorio, CotizacionRepositorio>();
            services.AddScoped<IFacturaElectronicaService, FacturaElectronicaService>();




        }
    }
}
