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

        public Vuelos? GetVueloById(int id)
        {
            return _context.Vuelos.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void UpdateVuelo(Vuelos entity) 
        {
            _context.Vuelos.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteVuelo(Vuelos vuelo)
        {
            _context.Vuelos.Remove(vuelo);
            _context.SaveChanges();
        }
    }
}
