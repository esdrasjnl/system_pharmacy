using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.BLL.Servicios;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DAL.DBContext;
using SistemaFarmacia.DTO;
using SistemaFarmacia.Model;
using System.Linq.Expressions;

using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace SistemaFarmacia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductoRepositorio _productoRepositorio;
        public ProductoController(IProductoRepositorio productoRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _productoRepositorio = productoRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<ProductoDTO>> _ResponseDTO = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                List<ProductoDTO> ListaProductos = new List<ProductoDTO>();
                IQueryable<Producto> query = await _productoRepositorio.Consultar();
                query = query.Include(r => r.IdCategoriaNavigation);

                ListaProductos = _mapper.Map<List<ProductoDTO>>(query.ToList());

                if (ListaProductos.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<ProductoDTO>>() { status = true, msg = "ok", value = ListaProductos };
                else
                    _ResponseDTO = new ResponseDTO<List<ProductoDTO>>() { status = false, msg = "", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ProductoDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("ListaVenta")]
        public async Task<IActionResult> ListaVenta()
        {
            ResponseDTO<List<ProductoDTO>> _ResponseDTO = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                List<ProductoDTO> ListaProductos = new List<ProductoDTO>();
                IQueryable<Producto> query = await _productoRepositorio.ConsultarVenta();
                query = query.Include(r => r.IdCategoriaNavigation);

                ListaProductos = _mapper.Map<List<ProductoDTO>>(query.ToList());

                if (ListaProductos.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<ProductoDTO>>() { status = true, msg = "ok", value = ListaProductos };
                else
                    _ResponseDTO = new ResponseDTO<List<ProductoDTO>>() { status = false, msg = "", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ProductoDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ProductoDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseDTO<ProductoDTO> _ResponseDTO = new ResponseDTO<ProductoDTO>();
            try
            {
                Producto _producto = _mapper.Map<Producto>(request);
                
                    Producto _productoCreado = await _productoRepositorio.Crear(_producto);
                

                

                if (_productoCreado.IdProducto != 0)
                    _ResponseDTO = new ResponseDTO<ProductoDTO>() { status = true, msg = "ok", value = _mapper.Map<ProductoDTO>(_productoCreado) };
                else
                    _ResponseDTO = new ResponseDTO<ProductoDTO>() { status = false, msg = "No se pudo crear el producto" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ProductoDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO request)
        {
            ResponseDTO<bool> _ResponseDTO = new ResponseDTO<bool>();
            try
            {
                Producto _producto = _mapper.Map<Producto>(request);
                Producto _productoParaEditar = await _productoRepositorio.Obtener(u => u.IdProducto == _producto.IdProducto);

                if (_productoParaEditar != null)
                {
                    _productoParaEditar.Codigo = _producto.Codigo;
                    _productoParaEditar.Nombre = _producto.Nombre;
                    _productoParaEditar.IdCategoria = _producto.IdCategoria;
                    _productoParaEditar.Stock = _producto.Stock;
                    _productoParaEditar.Imagen = _producto.Imagen;
                    _productoParaEditar.Pcosto = _producto.Pcosto;
                    _productoParaEditar.Ppublico = _producto.Ppublico;
                    _productoParaEditar.Ptendero = _producto.Ptendero;
                    _productoParaEditar.Prutero = _producto.Prutero;
                    _productoParaEditar.Pmayorista = _producto.Pmayorista;
                    _productoParaEditar.Pespecial = _producto.Pespecial;
                    _productoParaEditar.EsActivo = _producto.EsActivo;

                    bool respuesta = await _productoRepositorio.Editar(_productoParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<bool>() { status = true, msg = "ok", value = true };
                    else
                        _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se pudo editar el producto" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se encontró el producto" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }



        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            ResponseDTO<string> _ResponseDTO = new ResponseDTO<string>();
            try
            {
                Producto _productoEliminar = await _productoRepositorio.Obtener(u => u.IdProducto == id);

                if (_productoEliminar != null)
                {

                    bool respuesta = await _productoRepositorio.Eliminar(_productoEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar el producto", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

       

        [HttpGet("productospdf")]
public async Task<IActionResult> ProductosPdf()
{
    try
    {
        // Obtener las categorías desde el repositorio
        var productos = await _productoRepositorio.Lista(); // Asumo que Lista() devuelve una lista de objetos de tipo Producto

        // Verificar si hay productos
        if (productos == null || !productos.Any())
        {
            return NotFound(new { message = "No se encontraron productos." });
        }

        // Generar el PDF con los productos
        var pdf = Document.Create(container =>
        {
            container.Page(page =>
            {
                // Establecer tamaño de página A4 en horizontal
                page.Size(842, 595);
                page.Margin(10); // Establece los márgenes de la página

                // Configuración de cabecera
                page.Header().Row(row =>
                {
                    row.ConstantItem(140).Height(60).Placeholder();

                    row.RelativeItem().Column(col =>
                    {
                        col.Item().AlignCenter().Text("Fotosa Seir").Bold().FontSize(14);
                        col.Item().AlignCenter().Text("Chimaltenango 22-5-4 ").Bold().FontSize(9);
                        col.Item().AlignCenter().Text("Tel 7839-17-05").Bold().FontSize(9);
                        col.Item().AlignCenter().Text("farma@gmail.com").Bold().FontSize(9);
                    });

                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Border(1).BorderColor("#257272").AlignCenter().Text("Fotosa Seir");
                        col.Item().Background("#257272").AlignCenter().Text("00001-254 ").FontColor("#fff");
                        col.Item().Border(1).BorderColor("#257272").AlignCenter().Text("45646546548");
                    });
                });

                // Configuración de contenido
                page.Content().PaddingVertical(10)
                    .Column(column =>
                    {
                        column.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(colums =>
                            {
                                colums.RelativeColumn();
                                colums.RelativeColumn(3);
                                colums.RelativeColumn();
                                colums.RelativeColumn();
                                colums.RelativeColumn();
                                colums.RelativeColumn();
                                colums.RelativeColumn();
                                colums.RelativeColumn();
                                colums.RelativeColumn();
                            });

                            tabla.Header(header =>
                            {
                                header.Cell().Background("#257272").Padding(2).Text("Cod");
                                header.Cell().Background("#257272").Padding(2).Text("Producto");
                                header.Cell().Background("#257272").Padding(2).Text("Cantidad");
                                header.Cell().Background("#257272").Padding(2).Text("Costo");
                                header.Cell().Background("#257272").Padding(2).Text("Publico");
                                header.Cell().Background("#257272").Padding(2).Text("Tendero");
                                header.Cell().Background("#257272").Padding(2).Text("Rutero");
                                header.Cell().Background("#257272").Padding(2).Text("Mayorista");
                                header.Cell().Background("#257272").Padding(2).Text("Especial");
                            });

                            foreach (var producto in productos)
                            {
                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).Text(producto.Codigo.ToString()).FontSize(7);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).Text(producto.Nombre).FontSize(7);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).Text(producto.Stock).FontSize(7);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).Text(producto.Pcosto).FontSize(7);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).Text(producto.Ppublico).FontSize(7);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).Text(producto.Ptendero).FontSize(7);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).Text(producto.Prutero).FontSize(7);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).Text(producto.Pmayorista).FontSize(7);

                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).Text(producto.Pespecial).FontSize(7);
                            }
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





