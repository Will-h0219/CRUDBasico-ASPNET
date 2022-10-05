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
    public class JugadorService : IJugadorService
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Jugador> _dbSet;

        public JugadorService(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Jugador>();
        }

        public IEnumerable<Jugador> Get()
        {
            return _dbSet.Include(x => x.Equipo).ToList();
        }

        public Jugador Get(int id)
        {
            return _dbSet.Where(x => x.Id == id)
                         .Include(x => x.Equipo)
                         .FirstOrDefault();
        }

        public void Add(Jugador data)
        {
            _dbSet.Add(data);
        }

        public void Update(Jugador data)
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
