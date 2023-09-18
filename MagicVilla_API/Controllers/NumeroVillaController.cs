using AutoMapper;
using MagicVilla_API.Datos;
using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.DTO;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeroVillaController : ControllerBase
    {
        private readonly ILogger<NumeroVillaController> _logger;
        //private readonly ApplicationDbContext _db;
        private readonly IVillaRepositorio _villaRepo;
        private readonly INumeroVillaRepositorio _numeroRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;


        public NumeroVillaController(ILogger<NumeroVillaController> logger, IVillaRepositorio villaRepo, INumeroVillaRepositorio numeroRepo, IMapper mapper)
        {

            _logger = logger;
            //_db = db;
            _villaRepo = villaRepo;
            _mapper = mapper;
            _response = new();
            _numeroRepo = numeroRepo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetNumeroVillas() {
            try
            {
                _logger.LogInformation("GetNumeroVillas...");

                IEnumerable<NumeroVilla> numeroVillaLista = await _numeroRepo.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<NumeroVillaDto>>(numeroVillaLista);
                _response.statusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch(Exception ex) {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpGet("id", Name = "GetNumeroVilla")]
        [ProducesResponseType(200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetNumeroVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogInformation("Error al traer NumeroVilla ID " + id);
                    _response.isExitoso = false;
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                //var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
                var numeroVilla = await _numeroRepo.Obtener(v => v.VillaNo == id);

                if (numeroVilla == null)
                {
                    _response.isExitoso = false;
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Resultado = _mapper.Map<NumeroVillaDto>(numeroVilla);
                _response.statusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CrearNumeroVilla([FromBody] NumeroVillaCreateDto createDto) {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (await _numeroRepo.Obtener(v => v.VillaNo == createDto.VillaNo) != null)
                {
                    ModelState.AddModelError("NombreExiste", "El numero villa ya existe");
                    return BadRequest(ModelState);
                }

                if (await _villaRepo.Obtener(v => v.Id == createDto.VillaId) == null) {
                    ModelState.AddModelError("ClaveForanea", "El id de la villa no existe");
                    return BadRequest(ModelState);
                }

                if (createDto == null)
                {
                    return BadRequest(createDto);
                }

                //Genera ID
                //villaDto.Id = VillaStore.villaList.OrderByDescending(v => v.Id).FirstOrDefault().Id + 1;
                //VillaStore.villaList.Add(villaDto);

                NumeroVilla modelo = _mapper.Map<NumeroVilla>(createDto);

                modelo.FechaCreacion = DateTime.Now;
                modelo.FechaActualizacion = DateTime.Now;

                /*
                Villa modelo = new()
                {
                    Nombre = villaDto.Nombre,
                    Detalle = villaDto.Detalle,
                    ImagenUrl = villaDto.ImagenUrl,
                    Ocupantes = villaDto.Ocupantes,
                    Amenidad = villaDto.Amenidad,
                    Tarifa = villaDto.Tarifa,
                    MetrosCuadrados = villaDto.MetrosCuadrados
                };
                */

                await _numeroRepo.Crear(modelo);
                //await _db.SaveChangesAsync();

                _response.Resultado = modelo;
                _response.statusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetNumeroVilla", new { id = modelo.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteNumeroVilla(int id) {

            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var numeroVilla = await _numeroRepo.Obtener(v => v.VillaNo == id);

                if (numeroVilla == null)
                {
                    _response.isExitoso = false;
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                //VillaStore.villaList.Remove(villa);
                await _numeroRepo.Remover(numeroVilla);

                _response.statusCode = HttpStatusCode.NoContent;
                return Ok(_response);
                //await _db.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return BadRequest(_response);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateNumeroVilla(int id, [FromBody] NumeroVillaUpdateDto updateDto) {

            if (updateDto == null || id != updateDto.VillaNo) {
                _response.isExitoso = false;
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            if (await _villaRepo.Obtener(v => v.Id == updateDto.VillaId) == null)
            {
                ModelState.AddModelError("ClaveForanea", "El id de la villa no existe");
                return BadRequest(ModelState);
            }

            /*
            var villa = VillaStore.villaList.FirstOrDefault(v => v.Id == id);
            villa.Nombre = villaDto.Nombre;
            villa.Ocupantes = villaDto.Ocupantes;
            villa.MetrosCuadrados = villaDto.MetrosCuadrados;
            */

            NumeroVilla modelo = _mapper.Map<NumeroVilla>(updateDto);

            /*
            Villa modelo = new()
            {
                Id = villaDto.Id,
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Detalle,
                ImagenUrl = villaDto.ImagenUrl,
                Ocupantes = villaDto.Ocupantes,
                Amenidad = villaDto.Amenidad,
                Tarifa = villaDto.Tarifa,
                MetrosCuadrados = villaDto.MetrosCuadrados
            };
            */

            await _numeroRepo.Actualizar(modelo);
            //await _db.SaveChangesAsync();

            _response.statusCode = HttpStatusCode.NoContent;

            return Ok(_response);
        }

       

    }
}
