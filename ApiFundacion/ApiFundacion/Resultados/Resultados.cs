using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFundacion.Resultados
{
    public class Resultados
    {
        public bool Ok { get; set; }
        public string Error { get; set; }

        public string InfoAdicional { get; set; }

        public int CodigoError { get; set; }

        public object Return { get; set; }
    }
}
