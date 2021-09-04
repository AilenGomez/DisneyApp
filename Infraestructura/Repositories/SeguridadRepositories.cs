using Infraestructura.Entities;
using Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositories
{
    public class SeguridadRepositories : ISeguridadRepositories
    {
        public DisneyAppContext _context;
        public SeguridadRepositories(DisneyAppContext context)
        {
            _context = context;
        }

        public async Task<Seguridad> GetLoginByCredentials(UserLogin login)
        {
            return _context.Seguridades.FirstOrDefault(x => x.User == login.Usuario && x.Password == login.Contraseña);
        }
        public async Task CreateSeguridad(Seguridad seguridad)
        {
            _context.Seguridades.Add(seguridad);
            await _context.SaveChangesAsync();
        }
    }
}
