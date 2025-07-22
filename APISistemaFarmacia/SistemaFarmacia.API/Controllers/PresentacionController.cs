using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFarmacia.BLL.Servicios;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DTO;
using SistemaFarmacia.Model;

namespace SistemaFarmacia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentacionController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPresentacionRepositorio _presentacionRepositorio;

        public PresentacionController(IMapper mapper, IPresentacionRepositorio presentacionRepositorio)
        {
            _mapper = mapper;
            _presentacionRepositorio = presentacionRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            ResponseDTO<List<PresentacionDTO>> _response = new ResponseDTO<List<PresentacionDTO>>();

            try
            {
                List<PresentacionDTO> _listaPresentacion = new List<PresentacionDTO>();
                _listaPresentacion = _mapper.Map<List<PresentacionDTO>>(await _presentacionRepositorio.Lista());

                if (_listaPresentacion.Count > 0)
                    _response = new ResponseDTO<List<PresentacionDTO>>() { status = true, msg = "ok", value = _listaPresentacion };
                else
                    _response = new ResponseDTO<List<PresentacionDTO>>() { status = false, msg = "sin resultados", value = null };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new ResponseDTO<List<PresentacionDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }



        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] PresentacionDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ResponseDTO<PresentacionDTO> _ResponseDTO = new ResponseDTO<PresentacionDTO>();
            try
            {
                Presentacion _presentacion = _mapper.Map<Presentacion>(request);

                Presentacion _presentacionCreada = await _presentacionRepositorio.Crear(_presentacion);




                if (_presentacionCreada.IdPresentacion != 0)
                    _ResponseDTO = new ResponseDTO<PresentacionDTO>() { status = true, msg = "ok", value = _mapper.Map<PresentacionDTO>(_presentacionCreada) };
                else
                    _ResponseDTO = new ResponseDTO<PresentacionDTO>() { status = false, msg = "No se pudo crear la presentacion" };

                return StatusCode(StatusCodes.Status200OK, _ResponseDTO);
            }
            catch (Exception ex)
            {
                _ResponseDTO = new ResponseDTO<PresentacionDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _ResponseDTO);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] PresentacionDTO request)
        {
            ResponseDTO<bool> _ResponseDTO = new ResponseDTO<bool>();
            try
            {
                Presentacion _presentacion = _mapper.Map<Presentacion>(request);
                Presentacion _presentacionParaEditar = await _presentacionRepositorio.Obtener(u => u.IdPresentacion == _presentacion.IdPresentacion);

                if (_presentacionParaEditar != null)
                {
                    _presentacionParaEditar.Descripcion = _presentacion.Descripcion;


                    bool respuesta = await _presentacionRepositorio.Editar(_presentacionParaEditar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<bool>() { status = true, msg = "ok", value = true };
                    else
                        _ResponseDTO = new ResponseDTO<bool>() { status = false, msg = "No se pudo editar la presentacion" };
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
                Presentacion _presentacionEliminar = await _presentacionRepositorio.Obtener(u => u.IdPresentacion == id);
                if (_presentacionEliminar != null)
                {

                    bool respuesta = await _presentacionRepositorio.Eliminar(_presentacionEliminar);

                    if (respuesta)
                        _ResponseDTO = new ResponseDTO<string>() { status = true, msg = "ok", value = "" };
                    else
                        _ResponseDTO = new ResponseDTO<string>() { status = false, msg = "No se pudo eliminar la Presentacion", value = "" };
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
