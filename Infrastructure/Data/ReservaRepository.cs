using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            return _context.Reservas.Include(x => x.Vuelo).Include(x => x.Pasajero).ToList();
        }

        public Reservas? GetReservaById(int id) 
        {
            return _context.Reservas.Include(x => x.Vuelo).Include(x => x.Pasajero).FirstOrDefault(x => x.Id == id);
        }

        public void UpdateReserva(Reservas entity)
        {
            _context.Reservas.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteReserva(Reservas reserva) 
        {
            _context.Reservas.Remove(reserva);
            _context.SaveChanges();
        }
    }
}
