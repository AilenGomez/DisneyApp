using AutoMapper;
using Business.CustomEntities;
using Business.Dtos;
using Business.Interfaces;
using Business.QueryFilters;
using Infraestructura.Entities;
using Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Servicies
{
    public class PersonajeService : IPersonajeService
    {
        private readonly IRepository<Personaje> _personajeRepository;
        private readonly IMapper _mapper;

        public PersonajeService(IRepository<Personaje> personajeRepository, IMapper mapper)
        {
            _personajeRepository = personajeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PersonajeDTO>> GetAllPersonajeDTO(CharactersQueryFilter filters)
        {
            var result = await _personajeRepository.GetAll();
            if (filters.name != null)
            {
                result = result.Where(Personaje => Personaje.Nombre == filters.name).ToList();
            }
            if (filters.movies != null)
            {
                result = result.Where(Personaje => Personaje.idRodaje == filters.movies).ToList();
            }
            if (filters.age != null)
            {
                result = result.Where(Personaje => Personaje.Edad == filters.age).ToList();
            }
            var pagedPersonajes = PagedList<Personaje>.Create(result, filters.pageNumber, filters.pageSize);
            var personajesDTO = _mapper.Map<IEnumerable<PersonajeDTO>>(pagedPersonajes);
            return personajesDTO;
        }
        public async Task<PersonajeDTO> GetPersonajeByIdDTO(int id)
        {
            var result = await _personajeRepository.GetById(id);
            var personajeDTO = _mapper.Map<PersonajeDTO>(result);
            return personajeDTO;
        }

        public async Task<Personaje> PostPersonaje(PersonajeDTO personajeDTO)
        {
            var personaje = _mapper.Map<Personaje>(personajeDTO);
            var result= _personajeRepository.Create(personaje);
            return personaje;
         }
        public async Task<Personaje> UpdatePersonaje(int id, PersonajeDTO personajeDTO)
        {
            var personaje = _mapper.Map<Personaje>(personajeDTO);
            personaje.id = id;
            var result = _personajeRepository.Update(personaje);
            return personaje;
        }
        public Task<bool> DeletePersonaje(int id)
        {
            var result = _personajeRepository.Delete(id);
            return result;
        }

    }
}
