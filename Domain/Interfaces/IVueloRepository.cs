using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IVueloRepository
    {
        void AddVuelo(Vuelos entity);
        List<Vuelos> GetVuelos();
    }
}
