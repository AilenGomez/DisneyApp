using Infraestructura.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Interfaces
{
    public interface ISeguridadRepositories
    {
        public Task<Seguridad> GetLoginByCredentials(UserLogin login);
        public Task CreateSeguridad(Seguridad seguridad);
    }
}
