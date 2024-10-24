namespace Contract.Pasajeros.Request
{
    public class PasajeroRequest
    {
        public int NroDoc { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
    }
}
