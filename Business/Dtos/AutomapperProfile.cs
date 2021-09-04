using AutoMapper;
using Infraestructura.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Genero, GeneroDTO>(); // GET
            CreateMap<GeneroDTO, Genero>();//POST, PUT

            CreateMap<Personaje,PersonajeDTO>(); 
            CreateMap<PersonajeDTO,Personaje>();

            CreateMap<Rodaje,RodajeDTO>(); 
            CreateMap<RodajeDTO, Rodaje>();

            CreateMap<SeguridadDTO, Seguridad>().ReverseMap();

        }
    }
}
