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
        private readonly IGeneroRepositories _generoRepository;
        private readonly IMapper _mapper;

        public GeneroService(IGeneroRepositories generoRepository, IMapper mapper)
        {
            _generoRepository = generoRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GeneroDTO>> GetAllGenerosDTO()
        {
            var result = await _generoRepository.GetAllGeneros();
            var generoDTO = _mapper.Map<IEnumerable<GeneroDTO>>(result);
           return generoDTO;
        }
        public async Task<GeneroDTO> GetGeneroByIdDTO(int id)
        {
            var result = await _generoRepository.GetGeneroById(id);
            var generoDTO = _mapper.Map<GeneroDTO>(result);
            return generoDTO;
        }
        public async Task<Genero> PostGenero(GeneroDTO generoDTO)
        {
            var genero = _mapper.Map<Genero>(generoDTO);
            var result = _generoRepository.CreateGenero(genero);
            return genero;
        }
        public async Task<Genero> UpdateGenero(int id, GeneroDTO generoDTO)
        {
            var genero = _mapper.Map<Genero>(generoDTO);
            var result = _generoRepository.UpdateGenero(id, genero);
            return genero;
        }
        public bool DeleteGenero(int id)
        {
            var result = _generoRepository.DeleteGenero(id);
            return result;
        }

    }
}
