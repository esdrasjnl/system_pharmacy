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
    public class CotizacionRepositorio: ICotizacionRepositorio
    {
        private readonly DbfarmaciaContext _dbcontext;

        public CotizacionRepositorio(DbfarmaciaContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task<Cotizacion> Registrar(Cotizacion entidad)
        {
            Cotizacion CotizacionGenerada = new Cotizacion();

            //usaremos transacion, ya que si ocurre un error en algun insert a una tabla, debe reestablecer todo a cero, como si no hubo o no existió ningun insert
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                int CantidadDigitos = 4;
                try
                {
                    foreach (DetalleCotizacion dv in entidad.DetalleCotizacions)
                    {
                        Producto producto_encontrado = _dbcontext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                       // producto_encontrado.Stock = producto_encontrado.Stock - dv.CantidadInventario;
                        _dbcontext.Productos.Update(producto_encontrado);
                    }
                    await _dbcontext.SaveChangesAsync();


                    NumeroDocumentoCotizacion correlativo = _dbcontext.NumeroDocumentoCotizacions.First();

                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistro = DateTime.Now;

                    _dbcontext.NumeroDocumentoCotizacions.Update(correlativo);
                    await _dbcontext.SaveChangesAsync();


                    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));
                    string numeroCotizacion = ceros + correlativo.UltimoNumero.ToString();
                    numeroCotizacion = numeroCotizacion.Substring(numeroCotizacion.Length - CantidadDigitos, CantidadDigitos);

                    entidad.NumeroDocumentoCotizacion = numeroCotizacion;

                    await _dbcontext.Cotizacions.AddAsync(entidad);
                    await _dbcontext.SaveChangesAsync();

                    CotizacionGenerada = entidad;

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return CotizacionGenerada;
        }

        public async Task<List<Cotizacion>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            IQueryable<Cotizacion> query = _dbcontext.Cotizacions;

            if (buscarPor == "fecha")
            {

                DateTime fech_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-PE"));
                DateTime fech_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-PE"));

                return query.Where(v =>
                    v.FechaRegistro.Value.Date >= fech_Inicio.Date &&
                    v.FechaRegistro.Value.Date <= fech_Fin.Date
                )
                .Include(dv => dv.DetalleCotizacions)
                .ThenInclude(p => p.IdProductoNavigation)
                .ToList();

            }
            else
            {
                return query.Where(v => v.NumeroDocumentoCotizacion == numeroVenta)
                  .Include(dv => dv.DetalleCotizacions)
                  .ThenInclude(p => p.IdProductoNavigation)
                  .ToList();
            }
        }

        public async Task<List<DetalleCotizacion>> Reporte(string FechaInicio, string FechaFin)
        {
            DateTime fech_Inicio = DateTime.ParseExact(FechaInicio, "dd/MM/yyyy", new CultureInfo("es-PE"));
            DateTime fech_Fin = DateTime.ParseExact(FechaFin, "dd/MM/yyyy", new CultureInfo("es-PE"));

            List<DetalleCotizacion> listaResumen = await _dbcontext.DetalleCotizacion
                .Include(p => p.IdProductoNavigation)
                .Include(v => v.IdCotizacionNavigation)
                .Where(dv => dv.IdCotizacionNavigation.FechaRegistro.Value.Date >= fech_Inicio.Date && dv.IdCotizacionNavigation.FechaRegistro.Value.Date <= fech_Fin.Date)
                .ToListAsync();

            return listaResumen;
        }

        public async Task<Cotizacion> ObtenerPorId(int id)
        {
            //   return await _dbcontext.Venta.FirstOrDefaultAsync(c => c.IdVenta == id);
            return await _dbcontext.Cotizacions
          .Include(v => v.DetalleCotizacions)
          .ThenInclude(dv => dv.IdProductoNavigation) // Asegúrate de incluir los productos
          .Include(v => v.IdClienteNavigation)
          .FirstOrDefaultAsync(c => c.IdCotizacion == id);


            //return await _dbcontext.Venta.Include(v => v.DetalleVenta).ThenInclude(dv => dv.IdProductoNavigation).FirstOrDefaultAsync
        }


    }
}
