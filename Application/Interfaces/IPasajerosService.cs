using Contract.Pasajeros.Request;
using Contract.Pasajeros.Response;

namespace Application.Interfaces
{
    public interface IPasajerosService
    {
        void CreatePasajero(CreatePasajeroRequest pasajero);
        List<PasajeroResponse> GetAllPasajeros();
    }
}
