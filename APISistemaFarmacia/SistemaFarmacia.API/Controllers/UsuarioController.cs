using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.BLL.Servicios;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DTO;
using SistemaFarmacia.Model;

using QuestPDF.Fluent;

namespace SistemaFarmacia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<UsuarioDTO>> _ResponseDTO = new ResponseDTO<List<UsuarioDTO>>();

            try
            {
                List<UsuarioDTO> ListaUsuarios = new List<UsuarioDTO>();
                IQueryable<Usuario> query = await _usuarioRepositorio.Consultar();
                query = query.Include(r => r.IdRolNavigation);

                ListaUsuarios = _mapper.Map<List<UsuarioDTO>>(query.ToList());

                if (ListaUsuarios.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<UsuarioDTO>>() { status = true, msg = "ok", value = ListaUsuarios };
                else
                    _ResponseDTO = new ResponseDTO<List<UsuarioDTO>>() { status = false, msg = "", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<UsuarioDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpGet]
        [Route("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            ResponseDTO<UsuarioDTO> _ResponseDTO = new ResponseDTO<UsuarioDTO>();
            try
            {
                UsuarioDTO _usuario = new UsuarioDTO();
                IQueryable<Usuario> query = await _usuarioRepositorio.Consultar(u => u.Correo == correo && u.Clave == clave);
                query = query.Include(r => r.IdRolNavigation);

                _usuario = _mapper.Map<UsuarioDTO>(query.FirstOrDefault());

                if (_usuario != null)
                    _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = true, msg = "ok", value = _usuario };
                else
                    _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = "no encontrado", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);

            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }



            /*
            ResponseDTO<Usuario> _ResponseDTO = new ResponseDTO<Usuario>();
            try
            {
                Usuario _usuario = await _usuarioRepositorio.Obtener(u => u.Correo == correo && u.Clave == clave);

                if (_usuario != null)
                    _ResponseDTO = new ResponseDTO<Usuario>() { status = true, msg = "ok", value = _usuario };
                else
                    _ResponseDTO = new ResponseDTO<Usuario>() { status = false, msg = "no encontrado", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<Usuario>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
            */
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] UsuarioDTO request)
        {
            ResponseDTO<UsuarioDTO> _ResponseDTO = new ResponseDTO<UsuarioDTO>();
            try
            {
                Usuario _usuario = _mapper.Map<Usuario>(request);

                Usuario _usuarioCreado = await _usuarioRepositorio.Crear(_usuario);

                if (_usuarioCreado.IdUsuario != 0)
                    _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = true, msg = "ok", value = _mapper.Map<UsuarioDTO>(_usuarioCreado) };
                else
                    _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = "No se pudo crear el usuario" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO request)
        {
            ResponseDTO<UsuarioDTO> _ResponseDTO = new ResponseDTO<UsuarioDTO>();
            try
            {
                Usuario _usuario = _mapper.Map<Usuario>(request);
                Usuario _usuarioParaEditar = await _usuarioRepositorio.Obtener(u => u.IdUsuario == _usuario.IdUsuario);

                if (_usuarioParaEditar != null)
                {

                    _usuarioParaEditar.NombreApellidos = _usuario.NombreApellidos;
                    _usuarioParaEditar.Correo = _usuario.Correo;
                    _usuarioParaEditar.IdRol = _usuario.IdRol;
                    _usuarioParaEditar.Clave = _usuario.Clave;

                    bool respuesta = await _usuarioRepositorio.Editar(_usuarioParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = true, msg = "ok", value = _mapper.Map<UsuarioDTO>(_usuarioParaEditar) };
                    else
                        _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = "No se pudo editar el usuario" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = "No se encontró el usuario" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<UsuarioDTO>() { status = false, msg = ex.Message };
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
                Usuario _usuarioEliminar = await _usuarioRepositorio.Obtener(u => u.IdUsuario == id);

                if (_usuarioEliminar != null)
                {

                    bool respuesta = await _usuarioRepositorio.Eliminar(_usuarioEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar el usuario", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpGet("usuariospdf")]
        public async Task<IActionResult> UsuariosPdf()
        {


            try
            {
                // Obtener las categorías desde el repositorio
                var usuarios = await _usuarioRepositorio.Lista(); // Asumo que Lista() devuelve una lista de objetos de tipo Categoria

                // Verificar si hay categorías
                if (usuarios == null || !usuarios.Any())
                {
                    return NotFound(new { message = "No se encontraron usuarios." });
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
                                        colums.RelativeColumn();
                                        colums.RelativeColumn();
                                        colums.RelativeColumn();


                                    });

                                    tabla.Header(header =>
                                    {
                                        header.Cell().Background("#257272").Padding(2).Text("ID Categoria");
                                        header.Cell().Background("#257272").Padding(2).Text("Cliente");
                                        header.Cell().Background("#257272").Padding(2).Text("Rol");

                                    });



                                    foreach (var usuario in usuarios)
                                    {
                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(usuario.IdUsuario.ToString()).FontSize(10);

                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(usuario.NombreApellidos).FontSize(10);

                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(usuario.IdRolNavigation).FontSize(10);

                                        
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
