using Infraestructura.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interfaces
{
    public interface IPersonajeRepositories
    {
         Task<IEnumerable<Personaje>> GetAllPersonaje(string name, int? movies, int? age);
    }
}
