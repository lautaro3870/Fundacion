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

        public async Task<Publicacionesxproyecto> GetPublicacionId(int id)
        {
            return await context.Publicacionesxproyectos.FirstOrDefaultAsync(x => x.IdPublicacion == id);
        }

        public async Task<bool> Insert(PublicacionesDTO publicacion)
        {
            var p = new Publicacionesxproyecto
            {
                IdProyecto = publicacion.IdProyecto,
                Año = publicacion.Año,
                Publicacion = publicacion.Publicacion,
                Codigobcs = publicacion.Codigobcs
            };
            context.Publicacionesxproyectos.Add(p);
            var valor = await context.SaveChangesAsync();

            if (valor == 0)
            {
                throw new Exception("No se pudo insertar la publicacion");
            }

            return true;

        }

        public async Task<bool> Update(PublicacionesDTO publicacion)
        {
            var publi = await context.Publicacionesxproyectos.FirstOrDefaultAsync(x => x.IdPublicacion == publicacion.IdPublicacion && x.IdProyecto == publicacion.IdProyecto);

            if (publi == null)
            {
                throw new Exception("Publicacion no encontrada");
            }
            else
            {
                publi.IdProyecto = publicacion.IdProyecto;
                publi.Publicacion = publicacion.Publicacion;
                publi.Año = publicacion.Año;
                publi.Codigobcs = publicacion.Codigobcs;

                context.Publicacionesxproyectos.Update(publi);
                var valor = await context.SaveChangesAsync();

                if (valor == 0)
                {
                    throw new Exception("Publicacion no modificada");
                }

                return true;
            }

        }
    }
}
