using AutoMapper;
using SistemaFarmacia.DTO;
using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.Utility
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            #region Rol
            CreateMap<Rol, RolDTO>().ReverseMap();
            #endregion Rol

            #region Usuario
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(destino =>
                    destino.rolDescripcion,
                    opt => opt.MapFrom(origen => origen.IdRolNavigation.Descripcion)
                );

            CreateMap<UsuarioDTO, Usuario>()
            .ForMember(destino =>
                destino.IdRolNavigation,
                opt => opt.Ignore()
            ).ForMember(destino =>
                    destino.EsActivo,
                    opt => opt.MapFrom(src => true)
                );

            
            #endregion Usuario

            #region Categoria
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            #endregion Categoria

            #region Producto
            CreateMap<Producto, ProductoDTO>()
            .ForMember(destino =>
                destino.DescripcionCategoria,
                opt => opt.MapFrom(origen => origen.IdCategoriaNavigation.Descripcion)
            );


            CreateMap<ProductoDTO, Producto>()
            .ForMember(destino =>
                destino.IdCategoriaNavigation,
                opt => opt.Ignore()
            );
            #endregion Producto

            #region Presentacion
            CreateMap<Presentacion, PresentacionDTO>().ReverseMap();
            #endregion Presentacion

            #region Venta
            CreateMap<Venta, VentaDTO>()
            .ForMember(destino =>
                destino.NombreCliente,
                opt => opt.MapFrom(origen => origen.IdClienteNavigation.NombreCompleto)
            );
            //CreateMap<Venta, VentaDTO>()
            //    .ForMember(destino =>
            //        destino.TotalTexto,
            //        opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
            //    ).ForMember(destino =>
            //        destino.FechaRegistro,
            //        opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
            //    );
            CreateMap<VentaDTO, Venta>()
                .ForMember(destino =>
                destino.IdClienteNavigation,
                opt => opt.Ignore()
            );
            //CreateMap<VentaDTO, Venta>()
            //    .ForMember(destino =>
            //        destino.Total,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
            //    );

            #endregion Venta

            #region Compra
            CreateMap<Compra, CompraDTO>()
            .ForMember(destino =>
                destino.NombreProveedor,
                opt => opt.MapFrom(origen => origen.IdProveedorNavigation.Nombre)
            );
            //CreateMap<Venta, VentaDTO>()
            //    .ForMember(destino =>
            //        destino.TotalTexto,
            //        opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
            //    ).ForMember(destino =>
            //        destino.FechaRegistro,
            //        opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
            //    );
            CreateMap<CompraDTO, Compra>()
                .ForMember(destino =>
                destino.IdProveedorNavigation,
                opt => opt.Ignore()
            );
            //CreateMap<VentaDTO, Venta>()
            //    .ForMember(destino =>
            //        destino.Total,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
            //    );

            #endregion Compra

            #region Cotizacion
            CreateMap<Cotizacion, CotizacionDTO>()
            .ForMember(destino =>
                destino.NombreCliente,
                opt => opt.MapFrom(origen => origen.IdClienteNavigation.NombreCompleto)
            );
            //CreateMap<Venta, VentaDTO>()
            //    .ForMember(destino =>
            //        destino.TotalTexto,
            //        opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
            //    ).ForMember(destino =>
            //        destino.FechaRegistro,
            //        opt => opt.MapFrom(origen => origen.FechaRegistro.Value.ToString("dd/MM/yyyy"))
            //    );
            CreateMap<CotizacionDTO, Cotizacion>()
                .ForMember(destino =>
                destino.IdClienteNavigation,
                opt => opt.Ignore()
            );
            //CreateMap<VentaDTO, Venta>()
            //    .ForMember(destino =>
            //        destino.Total,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
            //    );

            #endregion Cotizacion


            #region DetalleVenta
            CreateMap<DetalleVenta, DetalleVentaDTO>()
                .ForMember(destino =>
                    destino.DescripcionProducto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                );
            //.ForMember(destino =>
            //    destino.PrecioTexto,
            //    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
            //)
            //.ForMember(destino =>
            //    destino.TotalTexto,
            //    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
            //);
            CreateMap<DetalleVentaDTO, DetalleVenta>();

            //CreateMap<DetalleVentaDTO, DetalleVenta>()
            //    .ForMember(destino =>
            //        destino.Precio,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTexto, new CultureInfo("es-PE")))
            //    )
            //    .ForMember(destino =>
            //        destino.Total,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
            //    );
            #endregion DetalleVenta


            #region DetalleCompra
            CreateMap<DetalleCompra, DetalleCompraDTO>()
                .ForMember(destino =>
                    destino.DescripcionProducto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                );
            //.ForMember(destino =>
            //    destino.PrecioTexto,
            //    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
            //)
            //.ForMember(destino =>
            //    destino.TotalTexto,
            //    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
            //);
            CreateMap<DetalleCompraDTO, DetalleCompra>();

            //CreateMap<DetalleVentaDTO, DetalleVenta>()
            //    .ForMember(destino =>
            //        destino.Precio,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTexto, new CultureInfo("es-PE")))
            //    )
            //    .ForMember(destino =>
            //        destino.Total,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
            //    );
            #endregion DetalleCompra


            #region DetalleCotizacion
            CreateMap<DetalleCotizacion, DetalleCotizacionDTO>()
                .ForMember(destino =>
                    destino.DescripcionProducto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                );
            //.ForMember(destino =>
            //    destino.PrecioTexto,
            //    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
            //)
            //.ForMember(destino =>
            //    destino.TotalTexto,
            //    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
            //);
            CreateMap<DetalleCotizacionDTO, DetalleCotizacion>();

            //CreateMap<DetalleVentaDTO, DetalleVenta>()
            //    .ForMember(destino =>
            //        destino.Precio,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PrecioTexto, new CultureInfo("es-PE")))
            //    )
            //    .ForMember(destino =>
            //        destino.Total,
            //        opt => opt.MapFrom(origen => Convert.ToDecimal(origen.TotalTexto, new CultureInfo("es-PE")))
            //    );
            #endregion DetalleCotizacion


            #region Reporte
            CreateMap<DetalleVenta, ReporteDTO>()
                .ForMember(destino =>
                    destino.FechaRegistro,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                )
                .ForMember(destino =>
                    destino.NumeroDocumento,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.NumeroDocumento)
                )
                .ForMember(destino =>
                    destino.TipoPago,
                    opt => opt.MapFrom(origen => origen.IdVentaNavigation.TipoPago)
                )
                .ForMember(destino =>
                    destino.TotalVenta,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.IdVentaNavigation.Total.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Producto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                )
                .ForMember(destino =>
                    destino.Cantidad,
                    opt => opt.MapFrom(origen => origen.CantidadReporte)
                )
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                );
            #endregion Reporte

            #region Reporte Compra
            

            CreateMap<DetalleCompra, ReporteCompraDTO>()
                .ForMember(destino =>
                    destino.FechaRegistro,
                    opt => opt.MapFrom(origen => origen.IdCompraNavigation.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                )
                .ForMember(destino =>
                    destino.NumeroDocumentoCompra,
                    opt => opt.MapFrom(origen => origen.IdCompraNavigation.NumeroDocumentoCompra)
                )
                .ForMember(destino =>
                    destino.TipoPago,
                    opt => opt.MapFrom(origen => origen.IdCompraNavigation.TipoPago)
                )
                .ForMember(destino =>
                    destino.TotalCompra,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.IdCompraNavigation.Total.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Producto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                ).ForMember(destino =>
                    destino.Cantidad,
                    opt => opt.MapFrom(origen => origen.CantidadReporte)
                )
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                );
            #endregion Reporte Compra


            #region Reporte Cotizacion
            CreateMap<DetalleCotizacion, ReporteCotizacionDTO>()
                .ForMember(destino =>
                    destino.FechaRegistro,
                    opt => opt.MapFrom(origen => origen.IdCotizacionNavigation.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                )
                .ForMember(destino =>
                    destino.NumeroDocumentoCotizacion,
                    opt => opt.MapFrom(origen => origen.IdCotizacionNavigation.NumeroDocumentoCotizacion)
                )
                .ForMember(destino =>
                    destino.TipoPago,
                    opt => opt.MapFrom(origen => origen.IdCotizacionNavigation.TipoPago)
                )
                .ForMember(destino =>
                    destino.TotalCotizacion,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.IdCotizacionNavigation.Total.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Producto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.Nombre)
                )
                .ForMember(destino =>
                    destino.Cantidad,
                    opt => opt.MapFrom(origen => origen.CantidadReporte)
                )
                .ForMember(destino =>
                    destino.Precio,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Precio.Value, new CultureInfo("es-PE")))
                )
                .ForMember(destino =>
                    destino.Total,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Total.Value, new CultureInfo("es-PE")))
                );
            #endregion Reporte Cotizacion


            #region Presentacion Producto
            CreateMap<Prodpresentacion, ProdpresentacionDTO>()
            .ForMember(destino =>
                destino.DescripcionPresentacion,
                opt => opt.MapFrom(origen => origen.IdPresentacionNavigation.Descripcion)
            );
            

            CreateMap<ProdpresentacionDTO, Prodpresentacion>()
            .ForMember(destino =>
                destino.IdPresentacionNavigation,
                opt => opt.Ignore()
            );

            #endregion Presentacion Producto


            #region Cliente
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            #endregion Cliente


            #region Proveedor
            CreateMap<Proveedor, ProveedorDTO>().ReverseMap();
            #endregion Proveedor





        }
    }
}
