using Business.Dtos;
using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AppDisney.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class genreController : ControllerBase
    {
        private readonly IGeneroService _generoService;

        public genreController(IGeneroService generoService)
        {
            _generoService = generoService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _generoService.GetAllGenerosDTO();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = _generoService.GetGeneroByIdDTO(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GeneroDTO generoDTO)
        {
            var result = _generoService.PostGenero(generoDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put( GeneroDTO generoDTO)
        {
            var result = _generoService.UpdateGenero( generoDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<String> Delete(int id)
        {
            var result = _generoService.DeleteGenero(id);
            return await result == true ? "Se elimino correctamente" : "No se elimino";

        }
    }
}
