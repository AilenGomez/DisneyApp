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
    public class GeneroService : IGeneroService
    {
        private readonly IRepository<Genero> _generoRepository;
        private readonly IMapper _mapper;

        public GeneroService(IRepository<Genero> generoRepository, IMapper mapper)
        {
            _generoRepository = generoRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GeneroDTO>> GetAllGenerosDTO()
        {
            var result = await _generoRepository.GetAll();
            var generoDTO = _mapper.Map<IEnumerable<GeneroDTO>>(result);
           return generoDTO;
        }
        public async Task<GeneroDTO> GetGeneroByIdDTO(int id)
        {
            var result = await _generoRepository.GetById(id);
            var generoDTO = _mapper.Map<GeneroDTO>(result);
            return generoDTO;
        }
        public async Task<Genero> PostGenero(GeneroDTO generoDTO)
        {
            var genero = _mapper.Map<Genero>(generoDTO);
            var result = _generoRepository.Create(genero);
            return genero;
        }
        public async Task<Genero> UpdateGenero(int id, GeneroDTO generoDTO)
        {
            var genero = _mapper.Map<Genero>(generoDTO);
            genero.id = id;
            var result = _generoRepository.Update(genero);
            return genero;
        }
        public Task<bool> DeleteGenero(int id)
        {
            var result = _generoRepository.Delete(id);
            return result;
        }

    }
}
