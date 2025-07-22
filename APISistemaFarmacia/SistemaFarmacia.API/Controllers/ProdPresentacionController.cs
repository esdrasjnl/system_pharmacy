using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DTO;
using SistemaFarmacia.Model;

namespace SistemaFarmacia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdPresentacionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProdpresentacionRepositorio _prodpresentacionRepositorio;

        public ProdPresentacionController(IMapper mapper, IProdpresentacionRepositorio prodpresentacionRepositorio)
        {
            _mapper = mapper;
            _prodpresentacionRepositorio = prodpresentacionRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<ProdpresentacionDTO>> _ResponseDTO = new ResponseDTO<List<ProdpresentacionDTO>>();

            try
            {
                List<ProdpresentacionDTO> ListaProductos = new List<ProdpresentacionDTO>();
                IQueryable<Prodpresentacion> query = await _prodpresentacionRepositorio.Consultar();
                query = query.Include(r => r.IdPresentacionNavigation);

                ListaProductos = _mapper.Map<List<ProdpresentacionDTO>>(query.ToList());

                if (ListaProductos.Count > 0)
                    _ResponseDTO = new ResponseDTO<List<ProdpresentacionDTO>>() { status = true, msg = "ok", value = ListaProductos };
                else
                    _ResponseDTO = new ResponseDTO<List<ProdpresentacionDTO>>() { status = false, msg = "", value = null };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<List<ProdpresentacionDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ProdpresentacionDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseDTO<ProdpresentacionDTO> _ResponseDTO = new ResponseDTO<ProdpresentacionDTO>();
            try
            {
                Prodpresentacion _producto = _mapper.Map<Prodpresentacion>(request);

                Prodpresentacion _productoCreado = await _prodpresentacionRepositorio.Crear(_producto);




                if (_productoCreado.IdProducto != 0)
                    _ResponseDTO = new ResponseDTO<ProdpresentacionDTO>() { status = true, msg = "ok", value = _mapper.Map<ProdpresentacionDTO>(_productoCreado) };
                else
                    _ResponseDTO = new ResponseDTO<ProdpresentacionDTO>() { status = false, msg = "No se pudo crear el producto" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<ProdpresentacionDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProdpresentacionDTO request)
        {
            ResponseDTO<bool> _ResponseDTO = new ResponseDTO<bool>();
            try
            {
                Prodpresentacion _producto = _mapper.Map<Prodpresentacion>(request);
                Prodpresentacion _productoParaEditar = await _prodpresentacionRepositorio.Obtener(u => u.IdProdpresentacion == _producto.IdProdpresentacion);

                if (_productoParaEditar != null)
                {
                    _productoParaEditar.IdProducto = _producto.IdProducto;
                    _productoParaEditar.IdPresentacion = _producto.IdPresentacion;
                    _productoParaEditar.Cantidad = _producto.Cantidad;
                    

                    bool respuesta = await _prodpresentacionRepositorio.Editar(_productoParaEditar);

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
                Prodpresentacion _productoEliminar = await _prodpresentacionRepositorio.Obtener(u => u.IdProdpresentacion == id);

                if (_productoEliminar != null)
                {

                    bool respuesta = await _prodpresentacionRepositorio.Eliminar(_productoEliminar);

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
    }
}
