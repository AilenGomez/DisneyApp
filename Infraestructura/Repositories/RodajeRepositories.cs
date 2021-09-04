using Infraestructura.Entities;
using Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class RodajeRepositories : IRodajeRepositories
    {
        public DisneyAppContext _context;

        public RodajeRepositories(DisneyAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Rodaje>> GetAllRodajes(string name, int? genre, string order)
        {
            var result = _context.Rodajes.ToList();
            if (name != null)
            {
                result = result.Where(Rodaje => Rodaje.Titulo == name).ToList();
            }
            //if (genre != null)
            //{
            //    result = result.Where(Rodaje => Rodaje.idGenre == genre ).ToList();
            //}
            if (order != null)
            {
                if (order == "ASC")
                {
                    result = result.OrderBy(x => x.FechaCreacion).ToList();
                }
                else if (order == "DESC")
                {
                    result = result.OrderByDescending(x => x.FechaCreacion).ToList();
                }
                
            }
            return result;
        }

        public async Task<Rodaje> GetRodajeById(int id)
        {

            var result = _context.Rodajes.FirstOrDefault(Rodaje => Rodaje.idRodaje == id);
            return result;
        }
        public async Task CreateRodaje(Rodaje rodaje)
        {
            _context.Rodajes.Add(rodaje);
            await _context.SaveChangesAsync();

        }
        public async Task<Rodaje> UpdateRodaje(int id, Rodaje rodaje)
        {
            var currentRodaje = _context.Rodajes.Where(rod => rod.idRodaje == id).FirstOrDefault();
            currentRodaje.Titulo = rodaje.Titulo;
            currentRodaje.FechaCreacion = rodaje.FechaCreacion;
            currentRodaje.Calificacion = rodaje.Calificacion;
            await _context.SaveChangesAsync();
            return currentRodaje;
        }
        public bool DeleteRodaje(int id)
        {
            var currentRodaje = _context.Rodajes.Where(rod => rod.idRodaje == id).FirstOrDefault();
            _context.Rodajes.Remove(currentRodaje);
            int rows = _context.SaveChanges();
            return rows > 0;
        }
    }
}
