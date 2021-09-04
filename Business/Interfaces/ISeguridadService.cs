using Business.Dtos;
using Infraestructura.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ISeguridadService
    {
         Task<Seguridad> GetLoginByCredentials(UserLogin login);

         Task RegisterUser(SeguridadDTO seguridadDTO);
        Task<Seguridad> PostSeguridad(SeguridadDTO seguridadDTO);
    }
}
