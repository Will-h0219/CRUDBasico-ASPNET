using CRUDBasico.Context;
using CRUDBasico.Models.Entities;
using CRUDBasico.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBasico.Services
{
    public class EquipoService : IEquipoService
    {
        private readonly AppDbContext _context;
        private readonly DbSet<EquipoDeFutbol> _dbSet;

        public EquipoService(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<EquipoDeFutbol>();
        }

        public IEnumerable<EquipoDeFutbol> Get()
        {
            return _dbSet.Include(x => x.Jugadores).ToList();
        }

        public EquipoDeFutbol Get(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(EquipoDeFutbol data)
        {
            _dbSet.Add(data);
        }

        public void Update(EquipoDeFutbol data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var dataToDelete = _dbSet.Find(id);
            _dbSet.Remove(dataToDelete);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
