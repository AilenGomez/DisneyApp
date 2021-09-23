﻿using Business.Dtos;
using Business.QueryFilters;
using Infraestructura.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IGeneroService
    {
        public Task<IEnumerable<GeneroDTO>> GetAllGenerosDTO(GenreQueryFilter filters);
        public Task<GeneroDTO> GetGeneroByIdDTO(int id);
        Task<Genero> PostGenero(GeneroDTO generoDTO);
        Task<Genero> UpdateGenero(int id,GeneroDTO generoDTO);
        Task<bool> DeleteGenero(int id);
    }
}
