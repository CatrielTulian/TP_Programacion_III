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

        public Pasajeros? GetPasajeroById(int id) 
        {
            return _context.Pasajeros.FirstOrDefault(x => x.Id.Equals(id));
        }
        
        public void UpdatePasajero(Pasajeros entity)
        {
            _context.Pasajeros.Update(entity);
            _context.SaveChanges();
        }

        public void DeletePasajero(Pasajeros pasajeros) 
        {
            _context.Pasajeros.Remove(pasajeros);
            _context.SaveChanges();
        }
    }
}
