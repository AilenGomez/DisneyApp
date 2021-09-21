using Infraestructura.Entities;
using Infraestructura.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class PersonajeRepositories : IPersonajeRepositories 
    {
        public DisneyAppContext _context;

        public PersonajeRepositories(DisneyAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Personaje>> GetAllPersonaje(string name, int? movies, int? age)
        {
            var result =  _context.Personajes.ToList();
            if (name != null)
            {
                result = result.Where(Personaje => Personaje.Nombre == name).ToList();
            }
            if (movies != null)
            {
                result = result.Where(Personaje => Personaje.idRodaje == movies).ToList();
            }
            if (age != null)
            {
                result = result.Where(Personaje => Personaje.Edad == age).ToList();
            }
            return result;
        }

    }
}
