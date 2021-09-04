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

        public async Task<Personaje> GetPersonajeById(int id)
        {
            var result = _context.Personajes.FirstOrDefault(Personaje => Personaje.Id == id);
            return result;
        }
        public async Task CreatePersonaje(Personaje personaje)
        {
             _context.Personajes.Add(personaje);
           await _context.SaveChangesAsync();
            
        }
        public async Task<Personaje> UpdatePersonaje(int id, Personaje personaje)
        {
            var currentPersonaje = _context.Personajes.Where(pers => pers.Id == id).FirstOrDefault();
            currentPersonaje.Nombre = personaje.Nombre;
            currentPersonaje.Edad = personaje.Edad;
            currentPersonaje.Historia = personaje.Historia;
            currentPersonaje.Peso = personaje.Peso;
            await _context.SaveChangesAsync();
            return currentPersonaje;           
        }
        public bool DeletePersonaje(int id)
        {
            var currentPersonaje = _context.Personajes.Where(pers => pers.Id == id).FirstOrDefault();
            _context.Personajes.Remove(currentPersonaje);
            int rows = _context.SaveChanges();
            return rows > 0;
        }
    }
}
