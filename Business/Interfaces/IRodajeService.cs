using Business.Dtos;
using Infraestructura.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRodajeService
    {
        public Task<IEnumerable<RodajeDTO>> GetAllRodajesDTO(string name, int? genre, string order);
        public Task<RodajeDTO> GetRodajeByIdDTO(int id);
        Task<Rodaje> PostRodaje(RodajeDTO rodajeDTO);
        Task<Rodaje> UpdateRodaje(int id, RodajeDTO rodajeDTO);
        bool DeleteRodaje(int id);
    }
}
