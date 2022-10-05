using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBasico.Models.DataTransferObjects
{
    public class NuevoEquipoDTO
    {
        public string Nombre { get; set; }
        public string Presidente { get; set; }
        public DateTime AnioFundacion { get; set; }
        public string Liga { get; set; }
    }
}
