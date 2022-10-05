using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBasico.Models.DataTransferObjects
{
    public class NuevoJugadorDTO
    {
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public int EquipoId { get; set; }
        public string Posicion { get; set; }
    }
}
