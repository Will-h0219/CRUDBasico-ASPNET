using CRUDBasico.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBasico.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EquipoDeFutbol> Equipo { get; set; }
        public DbSet<Jugador> Jugador { get; set; }
    }
}
