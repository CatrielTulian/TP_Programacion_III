using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IVueloRepository
    {
        void AddVuelo(Vuelos entity);
        List<Vuelos> GetVuelos();

        Vuelos? GetVueloById(int id);
        void UpdateVuelo(Vuelos entity);

        void DeleteVuelo(Vuelos entity);
    }
}
