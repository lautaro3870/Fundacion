using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
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

        public async Task<List<ProyectoDTO>> GetProyectos()
        {
            //return await context.Proyectos.ToListAsync();
            var proyectos = await context.Proyectos.OrderBy(x => x.Id).ToListAsync();

            var listProyectoDto = new List<ProyectoDTO>();
            
            foreach (var i in proyectos)
            {
                var areaxProyecto = await context.Areasxproyectos.Where(x => x.Idproyecto == i.Id).ToListAsync();
                var listaAreaDto = new List<AreasDTO>();
                foreach (var j in areaxProyecto)
                {
                    var area = await context.Areas.FirstOrDefaultAsync(x => x.Id == j.Idarea);
                    
                    if (area != null)
                    {
                        var areaDto = new AreasDTO
                        {
                            Area1 = area.Area1
                        };
                        listaAreaDto.Add(areaDto);
                    }
                }
                var proyectoDto = new ProyectoDTO
                {
                    Id = i.Id,
                    Titulo = i.Titulo,
                    AnioFinalizacion = i.AnioFinalizacion,
                    AnioInicio = i.AnioInicio,
                    Departamentos = i.Departamento,
                    ListaAreas = listaAreaDto,
                    FichaLista = i.FichaLista,
                    MesFinalizacion = i.MesFinalizacion,
                    MesInicio = i.MesInicio,
                    PaisRegion = i.PaisRegion
                };

                listProyectoDto.Add(proyectoDto);
            }
            return listProyectoDto;

        }

        public Task<Proyecto> Update(Proyecto proyecto)
        {
            throw new NotImplementedException();
        }
    }
}
