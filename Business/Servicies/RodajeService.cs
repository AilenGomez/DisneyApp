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
    public class RodajeService : IRodajeService
    {
        private readonly IRepository<Rodaje> _rodajeRepository;
        private readonly IMapper _mapper;


        public RodajeService(IMapper mapper, IRepository<Rodaje> rodajeRepository)
        {
            _rodajeRepository = rodajeRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RodajeDTO>> GetAllRodajesDTO(MovieQueryFilter filters)
        {
            var result = await _rodajeRepository.GetAll();
            if (filters.name != null)
            {
                result = result.Where(Rodaje => Rodaje.Titulo == filters.name).ToList();
            }
            if (filters.order != null)
            {
                if (filters.order == "ASC")
                {
                    result = result.OrderBy(x => x.FechaCreacion).ToList();
                }
                else if (filters.order == "DESC")
                {
                    result = result.OrderByDescending(x => x.FechaCreacion).ToList();
                }

            }
            var pagedRodaje = PagedList<Rodaje>.Create(result, filters.pageNumber, filters.pageSize);
            var rodajeDTO = _mapper.Map<IEnumerable<RodajeDTO>>(pagedRodaje);
            return rodajeDTO;
        }
        public async Task<RodajeDTO> GetRodajeByIdDTO(int id)
        {
            var result = await _rodajeRepository.GetById(id);
            var rodajeDTO = _mapper.Map<RodajeDTO>(result);
            return rodajeDTO;
        }

        public async Task<Rodaje> PostRodaje(RodajeDTO rodajeDTO)
        {
            var rodaje = _mapper.Map<Rodaje>(rodajeDTO);
            var result = _rodajeRepository.Create(rodaje);
            return rodaje;
        }
        public async Task<Rodaje> UpdateRodaje(int id,RodajeDTO rodajeDTO)
        {
            var rodaje = _mapper.Map<Rodaje>(rodajeDTO);
            rodaje.id = id;
            var result = _rodajeRepository.Update(rodaje);
            return rodaje;
        }
        public Task<bool> DeleteRodaje(int id)
        {
            var result = _rodajeRepository.Delete(id);
            return result;
        }


    }
}
