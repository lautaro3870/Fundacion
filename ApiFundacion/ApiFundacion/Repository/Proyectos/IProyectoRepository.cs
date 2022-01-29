using ApiFundacion.Models;
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

        Task<List<Proyecto>> GetProyectos();

        Task<bool> Delete(int id);
    }
}
