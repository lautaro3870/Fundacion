using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Repository.Proyectos
{
    public interface IProyectoRepository
    {
        Task<Proyecto> Create(Proyecto proyecto);

        Task<Proyecto> Update(Proyecto proyecto);

        Task<List<ProyectoDTO>> GetProyectos();

        Task<bool> Delete(int id);
    }
}
