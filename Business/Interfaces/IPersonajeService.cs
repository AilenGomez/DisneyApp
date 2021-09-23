using Business.Dtos;
using Business.QueryFilters;
using Infraestructura.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPersonajeService
    {
        Task<IEnumerable<PersonajeDTO>> GetAllPersonajeDTO(CharactersQueryFilter filters);
        Task<PersonajeDTO> GetPersonajeByIdDTO(int id);
        Task<Personaje> PostPersonaje(PersonajeDTO personajeDTO);
        Task<Personaje> UpdatePersonaje(int id, PersonajeDTO personajeDTO);
        Task<bool> DeletePersonaje(int id);
    }
}
