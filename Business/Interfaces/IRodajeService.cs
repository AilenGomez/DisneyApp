using Business.Dtos;
using Business.QueryFilters;
using Infraestructura.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRodajeService
    {
        public Task<IEnumerable<RodajeDTO>> GetAllRodajesDTO(MovieQueryFilter filters);
        public Task<RodajeDTO> GetRodajeByIdDTO(int id);
        Task<Rodaje> PostRodaje(RodajeDTO rodajeDTO);
        Task<Rodaje> UpdateRodaje(int id, RodajeDTO rodajeDTO);
        Task<bool> DeleteRodaje(int id);
    }
}
