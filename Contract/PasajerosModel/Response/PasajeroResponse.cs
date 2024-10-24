namespace Contract.Pasajeros.Response
{
    public class PasajeroResponse
    {
        public int Id { get; set; }
        public int NroDoc { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
    }
}
