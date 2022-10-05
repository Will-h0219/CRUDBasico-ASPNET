using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBasico.Models.Entities
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Posicion { get; set; }

        public int EquipoId { get; set; }
        public EquipoDeFutbol Equipo { get; set; }
    }
}
