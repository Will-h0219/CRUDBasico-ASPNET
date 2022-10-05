using CRUDBasico.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBasico.Services.Contracts
{
    public interface IEquipoService
    {
        IEnumerable<EquipoDeFutbol> Get();
        EquipoDeFutbol Get(int id);
        void Add(EquipoDeFutbol data);
        void Delete(int id);
        void Update(EquipoDeFutbol data);
        void Save();
    }
}
