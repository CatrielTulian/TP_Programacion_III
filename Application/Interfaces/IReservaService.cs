using Contract.Reservas.Request;
using Contract.Reservas.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IReservaService
    {
        void CreateReserva(ReservaRequest reserva);
        List<ReservaResponse> GetAllReservas();
        ReservaResponse? GetReservaById(int id);
    }
}
