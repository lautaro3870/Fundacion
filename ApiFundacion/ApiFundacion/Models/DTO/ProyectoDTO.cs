using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Models.DTO
{
    public class ProyectoDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string PaisRegion { get; set; }
        
        public int? MesInicio { get; set; }
        public int? AnioInicio { get; set; }
        public int? MesFinalizacion { get; set; }
        public int? AnioFinalizacion { get; set; }
        //public string ConsultoresAsoc { get; set; }
        public bool? FichaLista { get; set; }

        public List<AreasDTO> ListaAreas { get; set; }

        public string Departamentos { get; set; }
        
        
    }
}
