using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IPasajeroRepository
    {
        void AddPasajero(Pasajeros entity);
        List<Pasajeros> GetPasajeros();
    }
}
