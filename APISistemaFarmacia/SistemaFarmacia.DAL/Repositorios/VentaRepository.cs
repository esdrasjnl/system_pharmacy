using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaFarmacia.DAL.DBContext;
using SistemaFarmacia.DAL.Repositorios.Contrato;
using SistemaFarmacia.Model;
namespace SistemaFarmacia.DAL.Repositorios
{
    public class VentaRepository //: GenericRepository<Venta>, IVentaRepository
    {
        /*
        private readonly DbfarmaciaContext _dbContext;

        public VentaRepository(DbfarmaciaContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVenta dv in modelo.DetalleVenta)
                    {
                        Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto_encontrado.Stock = producto_encontrado.Stock - dv.CantidadInventario;
                        _dbContext.Productos.Update(producto_encontrado);

                    }
                    await _dbContext.SaveChangesAsync();

                    NumeroDocumento correlativo = _dbContext.NumeroDocumentos.First();

                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistro = DateTime.Now;

                    _dbContext.NumeroDocumentos.Update(correlativo);
                    await _dbContext.SaveChangesAsync();

                    int CantidadDigitos = 4;
                    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - CantidadDigitos, CantidadDigitos);

                    modelo.NumeroDocumento = numeroVenta;

                    await _dbContext.Venta.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();

                    ventaGenerada = modelo;

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
            return ventaGenerada;
        }*/
    }
}
