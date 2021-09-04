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
    public class RodajeService : IRodajeService
    {
        private readonly IRodajeRepositories _rodajeRepository;
        private readonly IMapper _mapper;


        public RodajeService(IRodajeRepositories rodajeRepository, IMapper mapper)
        {
            _rodajeRepository = rodajeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RodajeDTO>> GetAllRodajesDTO(string name, int? genre, string order)
        {
            var result = await _rodajeRepository.GetAllRodajes(name, genre,order);
            var rodajeDTO = _mapper.Map<IEnumerable<RodajeDTO>>(result);
            return rodajeDTO;
        }
        public async Task<RodajeDTO> GetRodajeByIdDTO(int id)
        {
            var result = await _rodajeRepository.GetRodajeById(id);
            var rodajeDTO = _mapper.Map<RodajeDTO>(result);
            return rodajeDTO;
        }

        public async Task<Rodaje> PostRodaje(RodajeDTO rodajeDTO)
        {
            var rodaje = _mapper.Map<Rodaje>(rodajeDTO);
            var result = _rodajeRepository.CreateRodaje(rodaje);
            return rodaje;
        }
        public async Task<Rodaje> UpdateRodaje(int id, RodajeDTO rodajeDTO)
        {
            var rodaje = _mapper.Map<Rodaje>(rodajeDTO);
            var result = _rodajeRepository.UpdateRodaje(id, rodaje);
            return rodaje;
        }
        public bool DeleteRodaje(int id)
        {
            var result = _rodajeRepository.DeleteRodaje(id);
            return result;
        }


    }
}
