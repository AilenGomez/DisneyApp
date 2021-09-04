using Infraestructura.Entities;
using Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class GeneroRepositories : IGeneroRepositories
    {
        public DisneyAppContext _context;

        public GeneroRepositories(DisneyAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Genero>> GetAllGeneros()
        {
            var result = _context.Generos.ToList();
            return result;
        }

        public async Task<Genero> GetGeneroById(int id)
        {
            var result = _context.Generos.FirstOrDefault(Genero => Genero.Id == id);
            return result;
        }
        public async Task CreateGenero(Genero genero)
        {
            _context.Generos.Add(genero);
            await _context.SaveChangesAsync();
        }
        public async Task<Genero> UpdateGenero(int id, Genero genero)
        {
            var currentGenero = _context.Generos.Where(gen => gen.Id == id).FirstOrDefault();
            currentGenero.Nombre = genero.Nombre;
            await _context.SaveChangesAsync();
            return currentGenero;
        }
        public bool DeleteGenero(int id)
        {
            var currentGenero = _context.Generos.Where(gen => gen.Id == id).FirstOrDefault();
            _context.Generos.Remove(currentGenero);
            int rows = _context.SaveChanges();
            return rows > 0;
        }
    }
}
