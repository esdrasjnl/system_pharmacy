using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFarmacia.BLL.Servicios;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DTO;
using SistemaFarmacia.Model;

using QuestPDF.Fluent;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml.Linq;
using SistemaFarmacia.DAL.DBContext;

namespace SistemaFarmacia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVentaRepositorio _ventaRepositorio;
        private readonly IFacturaElectronicaService _facturaElectronicaService;
        private readonly DbfarmaciaContext _context;

        public VentaController(IMapper mapper, IVentaRepositorio ventaRepositorio, IFacturaElectronicaService facturaElectronicaService, DbfarmaciaContext context)
        {
            _mapper = mapper;
            _ventaRepositorio = ventaRepositorio;
            _facturaElectronicaService = facturaElectronicaService;
            _context = context;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO request)
        {

            ResponseDTO<VentaDTO> _ResponseDTO = new ResponseDTO<VentaDTO>();
            try
            {

                Venta venta_creada = await _ventaRepositorio.Registrar(_mapper.Map<Venta>(request));
                request = _mapper.Map<VentaDTO>(venta_creada);

                if (venta_creada.IdVenta != 0)
                    _ResponseDTO = new ResponseDTO<VentaDTO>() { status = true, msg = "ok", value = request };
                else
                    _ResponseDTO = new ResponseDTO<VentaDTO>() { status = false, msg = "No se pudo registrar la venta" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);

               

            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<VentaDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
            
        }

        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor, string? numeroVenta, string? fechaInicio, string? fechaFin)
        {
            ResponseDTO<List<VentaDTO>> _ResponseDTO = new ResponseDTO<List<VentaDTO>>();

            numeroVenta = numeroVenta is null ? "" : numeroVenta;
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaInicio is null ? "" : fechaFin;

            try
            {

                List<VentaDTO> vmHistorialVenta = _mapper.Map<List<VentaDTO>>(await _ventaRepositorio.Historial(buscarPor, numeroVenta, fechaInicio, fechaFin));

                if (vmHistorialVenta.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<VentaDTO>>() { status = true, msg = "ok", value = vmHistorialVenta };
                else
                    _ResponseDTO = new ResponseDTO<List<VentaDTO>>() { status = false, msg = "No se pudo registrar la venta" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<VentaDTO>>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);

            }

        }

        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechaFin)
        {
            ResponseDTO<List<ReporteDTO>> _ResponseDTO = new ResponseDTO<List<ReporteDTO>>();
            try
            {

                List<ReporteDTO> listaReporte = _mapper.Map<List<ReporteDTO>>(await _ventaRepositorio.Reporte(fechaInicio, fechaFin));

                if (listaReporte.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<ReporteDTO>>() { status = true, msg = "ok", value = listaReporte };
                else
                    _ResponseDTO = new ResponseDTO<List<ReporteDTO>>() { status = false, msg = "No se pudo registrar la venta" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ReporteDTO>>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);

            }

        }





        [HttpGet("pdf/{id}")]
        public async Task<IActionResult> VentaIdPdf(int id)
        {
            try
            {
                // Obtener la categoría específica desde el repositorio
                var venta = await _ventaRepositorio.ObtenerPorId(id); // Asumo que este método obtiene una sola categoría por su ID

                // Verificar si la categoría existe
                if (venta == null)
                {
                    return NotFound(new { message = "Categoría no encontrada." });
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
                                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text(venta.IdClienteNavigation.NombreCompleto);
                                col.Item().Background("#257272").AlignCenter().Text(venta.NumeroDocumento.ToString()).FontColor("#fff");
                                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text(venta.FechaRegistro.ToString());
                            });
                        });

                        page.Content().PaddingVertical(10)
                            .Column(column =>
                            {
                                column.Item().Text("Datos del Cliente").Underline().Bold();

                                column.Item().Text(txt =>
                                {
                                    txt.Span("Nombre: ").SemiBold().FontSize(10);
                                    txt.Span($"{venta.IdClienteNavigation?.NombreCompleto ?? "N/A"}").FontSize(10);
                                });

                                column.Item().Text(txt =>
                                {
                                    txt.Span("NIT: ").SemiBold().FontSize(10);
                                    txt.Span($"{venta.IdClienteNavigation?.Nit ?? "N/A"}").FontSize(10);
                                });

                                column.Item().Text(txt =>
                                {
                                    txt.Span("Direccion: ").SemiBold().FontSize(10);
                                    txt.Span($"{venta.IdClienteNavigation?.Direccion ?? "N/A"}").FontSize(10);
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


                                    foreach (var detalle in venta.DetalleVenta)
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

                                    
                                        foreach (var detalle in venta.DetalleVenta)
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


        [HttpPost("certificar/{idVenta}")]
        public async Task<IActionResult> Certificar(int idVenta)
        {
            var resultado = await _facturaElectronicaService.CertificarVenta(idVenta);

            if (!resultado.Exito)
                return BadRequest(resultado.MensajeError);

            return Ok(resultado);
        }

        //[HttpGet("xmlCertificate/{id}")]
        //public async Task<IActionResult> VentaIdXml(int id)
        //{
        //    try
        //    {
        //        var venta = await _ventaRepositorio.ObtenerPorId(id);
        //        decimal iva = 1.12m;

        //        if (venta == null)
        //            return NotFound(new { message = "Venta no encontrada." });

        //        var fechaActual = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
        //        var itemsXml = "";
        //        int linea = 1;

        //        foreach (var detalle in venta.DetalleVenta)
        //        {
        //            itemsXml += $@"
        //                <dte:Item NumeroLinea=""{linea}"" BienOServicio=""B"">
        //                    <dte:Cantidad>{detalle.CantidadReporte:0.0000}</dte:Cantidad>
        //                    <dte:Descripcion>{detalle.IdProductoNavigation?.Nombre}</dte:Descripcion>
        //                    <dte:PrecioUnitario>{detalle.Precio:0.0000}</dte:PrecioUnitario>
        //                    <dte:Precio>{(detalle.CantidadReporte * detalle.Precio):0.0000}</dte:Precio>
        //                    <dte:Descuento>0.0000</dte:Descuento>
        //                    <dte:Impuestos>
        //                        <dte:Impuesto>
        //                            <dte:NombreCorto>IVA</dte:NombreCorto>
        //                            <dte:CodigoUnidadGravable>1</dte:CodigoUnidadGravable>
        //                            <dte:MontoGravable>{((detalle.Total ?? 0) / iva):0.0000}</dte:MontoGravable>
        //                            <dte:MontoImpuesto>{((detalle.Total ?? 0) - (detalle.Total ?? 0) / iva):0.0000}</dte:MontoImpuesto>
        //                        </dte:Impuesto>
        //                    </dte:Impuestos>
        //                    <dte:Total>{detalle.Total:0.0000}</dte:Total>
        //                </dte:Item>";
        //            linea++;
        //        }

        //        var totalVenta = venta.DetalleVenta.Sum(d => d.Total ?? 0);
        //        var totalImpuesto = totalVenta - (totalVenta / iva);
        //        var certId = Guid.NewGuid().ToString().ToUpper();

        //        var cdataContent = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
        //                <dte:GTDocumento Version=""0.1"" xmlns:dte=""http://www.sat.gob.gt/dte/fel/0.2.0""
        //                    xmlns:cfc=""http://www.sat.gob.gt/dte/fel/CompCambiaria/0.1.0""
        //                    xmlns:cex=""http://www.sat.gob.gt/face2/ComplementoExportaciones/0.1.0""
        //                    xmlns:cfe=""http://www.sat.gob.gt/face2/ComplementoFacturaEspecial/0.1.0""
        //                    xmlns:cno=""http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0""
        //                    xmlns:ds=""http://www.w3.org/2000/09/xmldsig#""
        //                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
        //                  <dte:SAT ClaseDocumento=""dte"">
        //                    <dte:DTE ID=""DatosCertificados"">
        //                      <dte:DatosEmision ID=""DatosEmision"">
        //                        <dte:DatosGenerales Tipo=""FACT"" FechaHoraEmision=""{fechaActual}"" CodigoMoneda=""GTQ"" />
        //                        <dte:Emisor NITEmisor=""107346834"" NombreEmisor=""TEKRA SOCIEDAD ANONIMA"" CodigoEstablecimiento=""1""
        //                                    NombreComercial=""TEKRA SOCIEDAD ANONIMA"" CorreoEmisor="""" AfiliacionIVA=""GEN"">
        //                          <dte:DireccionEmisor>
        //                            <dte:Direccion>19 CALLE 18-48</dte:Direccion>
        //                            <dte:CodigoPostal>01010</dte:CodigoPostal>
        //                            <dte:Municipio>GUATEMALA</dte:Municipio>
        //                            <dte:Departamento>GUATEMALA</dte:Departamento>
        //                            <dte:Pais>GT</dte:Pais>
        //                          </dte:DireccionEmisor>
        //                        </dte:Emisor>
        //                        <dte:Receptor IDReceptor=""{venta.IdClienteNavigation?.Nit ?? "C/F"}""
        //                                      NombreReceptor=""{venta.IdClienteNavigation?.NombreCompleto}""
        //                                      CorreoReceptor=""correo@ejemplo.com"">
        //                          <dte:DireccionReceptor>
        //                            <dte:Direccion>{venta.IdClienteNavigation?.Direccion ?? "GUATEMALA"}</dte:Direccion>
        //                            <dte:CodigoPostal>01001</dte:CodigoPostal>
        //                            <dte:Municipio>GUATEMALA</dte:Municipio>
        //                            <dte:Departamento>GUATEMALA</dte:Departamento>
        //                            <dte:Pais>GT</dte:Pais>
        //                          </dte:DireccionReceptor>
        //                        </dte:Receptor>
        //                        <dte:Frases>
        //                          <dte:Frase TipoFrase=""1"" CodigoEscenario=""1"" />
        //                        </dte:Frases>
        //                        <dte:Items>
        //                          {itemsXml}
        //                        </dte:Items>
        //                        <dte:Totales>
        //                          <dte:TotalImpuestos>
        //                            <dte:TotalImpuesto NombreCorto=""IVA"" TotalMontoImpuesto=""{totalImpuesto:0.0000}"" />
        //                          </dte:TotalImpuestos>
        //                          <dte:GranTotal>{totalVenta:0.0000}</dte:GranTotal>
        //                        </dte:Totales>
        //                      </dte:DatosEmision>
        //                    </dte:DTE>
        //                    <dte:Adenda>
        //                      <DECertificador>{certId}</DECertificador>
        //                    </dte:Adenda>
        //                  </dte:SAT>
        //                </dte:GTDocumento>";

        //        var soapXml = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
        //                <SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""
        //                                   xmlns:ns1=""http://apicertificacion.desa.tekra.com.gt:8080/certificacion/wsdl/"">
        //                  <SOAP-ENV:Body>
        //                    <ns1:CertificacionDocumento>
        //                      <Autenticacion>
        //                        <pn_usuario>tekra_api</pn_usuario>
        //                        <pn_clave>123456789</pn_clave>
        //                        <pn_cliente>2121010001</pn_cliente>
        //                        <pn_contrato>2122010001</pn_contrato>
        //                        <pn_id_origen>TEKRA_PRUEBA</pn_id_origen>
        //                        <pn_ip_origen>192.168.0.100</pn_ip_origen>
        //                        <pn_firmar_emisor>SI</pn_firmar_emisor>
        //                        <pn_validar_identificador>SI</pn_validar_identificador>
        //                      </Autenticacion>
        //                      <Documento><![CDATA[{cdataContent}]]></Documento>
        //                    </ns1:CertificacionDocumento>
        //                  </SOAP-ENV:Body>
        //                </SOAP-ENV:Envelope>";

        //        // Enviar el XML como text/xml a TEKRA
        //        using var httpClient = new HttpClient();
        //        var content = new StringContent(soapXml, Encoding.UTF8, "text/xml");
        //        var response = await httpClient.PostAsync("http://apicertificacion.desa.tekra.com.gt:8080/certificacion/servicio.php", content);
        //        var responseText = await response.Content.ReadAsStringAsync();

        //        // Buscar el contenido entre <RepresentacionGrafica>...</RepresentacionGrafica>
        //        var startTag = "<RepresentacionGrafica>";
        //        var endTag = "</RepresentacionGrafica>";
        //        var startIndex = responseText.IndexOf(startTag);
        //        var endIndex = responseText.IndexOf(endTag);

        //        if (startIndex == -1 || endIndex == -1 || endIndex <= startIndex)
        //            return StatusCode(500, new { message = "No se encontró la representación gráfica (PDF) en la respuesta." });

        //        startIndex += startTag.Length;
        //        var base64Pdf = responseText.Substring(startIndex, endIndex - startIndex).Trim();

        //        var pdfBytes = Convert.FromBase64String(base64Pdf);
        //        var pdfFileName = $"venta_{venta.IdVenta}_TEKRA.pdf";

        //        //return File(pdfBytes, "application/pdf", pdfFileName);
        //        var result = new FileContentResult(pdfBytes, "application/pdf")
        //        {
        //            FileDownloadName = $"venta_{venta.IdVenta}_TEKRA.pdf"
        //        };
        //        Response.Headers["Content-Disposition"] = "inline; filename=" + result.FileDownloadName;
        //        //return result;

        //        //var pdfBytes = pdf.GeneratePdf();

        //        // Asegurarse de que se está devolviendo el archivo correctamente para que se muestre en el navegador
        //        return new FileContentResult(pdfBytes, "application/pdf");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        [HttpGet("xmlCertificate/{id}")]
        public async Task<IActionResult> VentaIdXml(int id)
        {
            try
            {
                var venta = await _ventaRepositorio.ObtenerPorId(id);
                decimal iva = 1.12m;

                if (venta == null)
                    return NotFound(new { message = "Venta no encontrada." });

                var fechaActual = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz");
                var itemsXml = "";
                int linea = 1;

                foreach (var detalle in venta.DetalleVenta)
                {
                    itemsXml += $@"
                <dte:Item NumeroLinea=""{linea}"" BienOServicio=""B"">
                    <dte:Cantidad>{detalle.CantidadReporte:0.0000}</dte:Cantidad>
                    <dte:Descripcion>{detalle.IdProductoNavigation?.Nombre}</dte:Descripcion>
                    <dte:PrecioUnitario>{detalle.Precio:0.0000}</dte:PrecioUnitario>
                    <dte:Precio>{(detalle.CantidadReporte * detalle.Precio):0.0000}</dte:Precio>
                    <dte:Descuento>0.0000</dte:Descuento>
                    <dte:Impuestos>
                        <dte:Impuesto>
                            <dte:NombreCorto>IVA</dte:NombreCorto>
                            <dte:CodigoUnidadGravable>1</dte:CodigoUnidadGravable>
                            <dte:MontoGravable>{((detalle.Total ?? 0) / iva):0.0000}</dte:MontoGravable>
                            <dte:MontoImpuesto>{((detalle.Total ?? 0) - (detalle.Total ?? 0) / iva):0.0000}</dte:MontoImpuesto>
                        </dte:Impuesto>
                    </dte:Impuestos>
                    <dte:Total>{detalle.Total:0.0000}</dte:Total>
                </dte:Item>";
                    linea++;
                }

                var totalVenta = venta.DetalleVenta.Sum(d => d.Total ?? 0);
                var totalImpuesto = totalVenta - (totalVenta / iva);
                var certId = Guid.NewGuid().ToString().ToUpper();

                var cdataContent = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
                <dte:GTDocumento Version=""0.1"" xmlns:dte=""http://www.sat.gob.gt/dte/fel/0.2.0""
                    xmlns:cfc=""http://www.sat.gob.gt/dte/fel/CompCambiaria/0.1.0""
                    xmlns:cex=""http://www.sat.gob.gt/face2/ComplementoExportaciones/0.1.0""
                    xmlns:cfe=""http://www.sat.gob.gt/face2/ComplementoFacturaEspecial/0.1.0""
                    xmlns:cno=""http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0""
                    xmlns:ds=""http://www.w3.org/2000/09/xmldsig#""
                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
                  <dte:SAT ClaseDocumento=""dte"">
                    <dte:DTE ID=""DatosCertificados"">
                      <dte:DatosEmision ID=""DatosEmision"">
                        <dte:DatosGenerales Tipo=""FACT"" FechaHoraEmision=""{fechaActual}"" CodigoMoneda=""GTQ"" />
                        <dte:Emisor NITEmisor=""107346834"" NombreEmisor=""TEKRA SOCIEDAD ANONIMA"" CodigoEstablecimiento=""1""
                                    NombreComercial=""TEKRA SOCIEDAD ANONIMA"" CorreoEmisor="""" AfiliacionIVA=""GEN"">
                          <dte:DireccionEmisor>
                            <dte:Direccion>19 CALLE 18-48</dte:Direccion>
                            <dte:CodigoPostal>01010</dte:CodigoPostal>
                            <dte:Municipio>GUATEMALA</dte:Municipio>
                            <dte:Departamento>GUATEMALA</dte:Departamento>
                            <dte:Pais>GT</dte:Pais>
                          </dte:DireccionEmisor>
                        </dte:Emisor>
                        <dte:Receptor IDReceptor=""{venta.IdClienteNavigation?.Nit ?? "C/F"}""
                                      NombreReceptor=""{venta.IdClienteNavigation?.NombreCompleto}"" CorreoReceptor=""correo@ejemplo.com"">
                          <dte:DireccionReceptor>
                            <dte:Direccion>{venta.IdClienteNavigation?.Direccion ?? "GUATEMALA"}</dte:Direccion>
                            <dte:CodigoPostal>01001</dte:CodigoPostal>
                            <dte:Municipio>GUATEMALA</dte:Municipio>
                            <dte:Departamento>GUATEMALA</dte:Departamento>
                            <dte:Pais>GT</dte:Pais>
                          </dte:DireccionReceptor>
                        </dte:Receptor>
                        <dte:Frases>
                          <dte:Frase TipoFrase=""1"" CodigoEscenario=""1"" />
                        </dte:Frases>
                        <dte:Items>
                          {itemsXml}
                        </dte:Items>
                        <dte:Totales>
                          <dte:TotalImpuestos>
                            <dte:TotalImpuesto NombreCorto=""IVA"" TotalMontoImpuesto=""{totalImpuesto:0.0000}"" />
                          </dte:TotalImpuestos>
                          <dte:GranTotal>{totalVenta:0.0000}</dte:GranTotal>
                        </dte:Totales>
                      </dte:DatosEmision>
                    </dte:DTE>
                    <dte:Adenda>
                      <DECertificador>{certId}</DECertificador>
                    </dte:Adenda>
                  </dte:SAT>
                </dte:GTDocumento>";

                var soapXml = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
                <SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""
                                   xmlns:ns1=""http://apicertificacion.desa.tekra.com.gt:8080/certificacion/wsdl/"">
                  <SOAP-ENV:Body>
                    <ns1:CertificacionDocumento>
                      <Autenticacion>
                        <pn_usuario>tekra_api</pn_usuario>
                        <pn_clave>123456789</pn_clave>
                        <pn_cliente>2121010001</pn_cliente>
                        <pn_contrato>2122010001</pn_contrato>
                        <pn_id_origen>TEKRA_PRUEBA</pn_id_origen>
                        <pn_ip_origen>192.168.0.100</pn_ip_origen>
                        <pn_firmar_emisor>SI</pn_firmar_emisor>
                        <pn_validar_identificador>SI</pn_validar_identificador>
                      </Autenticacion>
                      <Documento><![CDATA[{cdataContent}]]></Documento>
                    </ns1:CertificacionDocumento>
                  </SOAP-ENV:Body>
                </SOAP-ENV:Envelope>";

                using var httpClient = new HttpClient();
                var content = new StringContent(soapXml, Encoding.UTF8, "text/xml");
                var response = await httpClient.PostAsync("http://apicertificacion.desa.tekra.com.gt:8080/certificacion/servicio.php", content);
                var responseText = await response.Content.ReadAsStringAsync();

                var startTag = "<RepresentacionGrafica>";
                var endTag = "</RepresentacionGrafica>";
                var startIndex = responseText.IndexOf(startTag);
                var endIndex = responseText.IndexOf(endTag);

                if (startIndex == -1 || endIndex == -1 || endIndex <= startIndex)
                    return StatusCode(500, new { message = "No se encontró la representación gráfica (PDF) en la respuesta." });

                startIndex += startTag.Length;
                var base64Pdf = responseText.Substring(startIndex, endIndex - startIndex).Trim();
                var pdfBytes = Convert.FromBase64String(base64Pdf);

                // Guardar PDF en C:\FacturasCertificadas
                var nombreArchivo = $"venta_{venta.IdVenta}_TEKRA.pdf";
                var carpeta = @"C:\FacturasCertificadas";
                Directory.CreateDirectory(carpeta);
                var rutaArchivo = Path.Combine(carpeta, nombreArchivo);
                await System.IO.File.WriteAllBytesAsync(rutaArchivo, pdfBytes);

                // Guardar en base de datos
                var factura = new FacturasCertificadas
                {
                    IdVenta = venta.IdVenta,
                    NombreArchivo = nombreArchivo,
                    RutaArchivo = rutaArchivo,
                    FechaGeneracion = DateTime.Now
                };

                _context.FacturasCertificadas.Add(factura);
                await _context.SaveChangesAsync();

                // 📤 Mostrar el archivo en navegador
                Response.Headers["Content-Disposition"] = $"inline; filename={nombreArchivo}";
                return new FileContentResult(pdfBytes, "application/pdf");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        private async Task GuardarFacturaCertificadaAsync(int idVenta, string nombreArchivo, string rutaArchivo)
        {
            try
            {
                var factura = new FacturasCertificadas
                {
                    IdVenta = idVenta,
                    NombreArchivo = nombreArchivo,
                    RutaArchivo = rutaArchivo,
                    FechaGeneracion = DateTime.Now
                };

                _context.FacturasCertificadas.Add(factura); // _context es tu DbContext inyectado
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Puedes loguear el error o lanzar la excepción nuevamente si lo deseas
                Console.WriteLine($"Error al guardar factura certificada: {ex.Message}");
            }
        }

    }
}



    

