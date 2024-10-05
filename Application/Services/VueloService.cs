using Application.Interfaces;
using Contract.Mappings;
using Contract.Vuelos.Request;
using Contract.Vuelos.Response;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class VueloService : IVueloService
    {
        private readonly IVueloRepository _vuelorepository;

        public VueloService(IVueloRepository vuelorepository)
        {
            _vuelorepository = vuelorepository;
        }

        public void CreateVuelo(CreateVueloRequest vuelo)
        {
            var vueloEntity = ProgramacionVuelos.ToVuelosEntity(vuelo);

            _vuelorepository.AddVuelo(vueloEntity);
        }

        public List<VueloResponse> GetAllVuelos() 
        { 
            var vuelos = _vuelorepository.GetVuelos();
            var vuelosResponse = new List<VueloResponse>();

            foreach (var vuelo in vuelos)
            {
                var vueloResp = ProgramacionVuelos.ToVueloResponse(vuelo);
                
                vuelosResponse.Add(vueloResp);
            }

            return vuelosResponse;
        }

    }
}
