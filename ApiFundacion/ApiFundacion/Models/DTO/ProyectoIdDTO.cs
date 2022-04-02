using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Models.DTO
{
    public class ProyectoIdDTO
    {
        public int Id { get; set; }     
        public string Titulo { get; set; }
        public string PaisRegion { get; set; }
        public string Contratante { get; set; }
        public string Dirección { get; set; }
        public string MontoContrato { get; set; }
        public string NroContrato { get; set; }
        public int? MesInicio { get; set; }
        public int? AnioInicio { get; set; }
        public int? MesFinalizacion { get; set; }
        public int? AnioFinalizacion { get; set; }
        public string ConsultoresAsoc { get; set; }
        public string Descripcion { get; set; }
        public string Resultados { get; set; }
        public bool? FichaLista { get; set; }
        public bool? EnCurso { get; set; }
        public string Departamento { get; set; }
        public string Moneda { get; set; }
        public bool? Certconformidad { get; set; }
        public int? Certificadopor { get; set; }
        //public byte[] SsmaTimestamp { get; set; }
        //public char? Trial118 { get; set; }
        public bool? Activo { get; set; }
        public string Link { get; set; }

        public List<AreasDTO> ListaAreas { get; set; }
        public List<PersonalDTOId> ListaPersonal { get; set; }

        public List<PublicacionesDTO> ListaPublicaciones { get; set; }
    }
}
