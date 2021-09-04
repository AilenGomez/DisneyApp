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
         Task<Personaje> GetPersonajeById(int id);
         Task CreatePersonaje(Personaje personaje);
         bool DeletePersonaje(int id);
         Task<Personaje> UpdatePersonaje(int id,Personaje personaje);
    }
}
