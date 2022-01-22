using System;
using System.Collections.Generic;

#nullable disable

namespace ApiFundacion.Models
{
    public partial class Area
    {
        public Area()
        {
            Areasxproyectos = new HashSet<Areasxproyecto>();
        }


        public int Id { get; set; }
        public string Area1 { get; set; }
        public char? Trial059 { get; set; }

        public virtual ICollection<Areasxproyecto> Areasxproyectos { get; set; }
    }
}
