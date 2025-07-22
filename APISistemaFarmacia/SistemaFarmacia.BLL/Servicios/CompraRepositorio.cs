using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DAL.DBContext;
using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios
{
    public class CompraRepositorio : ICompraRepositorio
    {
        private readonly DbfarmaciaContext _dbcontext; 

        public CompraRepositorio(DbfarmaciaContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Compra> Registrar(Compra entidad)
        {
            Compra CompraGenerada = new Compra();

            //usaremos transacion, ya que si ocurre un error en algun insert a una tabla, debe reestablecer todo a cero, como si no hubo o no existió ningun insert
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                int CantidadDigitos = 4;
                try
                {
                    foreach (DetalleCompra dv in entidad.DetalleCompras)
                    {
                        Producto producto_encontrado = _dbcontext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto_encontrado.Stock = producto_encontrado.Stock + dv.CantidadInventario;
                        _dbcontext.Productos.Update(producto_encontrado);
                    }
                    await _dbcontext.SaveChangesAsync();


                    NumeroDocumentoCompra correlativo = _dbcontext.NumeroDocumentoCompras.First();

                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistro = DateTime.Now;

                    _dbcontext.NumeroDocumentoCompras.Update(correlativo);
                    await _dbcontext.SaveChangesAsync();


                    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));
                    string numeroCompra = ceros + correlativo.UltimoNumero.ToString();
                    numeroCompra = numeroCompra.Substring(numeroCompra.Length - CantidadDigitos, CantidadDigitos);

                    entidad.NumeroDocumentoCompra = numeroCompra;

                    await _dbcontext.Compras.AddAsync(entidad);
                    await _dbcontext.SaveChangesAsync();

                    CompraGenerada = entidad;

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        
            return CompraGenerada;
            
        }

        public async Task<List<Compra>> Historial(string buscarPor, string numeroCompra, string fechaInicio, string fechaFin)
        {
            IQueryable<Compra> query = _dbcontext.Compras;

            if (buscarPor == "fecha")
            {

                DateTime fech_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-PE"));
                DateTime fech_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-PE"));

                return query.Where(v =>
                    v.FechaRegistro.Value.Date >= fech_Inicio.Date &&
                    v.FechaRegistro.Value.Date <= fech_Fin.Date
                )
                .Include(dv => dv.DetalleCompras)
                .ThenInclude(p => p.IdProductoNavigation)
                .ToList();

            }
            else
            {
                return query.Where(v => v.NumeroDocumentoCompra == numeroCompra)
                  .Include(dv => dv.DetalleCompras)
                  .ThenInclude(p => p.IdProductoNavigation)
                  .ToList();
            }
        }

        public async Task<List<DetalleCompra>> Reporte(string FechaInicio, string FechaFin)
        {
            DateTime fech_Inicio = DateTime.ParseExact(FechaInicio, "dd/MM/yyyy", new CultureInfo("es-PE"));
            DateTime fech_Fin = DateTime.ParseExact(FechaFin, "dd/MM/yyyy", new CultureInfo("es-PE"));

            List<DetalleCompra> listaResumen = await _dbcontext.DetalleCompra
                .Include(p => p.IdProductoNavigation)
                .Include(v => v.IdCompraNavigation)
                .Where(dv => dv.IdCompraNavigation.FechaRegistro.Value.Date >= fech_Inicio.Date && dv.IdCompraNavigation.FechaRegistro.Value.Date <= fech_Fin.Date)
                .ToListAsync();

            return listaResumen;
        }

        public async Task<Compra> ObtenerPorId(int id)
        {
            //   return await _dbcontext.Venta.FirstOrDefaultAsync(c => c.IdVenta == id);
            return await _dbcontext.Compras
          .Include(v => v.DetalleCompras)
          .ThenInclude(dv => dv.IdProductoNavigation) // Asegúrate de incluir los productos
          .Include(v => v.IdProveedorNavigation)
          .FirstOrDefaultAsync(c => c.IdCompra == id);


            //return await _dbcontext.Venta.Include(v => v.DetalleVenta).ThenInclude(dv => dv.IdProductoNavigation).FirstOrDefaultAsync

        }

    }




}

