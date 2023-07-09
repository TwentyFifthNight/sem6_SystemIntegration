using Server.Entities;
using Server.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using UserService;

namespace Server.Services.Users
{
    public class UserServiceImpl : IUserService
    {
       
        private readonly IConfiguration configuration;

        public UserServiceImpl(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<AuthenticationResponse?> Authenticate(AuthenticationRequest request)
        {
            try
            {
                SOAPInterfaceClient SOAPClient = new();
                string response = await SOAPClient.loginAsync(request.Username, request.Password);
                if(response == "")
                    return null;
                
                User? user = JsonConvert.DeserializeObject<User>(response);
                if(user == null) return null;
                string token = GenerateJwtToken(user);
                return new AuthenticationResponse(user, token);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:key"]);
            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.StateOrProvince, user.Voivodeship)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = 
                    new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
