using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using ApiFundacion.Repository.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Repository.Proyectos
{
    public interface IProyectoRepository
    {
        Task<bool> Create(ProyectoInsert proyecto);
        
        Task<bool> Update(ProyectoUpdate proyecto);

        Task<bool> Delete(int id);

        Task<List<ProyectoDTO>> GetProyectos();
        Task<List<ProyectoDTO>> GetProyectosFilter(ProyectosQueryFilter filters);

        //Task<List<ProyectoDTO>> Delete(int id);
    }
}
