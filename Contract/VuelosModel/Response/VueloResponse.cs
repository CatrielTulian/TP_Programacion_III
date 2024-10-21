namespace Contract.Vuelos.Response
{
    public class VueloResponse
    {
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
    }
}
