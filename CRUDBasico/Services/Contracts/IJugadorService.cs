using CRUDBasico.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBasico.Services.Contracts
{
    public interface IJugadorService
    {
        IEnumerable<Jugador> Get();
        Jugador Get(int id);
        void Add(Jugador data);
        void Delete(int id);
        void Update(Jugador data);
        void Save();
    }
}
