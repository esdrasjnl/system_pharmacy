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
    public class ProveedorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProveedorRepositorio _proveedorRepositorio;

        public ProveedorController(IMapper mapper, IProveedorRepositorio proveedorRepositorio)
        {
            _mapper = mapper;
            _proveedorRepositorio = proveedorRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<ProveedorDTO>> _ResponseDTO = new ResponseDTO<List<ProveedorDTO>>();

            try
            {
                List<ProveedorDTO> ListaClientes = new List<ProveedorDTO>();
                IQueryable<Proveedor> query = await _proveedorRepositorio.Consultar();


                ListaClientes = _mapper.Map<List<ProveedorDTO>>(query.ToList());

                if (ListaClientes.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<ProveedorDTO>>() { status = true, msg = "ok", value = ListaClientes };
                else
                    _ResponseDTO = new ResponseDTO<List<ProveedorDTO>>() { status = false, msg = "", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ProveedorDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }



        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ProveedorDTO request)
        {
            ResponseDTO<ProveedorDTO> _ResponseDTO = new ResponseDTO<ProveedorDTO>();
            try
            {
                Proveedor _ciente = _mapper.Map<Proveedor>(request);

                Proveedor _clienteCreado = await _proveedorRepositorio.Crear(_ciente);

                if (_clienteCreado.IdProveedor != 0)
                    _ResponseDTO = new ResponseDTO<ProveedorDTO>() { status = true, msg = "ok", value = _mapper.Map<ProveedorDTO>(_clienteCreado) };
                else
                    _ResponseDTO = new ResponseDTO<ProveedorDTO>() { status = false, msg = "No se pudo crear el usuario" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ProveedorDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProveedorDTO request)
        {
            ResponseDTO<ProveedorDTO> _ResponseDTO = new ResponseDTO<ProveedorDTO>();
            try
            {
                Proveedor _cliente = _mapper.Map<Proveedor>(request);
                Proveedor _clienteParaEditar = await _proveedorRepositorio.Obtener(u => u.IdProveedor == _cliente.IdProveedor);

                if (_clienteParaEditar != null)
                {

                    _clienteParaEditar.Nombre = _cliente.Nombre;
                    _clienteParaEditar.Nit = _cliente.Nit;
                    _clienteParaEditar.Direccion = _cliente.Direccion;
                    _clienteParaEditar.Telefono = _cliente.Telefono;
                    _clienteParaEditar.Celular = _cliente.Celular;
                    _clienteParaEditar.Cuenta = _cliente.Cuenta;


                    bool respuesta = await _proveedorRepositorio.Editar(_clienteParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<ProveedorDTO>() { status = true, msg = "ok", value = _mapper.Map<ProveedorDTO>(_clienteParaEditar) };
                    else
                        _ResponseDTO = new ResponseDTO<ProveedorDTO>() { status = false, msg = "No se pudo editar el cliente" };
                }
                else
                {
                    _ResponseDTO = new ResponseDTO<ProveedorDTO>() { status = false, msg = "No se encontró el cliente" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ProveedorDTO>() { status = false, msg = ex.Message };
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
                Proveedor _clienteEliminar = await _proveedorRepositorio.Obtener(u => u.IdProveedor == id);
                if (_clienteEliminar != null)
                {

                    bool respuesta = await _proveedorRepositorio.Eliminar(_clienteEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar el proveedor", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpGet("proveedorespdf")]
        public async Task<IActionResult> ProveedoresPdf()
        {


            try
            {
                // Obtener las categorías desde el repositorio
                var proveedores = await _proveedorRepositorio.Lista(); // Asumo que Lista() devuelve una lista de objetos de tipo Categoria

                // Verificar si hay categorías
                if (proveedores == null || !proveedores.Any())
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
                                        colums.RelativeColumn();
                                        colums.RelativeColumn();
                                        colums.RelativeColumn();
                                        colums.RelativeColumn();
                                        colums.RelativeColumn();


                                    });

                                    tabla.Header(header =>
                                    {
                                        header.Cell().Background("#257272").Padding(2).Text("ID Proveedor");
                                        header.Cell().Background("#257272").Padding(2).Text("Proveedor");
                                        header.Cell().Background("#257272").Padding(2).Text("Nit");
                                        header.Cell().Background("#257272").Padding(2).Text("Direccion");
                                        header.Cell().Background("#257272").Padding(2).Text("Telefono");

                                    });



                                    foreach (var proveedor in proveedores)
                                    {
                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(proveedor.IdProveedor.ToString()).FontSize(10);

                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(proveedor.Nombre).FontSize(10);

                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(proveedor.Nit).FontSize(10);

                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(proveedor.Direccion).FontSize(10);

                                        tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                        .Padding(2).Text(proveedor.Telefono).FontSize(10);

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
