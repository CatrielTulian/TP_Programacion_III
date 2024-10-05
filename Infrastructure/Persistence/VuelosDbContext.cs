using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class VuelosDbContext : DbContext
    {
        public VuelosDbContext(DbContextOptions<VuelosDbContext> options) : base(options)
        {

        }

        public DbSet<Vuelos> Vuelos { get; set; }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Pasajeros> Pasajeros { get; set; }
    }
}
