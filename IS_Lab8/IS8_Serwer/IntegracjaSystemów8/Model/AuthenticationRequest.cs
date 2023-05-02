using System.ComponentModel.DataAnnotations;

namespace IntegracjaSystemów8.Model
{
    public class AuthenticationRequest
    {
        [Required]public string Username { get; set; }
        [Required] public string Password { get; set; }

    }
}
