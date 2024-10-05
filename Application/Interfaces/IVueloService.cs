using Contract.Vuelos.Request;
using Contract.Vuelos.Response;

namespace Application.Interfaces
{
    public interface IVueloService
    {
        void CreateVuelo(CreateVueloRequest vuelo);
        List<VueloResponse> GetAllVuelos();
    }
}
