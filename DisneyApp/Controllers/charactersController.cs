using Business.Dtos;
using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AppDisney.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]

   
    public class charactersController : ControllerBase
    {
        private readonly IPersonajeService _personajeService;

        public charactersController(IPersonajeService personajeService)
        {
            _personajeService = personajeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string name, int? movie, int? age)
        {
            var result = await _personajeService.GetAllPersonajeDTO(name, movie, age);
            return Ok(result);
        }
     
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = _personajeService.GetPersonajeByIdDTO(id);
            return Ok(result);
        }
      
        [HttpPost]
        public async Task<IActionResult> Post(PersonajeDTO personajeDTO)
        {
            var result = _personajeService.PostPersonaje(personajeDTO);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,PersonajeDTO personajeDTO)
        {
            var result = _personajeService.UpdatePersonaje( id, personajeDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<String> Delete(int id)
        {
            var result = await _personajeService.DeletePersonaje(id);
            return result == true ? "Se elimino correctamente" : "No se elimino";            
        }
    }
}
