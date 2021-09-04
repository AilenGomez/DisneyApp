using Business.Dtos;
using Infraestructura.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPersonajeService
    {
        Task<IEnumerable<PersonajeDTO>> GetAllPersonajeDTO(string name, int? movie, int? age);
        Task<PersonajeDTO> GetPersonajeByIdDTO(int id);
        Task<Personaje> PostPersonaje(PersonajeDTO personajeDTO);
        Task<Personaje> UpdatePersonaje(int id, PersonajeDTO personajeDTO);
        bool DeletePersonaje(int id);
    }
}
