using Infraestructura.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interfaces
{
    public interface IGeneroRepositories
    {
        public abstract Task<IEnumerable<Genero>> GetAllGeneros();
        public abstract Task<Genero> GetGeneroById(int id);
        Task CreateGenero(Genero genero);
        bool DeleteGenero(int id);
        Task<Genero> UpdateGenero(int id, Genero genero);
    }
}
