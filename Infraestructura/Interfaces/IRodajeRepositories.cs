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
        Task<IEnumerable<Rodaje>> GetAllRodajes(string name, int? genre, string order);
     }
}
