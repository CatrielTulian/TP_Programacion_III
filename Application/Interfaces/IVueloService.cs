using Contract.Vuelos.Request;
using Contract.Vuelos.Response;

namespace Application.Interfaces
{
    public interface IVueloService
    {
        void CreateVuelo(VueloRequest vuelo);
        List<VueloResponse> GetAllVuelos();
        VueloResponse? GetVueloById(int id);

        bool UpdateVuelo(int id, VueloRequest vuelo);
        bool DeleteVuelo(int id);
        
    }
}
