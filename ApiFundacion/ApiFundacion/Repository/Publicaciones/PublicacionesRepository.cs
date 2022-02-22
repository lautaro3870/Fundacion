using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Repository.Publicaciones
{
    public class PublicacionesRepository : IPublicacionesRepository
    {
        private readonly dena66utud3alcContext context;
        public PublicacionesRepository(dena66utud3alcContext context)
        {
            this.context = context;
        }

        public async Task<List<Publicacionesxproyecto>> GetPublicaciones()
        {
            return await context.Publicacionesxproyectos.ToListAsync();
        }
    }
}
