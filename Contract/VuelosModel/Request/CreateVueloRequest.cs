namespace Contract.Vuelos.Request
{
    public class CreateVueloRequest
    {
        public int NumeroVuelo { get; set; }
        public int Capacidad { get; set; }
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; }= string.Empty;
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        
    }
}
