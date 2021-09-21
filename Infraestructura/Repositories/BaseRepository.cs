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
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DisneyAppContext _context;
        private readonly DbSet<T> _entities;
        public BaseRepository(DisneyAppContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return _entities.ToList();
        }
        public async Task<T> GetById(int id)
        {
           return  _entities.Find(id);
        }
        public async Task Create(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }
        public async Task<bool> Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
            int rows = _context.SaveChanges();
            return rows > 0;
        }   
        public async Task Update( T entity)
        {
            _entities.Attach(entity);
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            
        }
    }
}
