using Server.Model;
using System.Collections.Generic;
using Server.Entities;

namespace Server.Services.Users
{
    public interface IUserService
    {
        Task<AuthenticationResponse?> Authenticate(AuthenticationRequest request);
    }
}
