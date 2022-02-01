using ApiFundacion.Models;
using ApiFundacion.Models.DTO;
using ApiFundacion.Repository.QueryFilters;
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

        public async Task<List<ProyectoDTO>> GetProyectosFilter(ProyectosQueryFilter filters)
        {
            var proyectos = await context.Proyectos.OrderBy(x => x.Id).ToListAsync();
            var areasxproyectosBD = await context.Areasxproyectos.ToListAsync();
            var areaBD = await context.Areas.ToListAsync();

            var listProyectoDto = new List<ProyectoDTO>();

            foreach (var i in proyectos)
            {
                //var areaxProyecto = await context.Areasxproyectos.Where(x => x.Idproyecto == i.Id).ToListAsync();
                var areaxProyecto = areasxproyectosBD.Where(x => x.Idproyecto == i.Id).ToList();
                var listaAreaDto = new List<AreasDTO>();
                foreach (var j in areaxProyecto)
                {
                    //var area = await context.Areas.FirstOrDefaultAsync(x => x.Id == j.Idarea);
                    var area = areaBD.FirstOrDefault(x => x.Id == j.Idarea);

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

            if (filters.AnioInicio != null)
            {
                 listProyectoDto = listProyectoDto.Where(x => x.AnioInicio == filters.AnioInicio).ToList();
            }
            if (filters.AnioFin != null)
            {
                listProyectoDto = listProyectoDto.Where(x => x.AnioFinalizacion == filters.AnioFin).ToList();
            }
            if (filters.MesInicio != null)
            {
                listProyectoDto = listProyectoDto.Where(x => x.MesInicio == filters.MesInicio).ToList();
            }
            if (filters.MesFin != null)
            {
                listProyectoDto = listProyectoDto.Where(x => x.MesFinalizacion == filters.MesFin).ToList();
            }
            if (filters.Titulo != null)
            {
                listProyectoDto = listProyectoDto.Where(x => x.Titulo == filters.Titulo).ToList();
            }
            if (filters.Pais != null)
            {
                listProyectoDto = listProyectoDto.Where(x => x.PaisRegion == filters.Pais).ToList();
            }

            return listProyectoDto;
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
