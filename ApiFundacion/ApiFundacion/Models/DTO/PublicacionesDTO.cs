using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Models.DTO
{
    public class PublicacionesDTO
    {
        public int IdPublicacion { get; set; }
        public int? IdProyecto { get; set; }
        public string Publicacion { get; set; }
        public string Año { get; set; }
        //public string Medio { get; set; }
        public string Codigobcs { get; set; }
    }
}
