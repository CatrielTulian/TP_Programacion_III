﻿using Contract.AuthenticationModel.Request;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        string Autenticar(AuthenticationRequest authenticationRequest);
    }
}
