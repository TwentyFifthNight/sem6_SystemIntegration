using IntegracjaSystemów8.Entities;

namespace IntegracjaSystemów8.Model
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(User user, string token)
        {
            this.Id = user.Id;
            this.Username = user.Username;
            this.Token = token;
        }
    }
}
