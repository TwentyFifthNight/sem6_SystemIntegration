using IntegracjaSystemów8.Model;
using System.Collections.Generic;
using IntegracjaSystemów8.Entities;

namespace IntegracjaSystemów8.Services.Users
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest request);
        IEnumerable<User> GetUsers(); 
        User GetByUsername(string username);
        User GetById(int id);
    }
}
