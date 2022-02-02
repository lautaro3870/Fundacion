﻿using ApiFundacion.Models;
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
        public async Task<bool> Create(ProyectoInsert proyecto)
        {
            Proyecto pro = new Proyecto();

            pro.Activo = proyecto.Activo;
            pro.AnioFinalizacion = proyecto.AnioFinalizacion;
            pro.AnioInicio = proyecto.AnioInicio;
            pro.SsmaTimestamp = new byte[5];
            pro.MontoContrato = proyecto.MontoContrato;
            pro.NroContrato = proyecto.NroContrato;
            pro.PaisRegion = proyecto.PaisRegion;
            pro.Titulo = proyecto.Titulo;
            pro.Certconformidad = proyecto.Certconformidad;
            pro.Certificadopor = proyecto.Certificadopor;
            pro.Moneda = proyecto.Moneda;
            pro.EnCurso = proyecto.EnCurso;
            pro.Descripcion = proyecto.Descripcion;
            pro.Departamento = proyecto.Departamento;
            pro.ConsultoresAsoc = proyecto.ConsultoresAsoc;
            pro.Resultados = proyecto.Resultados;
            pro.MesInicio = proyecto.MesInicio;
            pro.MesFinalizacion = proyecto.MesFinalizacion;
            pro.Contratante = proyecto.Contratante;
            pro.Dirección = proyecto.Dirección;


            await context.Proyectos.AddAsync(pro);
            var valor = await context.SaveChangesAsync();

            if (valor == 0)
            {
                throw new Exception("No se pudo insertar el proyecto");
            }

            foreach (var i in proyecto.Areas)
            {
                Areasxproyecto area = new Areasxproyecto();
                area.Idarea = i.Id;
                area.Idproyecto = pro.Id;
                await context.Areasxproyectos.AddAsync(area);
                
            }

            foreach (var j in proyecto.Personal)
            {
                Equipoxproyecto equipo = new Equipoxproyecto();
                equipo.IdPersonal = j.Id;
                equipo.IdProyecto = pro.Id;
                equipo.SsmaTimestamp = new byte[5];
                await context.Equipoxproyectos.AddAsync(equipo);
                
            }

            valor = await context.SaveChangesAsync();

            if (valor == 0)
            {
                throw new Exception("No se pudo insertar el proyecto");
            }
            
            return true;
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

        public async Task<bool> Update(ProyectoUpdate proyecto)
        {
            var pro = context.Proyectos.FirstOrDefault(x => x.Id == proyecto.Id);

            if (pro == null)
            {
                throw new Exception("Proyecto no encotrado");
            }
            else
            {
                pro.Activo = proyecto.Activo ?? pro.Activo;
                pro.AnioFinalizacion = proyecto.AnioFinalizacion ?? pro.AnioFinalizacion;
                pro.AnioInicio = proyecto.AnioInicio ?? pro.AnioInicio;
                pro.SsmaTimestamp = new byte[5];
                pro.MontoContrato = proyecto.MontoContrato ?? pro.MontoContrato;
                pro.NroContrato = proyecto.NroContrato ?? pro.NroContrato;
                pro.PaisRegion = proyecto.PaisRegion ?? pro.PaisRegion;
                pro.Titulo = proyecto.Titulo ?? pro.Titulo;
                pro.Certconformidad = proyecto.Certconformidad ?? pro.Certconformidad;
                pro.Certificadopor = proyecto.Certificadopor ?? pro.Certificadopor;
                pro.Moneda = proyecto.Moneda ?? pro.Moneda;
                pro.EnCurso = proyecto.EnCurso ?? pro.EnCurso;
                pro.Descripcion = proyecto.Descripcion ?? pro.Descripcion;
                pro.Departamento = proyecto.Departamento ?? pro.Departamento;
                pro.ConsultoresAsoc = proyecto.ConsultoresAsoc ?? pro.ConsultoresAsoc;
                pro.Resultados = proyecto.Resultados ?? pro.Resultados;
                pro.MesInicio = proyecto.MesInicio ?? pro.MesInicio;
                pro.MesFinalizacion = proyecto.MesFinalizacion ?? pro.MesFinalizacion;
                pro.Contratante = proyecto.Contratante ?? pro.Contratante;
                pro.Dirección = proyecto.Dirección ?? pro.Dirección;

                var areaProyecto = await context.Areasxproyectos.Where(x => x.Idproyecto == proyecto.Id).ToListAsync();
                foreach(var j in areaProyecto)
                {
                    context.Areasxproyectos.Remove(j);
                }

                foreach (var i in proyecto.Areas)
                {
                    Areasxproyecto area = new Areasxproyecto();
                    area.Idarea = i.Id;
                    area.Idproyecto = pro.Id;
                    await context.Areasxproyectos.AddAsync(area);
                }

                var personalProyecto = await context.Equipoxproyectos.Where(x => x.IdProyecto == proyecto.Id).ToListAsync();
                foreach(var i in personalProyecto)
                {
                    context.Equipoxproyectos.Remove(i);
                }

                foreach (var j in proyecto.Personal)
                {
                    Equipoxproyecto equipo = new Equipoxproyecto();
                    equipo.IdPersonal = j.Id;
                    equipo.IdProyecto = pro.Id;
                    equipo.SsmaTimestamp = new byte[5];
                    await context.Equipoxproyectos.AddAsync(equipo);

                }

                context.Proyectos.Update(pro);
                var valor = await context.SaveChangesAsync();

                if (valor == 0)
                {
                    throw new Exception("Proyecto no se pudo actualizar");
                }
                return true;

            }


        }

        

        public Task<Proyecto> Update(ProyectoInsert proyecto)
        {
            throw new NotImplementedException();
        }
    }
}
