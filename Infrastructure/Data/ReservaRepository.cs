using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;

namespace Infrastructure.Data
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly VuelosDbContext _context;

        public ReservaRepository(VuelosDbContext context) 
        {
            _context = context;
        }

        public void AddReserva(Reservas entity)
        {
            _context.Reservas.Add(entity);
            _context.SaveChanges();
        }

        public List<Reservas> GetReservas()
        {
            return _context.Reservas.ToList();
        }

        public Reservas? GetReservaById(int id) 
        {
            return _context.Reservas.FirstOrDefault(x => x.Id == id);
        }
    }
}
