using AutoMapper;
using Business.Dtos;
using Business.Interfaces;
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
        private readonly IPersonajeRepositories _personajesRepository;
        private readonly IMapper _mapper;

        public PersonajeService(IRepository<Personaje> personajeRepository, IMapper mapper, IPersonajeRepositories personajesRepositories)
        {
            _personajeRepository = personajeRepository;
            _personajesRepository = personajesRepositories;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PersonajeDTO>> GetAllPersonajeDTO(string name, int? movie, int? age)
        {
            var result = await _personajesRepository.GetAllPersonaje(name, movie, age);
            var personajesDTO = _mapper.Map<IEnumerable<PersonajeDTO>>(result);
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
