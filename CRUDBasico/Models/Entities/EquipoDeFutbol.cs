using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBasico.Models.Entities
{
    public class EquipoDeFutbol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Presidente { get; set; }
        public DateTime AnioFundacion { get; set; }
        public string Liga { get; set; }

        public List<Jugador> Jugadores { get; set; }
    }
}
