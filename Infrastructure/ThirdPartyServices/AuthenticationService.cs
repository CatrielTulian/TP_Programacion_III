using Application.Interfaces;
using Contract.AuthenticationModel.Helpers;
using Contract.AuthenticationModel.Request;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.ThirdPartyServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IVueloRepository _vueloRepository;
        private readonly AutenticacionServiceOptions _options;


        public AuthenticationService(IVueloRepository vueloRepository, IOptions<AutenticacionServiceOptions> options)
        {
            _vueloRepository = vueloRepository;
            _options = options.Value;
        }

        private Vuelos? ValidateUser(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.User) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;

            var vuelos = _vueloRepository.GetVuelos();

            var user = vuelos.FirstOrDefault(x => x.User.Equals(authenticationRequest.User) && x.Password.Equals(authenticationRequest.Password));
            return user;
        }

        public string Autenticar(AuthenticationRequest authenticationRequest) 
        {
            var user = ValidateUser(authenticationRequest);

            if (user == null) 
            {
                throw new Exception("User authentication failed");
            }

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));
            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
            {
                new Claim("sub", user.Id.ToString()),
                
            };
           
            

            var jwtSecurityToken = new JwtSecurityToken(
            _options.Issuer,
            _options.Audience,
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return tokenToReturn.ToString();
        }
    }
}
