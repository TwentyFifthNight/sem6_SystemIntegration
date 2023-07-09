using Server.Entities;

namespace Server.Model
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
