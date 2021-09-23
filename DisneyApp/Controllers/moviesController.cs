using Business.Dtos;
using Business.Interfaces;
using Business.QueryFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace AppDisney.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class moviesController : ControllerBase
    {
        private readonly IRodajeService _rodajeService;

        public moviesController(IRodajeService rodajeService)
        {
            _rodajeService = rodajeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] MovieQueryFilter filters)
        {
            var result = await _rodajeService.GetAllRodajesDTO(filters);
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _rodajeService.GetRodajeByIdDTO(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RodajeDTO rodajeDTO)
        {
            var result = _rodajeService.PostRodaje(rodajeDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,RodajeDTO rodajeDTO)
        {
            var result = _rodajeService.UpdateRodaje(id, rodajeDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<String> Delete(int id)
        {
            var result = _rodajeService.DeleteRodaje(id);
            return await result == true ? "Se elimino correctamente" : "No se elimino";

        }
    }
}
