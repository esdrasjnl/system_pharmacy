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
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IMapper mapper, IClienteRepositorio clienteRepositorio)
        {
            _mapper = mapper;
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<ClienteDTO>> _ResponseDTO = new ResponseDTO<List<ClienteDTO>>();

            try
            {
                List<ClienteDTO> ListaClientes = new List<ClienteDTO>();
                IQueryable<Cliente> query = await _clienteRepositorio.Consultar();


                ListaClientes = _mapper.Map<List<ClienteDTO>>(query.ToList());

                if (ListaClientes.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<ClienteDTO>>() { status = true, msg = "ok", value = ListaClientes };
                else
                    _ResponseDTO = new ResponseDTO<List<ClienteDTO>>() { status = false, msg = "", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ClienteDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

       

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ClienteDTO request)
        {
            ResponseDTO<ClienteDTO> _ResponseDTO = new ResponseDTO<ClienteDTO>();
            try
            {
                Cliente _ciente = _mapper.Map<Cliente>(request);

                Cliente _clienteCreado = await _clienteRepositorio.Crear(_ciente);

                if (_clienteCreado.IdCliente != 0)
                    _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = true, msg = "ok", value = _mapper.Map<ClienteDTO>(_clienteCreado) };
                else
                    _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = false, msg = "No se pudo crear el usuario" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ClienteDTO request)
        {
            ResponseDTO<ClienteDTO> _ResponseDTO = new ResponseDTO<ClienteDTO>();
            try
            {
                Cliente _cliente = _mapper.Map<Cliente>(request);
                Cliente _clienteParaEditar = await _clienteRepositorio.Obtener(u => u.IdCliente == _cliente.IdCliente);

                if (_clienteParaEditar != null)
                {

                    _clienteParaEditar.NombreCompleto = _cliente.NombreCompleto;
                    _clienteParaEditar.Nit = _cliente.Nit;
                    _clienteParaEditar.Direccion = _cliente.Direccion;
                    _clienteParaEditar.Telefono = _cliente.Telefono;
                    _clienteParaEditar.TipoCliente = _cliente.TipoCliente;
                    _clienteParaEditar.Observaciones = _cliente.Observaciones;


                    bool respuesta = await _clienteRepositorio.Editar(_clienteParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = true, msg = "ok", value = _mapper.Map<ClienteDTO>(_clienteParaEditar) };
                    else
                        _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = false, msg = "No se pudo editar el cliente" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = false, msg = "No se encontró el cliente" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ClienteDTO>() { status = false, msg = ex.Message };
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
                Cliente _clienteEliminar = await _clienteRepositorio.Obtener(u => u.IdCliente == id);

                if (_clienteEliminar != null)
                {

                    bool respuesta = await _clienteRepositorio.Eliminar(_clienteEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar el cliente", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpGet("clientespdf")]
        public async Task<IActionResult> ClientesPdf()
        {


            try
            {
                // Obtener las categorías desde el repositorio
                var clientes = await _clienteRepositorio.Lista(); // Asumo que Lista() devuelve una lista de objetos de tipo Categoria

                // Verificar si hay categorías
                if (clientes == null || !clientes.Any())
                {
                    return NotFound(new { message = "No se encontraron clientes." });
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
                                        colums.RelativeColumn();
                                        colums.RelativeColumn();


                                    });

                                    tabla.Header(header =>
                                    {
                                        header.Cell().Background("#257272").Padding(2).Text("ID Cliente");
                                        header.Cell().Background("#257272").Padding(2).Text("Cliente");
                                        header.Cell().Background("#257272").Padding(2).Text("Nit");
                                        header.Cell().Background("#257272").Padding(2).Text("Telefono");
                                        header.Cell().Background("#257272").Padding(2).Text("Tipo Cliente");

                                    });



                                    foreach (var cliente in clientes)
                                    {
                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(cliente.IdCliente.ToString()).FontSize(10);

                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(cliente.NombreCompleto).FontSize(10);

                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(cliente.Nit).FontSize(10);

                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(cliente.Telefono).FontSize(10);

                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(cliente.TipoCliente).FontSize(10);

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
