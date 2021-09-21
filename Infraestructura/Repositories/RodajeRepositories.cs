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

       
    }
}
