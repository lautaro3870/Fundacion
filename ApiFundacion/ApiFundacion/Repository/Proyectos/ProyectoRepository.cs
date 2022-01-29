using ApiFundacion.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Repository.Proyectos
{
    public class ProyectoRepository : IProyectoRepository
    {

        public readonly dena66utud3alcContext context;

        public ProyectoRepository(dena66utud3alcContext context)
        {
            this.context = context;
        }
        public Task<Proyecto> Create(Proyecto proyecto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Proyecto>> GetProyectos()
        {
            return await context.Proyectos.ToListAsync();
        }

        public Task<Proyecto> Update(Proyecto proyecto)
        {
            throw new NotImplementedException();
        }
    }
}
