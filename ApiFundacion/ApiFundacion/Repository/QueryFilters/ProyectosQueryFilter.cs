using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Repository.QueryFilters
{
    public class ProyectosQueryFilter
    {
        public string? Titulo { get; set; }
        public string? Pais { get; set; }
        public int? MesInicio { get; set; }
        public int? MesFin { get; set; }
        public int? AnioInicio { get; set; }
        public int? AnioFin { get; set; }
    }
}
