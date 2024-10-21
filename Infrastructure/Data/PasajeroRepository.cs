using Domain.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Data
{
    public class PasajeroRepository : IPasajeroRepository
    {
        private readonly VuelosDbContext _context;

        public PasajeroRepository(VuelosDbContext context) 
        { 
            _context = context;
        }

        public void AddPasajero(Pasajeros entity)
        {
            _context.Pasajeros.Add(entity);
            _context.SaveChanges();
        }

        public List<Pasajeros> GetPasajeros()
        {
            return _context.Pasajeros.ToList();
        }
    }
}
