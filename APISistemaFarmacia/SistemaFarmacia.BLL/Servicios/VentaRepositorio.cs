﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DAL.DBContext;
using SistemaFarmacia.DAL.Repositorios.Contrato;
using SistemaFarmacia.DTO;
using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using System.Xml.Linq;


namespace SistemaFarmacia.BLL.Servicios
{
    public class VentaRepositorio: IVentaRepositorio
    {
        private readonly DbfarmaciaContext _dbcontext;
        
        public VentaRepositorio(DbfarmaciaContext context)
        {
            _dbcontext = context;
            
        }

        public async Task<Venta> Registrar(Venta entidad)
        {
            Venta VentaGenerada = new Venta();

            //usaremos transacion, ya que si ocurre un error en algun insert a una tabla, debe reestablecer todo a cero, como si no hubo o no existió ningun insert
            using (var transaction = _dbcontext.Database.BeginTransaction())
            {
                int CantidadDigitos = 4;
                try
                {
                    foreach (DetalleVenta dv in entidad.DetalleVenta)
                    {
                        Producto producto_encontrado = _dbcontext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto_encontrado.Stock = producto_encontrado.Stock - dv.CantidadInventario;
                        _dbcontext.Productos.Update(producto_encontrado);
                    }
                    await _dbcontext.SaveChangesAsync();


                    NumeroDocumento correlativo = _dbcontext.NumeroDocumentos.First();

                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistro = DateTime.Now;

                    _dbcontext.NumeroDocumentos.Update(correlativo);
                    await _dbcontext.SaveChangesAsync();


                    string ceros = string.Concat(Enumerable.Repeat("0", CantidadDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - CantidadDigitos, CantidadDigitos);

                    entidad.NumeroDocumento = numeroVenta;

                    await _dbcontext.Venta.AddAsync(entidad);
                    await _dbcontext.SaveChangesAsync();

                    VentaGenerada = entidad;

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return VentaGenerada;
            
        }


      

        public async Task<List<Venta>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            IQueryable<Venta> query = _dbcontext.Venta;

            if (buscarPor == "fecha")
            {

                DateTime fech_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-PE"));
                DateTime fech_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-PE"));

                return query.Where(v =>
                    v.FechaRegistro.Value.Date >= fech_Inicio.Date &&
                    v.FechaRegistro.Value.Date <= fech_Fin.Date
                )
                .Include(dv => dv.DetalleVenta)
                .ThenInclude(p => p.IdProductoNavigation)
                .ToList();

            }
            else
            {
                return query.Where(v => v.NumeroDocumento == numeroVenta)
                  .Include(dv => dv.DetalleVenta)
                  .ThenInclude(p => p.IdProductoNavigation)
                  .ToList();
            }


        }

        public async Task<List<DetalleVenta>> Reporte(string FechaInicio, string FechaFin)
        {

            DateTime fech_Inicio = DateTime.ParseExact(FechaInicio, "dd/MM/yyyy", new CultureInfo("es-PE"));
            DateTime fech_Fin = DateTime.ParseExact(FechaFin, "dd/MM/yyyy", new CultureInfo("es-PE"));

            List<DetalleVenta> listaResumen = await _dbcontext.DetalleVenta
                .Include(p => p.IdProductoNavigation)
                .Include(v => v.IdVentaNavigation)
                .Where(dv => dv.IdVentaNavigation.FechaRegistro.Value.Date >= fech_Inicio.Date && dv.IdVentaNavigation.FechaRegistro.Value.Date <= fech_Fin.Date)
                .ToListAsync();

            return listaResumen;
        }

        public async Task<Venta> ObtenerPorId(int id)
        {
         //   return await _dbcontext.Venta.FirstOrDefaultAsync(c => c.IdVenta == id);
          return await _dbcontext.Venta
        .Include(v => v.DetalleVenta)
        .ThenInclude(dv => dv.IdProductoNavigation) // Asegúrate de incluir los productos
        .Include(v => v.IdClienteNavigation)
        .FirstOrDefaultAsync(c => c.IdVenta == id);
         

            //return await _dbcontext.Venta.Include(v => v.DetalleVenta).ThenInclude(dv => dv.IdProductoNavigation).FirstOrDefaultAsync
            
        }

        public async Task<VentaDTO> Obtener(int ventaId)
        {
            var venta = await _dbcontext.Venta
                .Include(v => v.DetalleVenta) // Solo si necesitas también los detalles
                .FirstOrDefaultAsync(v => v.IdVenta == ventaId);

            if (venta == null)
                return null;

            var ventaDto = new VentaDTO
            {
                IdVenta = venta.IdVenta,
                NombreCliente = venta.NumeroDocumento,
                Total = venta.Total,
                // Mapear otros campos que necesites
            };

            return ventaDto;
        }


    }
}
