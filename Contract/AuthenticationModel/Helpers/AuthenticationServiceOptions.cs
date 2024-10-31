namespace Contract.AuthenticationModel.Helpers
{
    public class AutenticacionServiceOptions
    {
        public const string AuthenticationService = "AutenticacionService";

        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string SecretForKey { get; set; } = string.Empty;
    }
}
