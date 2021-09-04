using AutoMapper;
using Business.Dtos;
using Business.Interfaces;
using Infraestructura.Entities;
using Infraestructura.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Servicies
{
    public class SeguridadService : ISeguridadService
    {

        private readonly ISeguridadRepositories _seguridadRepository;
        private readonly IMapper _mapper;

        public SeguridadService(ISeguridadRepositories seguridadRepository, IMapper mapper)
        {
            _seguridadRepository = seguridadRepository;
            _mapper = mapper;
        }

        public async Task<Seguridad> GetLoginByCredentials(UserLogin login)
        {
            return await _seguridadRepository.GetLoginByCredentials(login);
        }

        public async Task<Seguridad> PostSeguridad(SeguridadDTO seguridadDTO)
        {
            var seguridad = _mapper.Map<Seguridad>(seguridadDTO);
            await _seguridadRepository.CreateSeguridad(seguridad);
            return seguridad;
        }
        
        public async Task RegisterUser(SeguridadDTO seguridadDTO)
        {
            var seguridad = _mapper.Map<Seguridad>(seguridadDTO);
            var result = _seguridadRepository.CreateSeguridad(seguridad);
        }



    }
}
