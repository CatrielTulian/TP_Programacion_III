using Contract.Pasajeros.Request;
using Contract.Pasajeros.Response;

namespace Application.Interfaces
{
    public interface IPasajerosService
    {
        void CreatePasajero(PasajeroRequest pasajero);
        List<PasajeroResponse> GetAllPasajeros();
        PasajeroResponse? GetPasajeroById(int id);
        bool UpdatePasajero(int id, PasajeroRequest pasajero);
        bool DeletePasajero(int id);
    }
}
