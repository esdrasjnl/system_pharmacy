using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DTO;
using AutoMapper;
using Azure;
using SistemaFarmacia.BLL.Servicios;
using SistemaFarmacia.Model;
using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.DAL.DBContext;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Previewer;
using QuestPDF.Infrastructure;


namespace SistemaFarmacia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IWebHostEnvironment _host;
      

        public CategoriaController(ICategoriaRepositorio categoriaRepositorio, IMapper mapper, DbfarmaciaContext dbContext, IWebHostEnvironment host)
        {
            _mapper = mapper;
            _categoriaRepositorio = categoriaRepositorio;
            _host = host;
            
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<CategoriaDTO>> _response = new ResponseDTO<List<CategoriaDTO>>();

            try
            {
                List<CategoriaDTO> _listaCategorias = new List<CategoriaDTO>();
                _listaCategorias = _mapper.Map<List<CategoriaDTO>>(await _categoriaRepositorio.Lista());

                if (_listaCategorias.Count > 0)
                    _response = new ResponseDTO<List<CategoriaDTO>>() { status = true, msg = "ok", value = _listaCategorias };
                else
                    _response = new ResponseDTO<List<CategoriaDTO>>() { status = false, msg = "sin resultados", value = null };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseDTO<List<CategoriaDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

       

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] CategoriaDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseDTO<CategoriaDTO> _ResponseDTO = new ResponseDTO<CategoriaDTO>();
            try
            {

               


                Categoria _categoria = _mapper.Map<Categoria>(request);

                Categoria _categoriaCreada = await _categoriaRepositorio.Crear(_categoria);




                if (_categoriaCreada.IdCategoria != 0)
                    _ResponseDTO = new ResponseDTO<CategoriaDTO>() { status = true, msg = "ok", value = _mapper.Map<CategoriaDTO>(_categoriaCreada) };
                else
                    _ResponseDTO = new ResponseDTO<CategoriaDTO>() { status = false, msg = "No se pudo crear la catgoria" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<CategoriaDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


       


        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] CategoriaDTO request)
        {
            ResponseDTO<bool> _ResponseDTO = new ResponseDTO<bool>();
            try
            {
                Categoria _categoria = _mapper.Map<Categoria>(request);
                Categoria _categoriaParaEditar = await _categoriaRepositorio.Obtener(u => u.IdCategoria == _categoria.IdCategoria);

                if (_categoriaParaEditar != null)
                {
                    _categoriaParaEditar.Descripcion = _categoria.Descripcion;
                    

                    bool respuesta = await _categoriaRepositorio.Editar(_categoriaParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<bool>() { status = true, msg = "ok", value = true };
                    else
                        _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se pudo editar la categoria" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se encontró la categoria" };
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
                Categoria _categoriaEliminar = await _categoriaRepositorio.Obtener(u => u.IdCategoria == id);

                if (_categoriaEliminar != null)
                {

                    bool respuesta = await _categoriaRepositorio.Eliminar(_categoriaEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar la categoria", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }




        [HttpGet("pdf")]
        public async Task<IActionResult> CategoriasPdf()
        {


            try
            {
                // Obtener las categorías desde el repositorio
                var categorias = await _categoriaRepositorio.Lista(); // Asumo que Lista() devuelve una lista de objetos de tipo Categoria

                // Verificar si hay categorías
                if (categorias == null || !categorias.Any())
                {
                    return NotFound(new { message = "No se encontraron categorías." });
                }

                // Generar el PDF con las categorías
                var pdf = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Margin(30);// este es un margen entre los datos y la hoja
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
                        page.Content().PaddingVertical(10)
                            .Column(column =>
                            {
                                

                                
                                column.Item().Table(tabla =>
                                {
                                    tabla.ColumnsDefinition(colums =>
                                    {
                                        colums.RelativeColumn(3);
                                        colums.RelativeColumn();
                                       

                                    });

                                tabla.Header(header => 
                                {
                                    header.Cell().Background("#257272").Padding(2).Text("ID Categoria");
                                    header.Cell().Background("#257272").Padding(2).Text("Descripcion");
                                   
                                });

                                    

                                    foreach (var categoria in categorias)
                                    {
                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(categoria.IdCategoria.ToString()).FontSize(10);

                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(categoria.Descripcion).FontSize(10);
                                       
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









        /*



        [HttpGet("pdf/{id}")]
        public async Task<IActionResult> CategoriaPdf(int id)
        {
            try
            {
                // Obtener la categoría específica desde el repositorio
                var categoria = await _categoriaRepositorio.ObtenerPorId(id); // Asumo que este método obtiene una sola categoría por su ID

                // Verificar si la categoría existe
                if (categoria == null)
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
                                col.Item().AlignCenter().Text("Codigo estudiante sac").Bold().FontSize(14);
                                col.Item().AlignCenter().Text("Chimaltenango 22-5 ").Bold().FontSize(9);
                                col.Item().AlignCenter().Text("Tel 7839-17-05").Bold().FontSize(9);
                                col.Item().AlignCenter().Text("farma@gmail.com").Bold().FontSize(9);
                            });

                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text("Codigo estudiante sac");
                                col.Item().Background("#257272").AlignCenter().Text("Chimaltenango 22-5 ").FontColor("#fff");
                                col.Item().Border(1).BorderColor("#257272").AlignCenter().Text("45646546548");
                            });
                        });

                        page.Content().PaddingVertical(10)
                            .Column(column =>
                            {
                                column.Item().Text("Datos del Cliente").Underline().Bold();

                                column.Item().Text(txt =>
                                {
                                    txt.Span("Nombre:").SemiBold().FontSize(10);
                                    txt.Span("Fredy Cumes:").FontSize(10);
                                });

                                column.Item().Text(txt =>
                                {
                                    txt.Span("DPI:").SemiBold().FontSize(10);
                                    txt.Span("251454:").FontSize(10);
                                });

                                column.Item().Text(txt =>
                                {
                                    txt.Span("Direccion :").SemiBold().FontSize(10);
                                    txt.Span("Chimaltnenago:").FontSize(10);
                                });

                                // Esta es la línea de separación
                                column.Item().LineHorizontal(0.5f);

                                // Generar la tabla con solo la categoría obtenida
                                column.Item().Table(tabla =>
                                {
                                    tabla.ColumnsDefinition(colums =>
                                    {
                                        colums.RelativeColumn(3);
                                        colums.RelativeColumn();
                                    });

                                    tabla.Header(header =>
                                    {
                                        header.Cell().Background("#257272").Padding(2).Text("ID Categoria");
                                        header.Cell().Background("#257272").Padding(2).Text("Descripcion");
                                    });

                                    // Aquí agregamos solo la categoría obtenida
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(categoria.IdCategoria.ToString()).FontSize(10);

                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(categoria.Descripcion).FontSize(10);
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

        */


    }
}
