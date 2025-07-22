using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFarmacia.BLL.Servicios;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DTO;
using SistemaFarmacia.Model;

using QuestPDF.Fluent;

namespace SistemaFarmacia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompraRepositorio _compraRepositorio;

        public CompraController(IMapper mapper, ICompraRepositorio compraRepositorio)
        {
            _mapper = mapper;
            _compraRepositorio = compraRepositorio;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] CompraDTO request)
        {

            ResponseDTO<CompraDTO> _ResponseDTO = new ResponseDTO<CompraDTO>();
            try
            {

                Compra venta_creada = await _compraRepositorio.Registrar(_mapper.Map<Compra>(request));
                request = _mapper.Map<CompraDTO>(venta_creada);

                if (venta_creada.IdCompra != 0)
                    _ResponseDTO = new ResponseDTO<CompraDTO>() { status = true, msg = "ok", value = request };
                else
                    _ResponseDTO = new ResponseDTO<CompraDTO>() { status = false, msg = "No se pudo registrar la venta" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);



            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<CompraDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }

        }

        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor, string? numeroVenta, string? fechaInicio, string? fechaFin)
        {
            ResponseDTO<List<CompraDTO>> _ResponseDTO = new ResponseDTO<List<CompraDTO>>();

            numeroVenta = numeroVenta is null ? "" : numeroVenta;
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaInicio is null ? "" : fechaFin;
            try
            {

                List<CompraDTO> vmHistorialVenta = _mapper.Map<List<CompraDTO>>(await _compraRepositorio.Historial(buscarPor, numeroVenta, fechaInicio, fechaFin));

                if (vmHistorialVenta.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<CompraDTO>>() { status = true, msg = "ok", value = vmHistorialVenta };
                else
                    _ResponseDTO = new ResponseDTO<List<CompraDTO>>() { status = false, msg = "No se pudo registrar la compra" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<CompraDTO>>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);

            }

        }

        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechaFin)
        {
            ResponseDTO<List<ReporteCompraDTO>> _ResponseDTO = new ResponseDTO<List<ReporteCompraDTO>>();
            try
            {

                List<ReporteCompraDTO> listaReporte = _mapper.Map<List<ReporteCompraDTO>>(await _compraRepositorio.Reporte(fechaInicio, fechaFin));

                if (listaReporte.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<ReporteCompraDTO>>() { status = true, msg = "ok", value = listaReporte };
                else
                    _ResponseDTO = new ResponseDTO<List<ReporteCompraDTO>>() { status = false, msg = "No se pudo registrar la venta" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ReporteCompraDTO>>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);

            }

        }


        [HttpGet("comprapdf/{id}")]
        public async Task<IActionResult> CompraIdPdf(int id)
        {
            try
            {
                // Obtener la categoría específica desde el repositorio
                var compra = await _compraRepositorio.ObtenerPorId(id); // Asumo que este método obtiene una sola categoría por su ID

                // Verificar si la categoría existe
                if (compra == null)
                {
                    return NotFound(new { message = "Compra no encontrada." });
                }

                // Generar el PDF con la categoría
                var pdf = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(30); // Este es un margen entre los datos y la hoja
                        page.Header().Row(row =>
                        {
                            row.ConstantItem(140).Height(60).Placeholder();

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().AlignCenter().Text("MEDICAMENTOS FOTOSA").Bold().FontSize(14);
                                col.Item().AlignCenter().Text("Mercado Chimaltenango").Bold().FontSize(9);
                                col.Item().AlignCenter().Text("Tel 7839-17-05").Bold().FontSize(9);
                                col.Item().AlignCenter().Text("fotosa@gmail.com").Bold().FontSize(9);
                            });

                            row.RelativeItem().Column(col =>
                            {
                                //  col.Item().Border(1).BorderColor("#257272").AlignCenter().Text(venta.IdVenta.ToString());
                                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text(compra.IdProveedorNavigation.Nombre);
                                col.Item().Background("#257272").AlignCenter().Text(compra.NumeroDocumentoCompra.ToString()).FontColor("#fff");
                                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text(compra.FechaRegistro.ToString());
                            });
                        });

                        page.Content().PaddingVertical(10)
                            .Column(column =>
                            {
                                column.Item().Text("Datos del Cliente").Underline().Bold();

                                column.Item().Text(txt =>
                                {
                                    txt.Span("Nombre: ").SemiBold().FontSize(10);
                                    txt.Span($"{compra.IdProveedorNavigation?.Nombre ?? "N/A"}").FontSize(10);
                                });

                                column.Item().Text(txt =>
                                {
                                    txt.Span("NIT: ").SemiBold().FontSize(10);
                                    txt.Span($"{compra.IdProveedorNavigation?.Nit ?? "N/A"}").FontSize(10);
                                });

                                column.Item().Text(txt =>
                                {
                                    txt.Span("Direccion: ").SemiBold().FontSize(10);
                                    txt.Span($"{compra.IdProveedorNavigation?.Direccion ?? "N/A"}").FontSize(10);
                                });

                                // Esta es la línea de separación
                                column.Item().LineHorizontal(0.5f);

                                // Generar la tabla con solo la categoría obtenida
                                column.Item().Table(tabla =>
                                {
                                    tabla.ColumnsDefinition(colums =>
                                    {

                                        colums.RelativeColumn();
                                        colums.RelativeColumn();
                                        //  colums.RelativeColumn();
                                        colums.RelativeColumn();
                                        colums.RelativeColumn();
                                        colums.RelativeColumn();
                                    });

                                    tabla.Header(header =>
                                    {
                                        header.Cell().Background("#257272").Padding(2).Text("Codigo");
                                        header.Cell().Background("#257272").Padding(2).Text("Cantidad");
                                        // header.Cell().Background("#257272").Padding(2).Text("Presentacion");
                                        header.Cell().Background("#257272").Padding(2).Text("Producto");
                                        header.Cell().Background("#257272").Padding(2).Text("Precio");
                                        header.Cell().Background("#257272").Padding(2).Text("Total");
                                    });


                                    foreach (var detalle in compra.DetalleCompras)
                                    {
                                        tabla.Cell().Padding(2).Text(detalle.IdProductoNavigation.Codigo.ToString()).FontSize(10);
                                        //    tabla.Cell().Padding(2).Text(detalle.IdProductoNavigation?.Descripcion ?? "N/A").FontSize(10); // Descripción del producto
                                        //  tabla.Cell().Padding(2).Text(detalle.Precio.ToString("F2")).FontSize(10); // Precio
                                        tabla.Cell().Padding(2).Text(detalle.CantidadReporte.ToString()).FontSize(10); // Cantidad

                                        tabla.Cell().Padding(2).Text(detalle.IdProductoNavigation.Nombre.ToString()).FontSize(10);
                                        //  tabla.Cell().Padding(2).Text(detalle.IdProductoNavigation.Prutero.ToString()).FontSize(10);
                                        tabla.Cell().Padding(2).Text(detalle.Precio.ToString()).FontSize(10);
                                        tabla.Cell().Padding(2).Text(detalle.Total?.ToString("F2") ?? "0.00").FontSize(10); // Total
                                    }


                                    foreach (var detalle in compra.DetalleCompras)
                                    {
                                        Console.WriteLine($"Producto: {detalle.IdProductoNavigation.Nombre}, Precio: {detalle.Precio}, Cantidad: {detalle.CantidadReporte}, Total: {detalle.Total}");
                                    }

                                    // Aquí agregamos solo la categoría obtenida
                                    /*  tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                          .Padding(2).Text(venta.IdVenta.ToString()).FontSize(10);

                                      tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                          .Padding(2).Text(venta.Total).FontSize(10);*/
                                });
                            });
                    });
                });

                // Generar el archivo PDF en formato de bytes
                var pdfBytes = pdf.GeneratePdf();

                // Asegurarse de que se está devolviendo el archivo correctamente para que se muestre en el navegador
                return new FileContentResult(pdfBytes, "application/pdf");
            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de excepción
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }


       


    }
}
