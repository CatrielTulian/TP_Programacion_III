using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data
{
    public class VueloRepository : IVueloRepository
    {
        private readonly VuelosDbContext _context;

        public VueloRepository(VuelosDbContext context) 
        { 
            _context = context;
        }

        public void AddVuelo(Vuelos entity)
        {
            _context.Vuelos.Add(entity);
            _context.SaveChanges();
        }

        public List<Vuelos> GetVuelos()
        {
            return _context.Vuelos.ToList();
        } 
    }
}
