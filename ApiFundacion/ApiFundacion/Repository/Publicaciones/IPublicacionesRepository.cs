using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Repository.Publicaciones
{
    public interface IPublicacionesRepository
    {
        Task<List<Publicacionesxproyecto>> GetPublicaciones();
        Task<Publicacionesxproyecto> GetPublicacionId(int id);
        Task<bool> Insert(PublicacionesDTO publicacion);
        Task<bool> Update(PublicacionesDTO publicacion);
    }
}
