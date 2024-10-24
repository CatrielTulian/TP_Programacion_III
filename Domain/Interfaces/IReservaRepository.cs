using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IReservaRepository
    {
        void AddReserva(Reservas entity);
        List<Reservas> GetReservas();
        Reservas? GetReservaById(int id);
    }
}
