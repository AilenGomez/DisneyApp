using Infraestructura.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interfaces
{
    public interface IRodajeRepositories
    {
        public abstract Task<IEnumerable<Rodaje>> GetAllRodajes(string name, int? genre, string order);
        public abstract Task<Rodaje> GetRodajeById(int id);
        Task CreateRodaje(Rodaje rodaje);
        bool DeleteRodaje(int id);
        Task<Rodaje> UpdateRodaje(int id, Rodaje rodaje);
    }
}
