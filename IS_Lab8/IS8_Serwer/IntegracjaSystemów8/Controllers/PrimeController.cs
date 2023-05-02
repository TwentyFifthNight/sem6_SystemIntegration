using IntegracjaSystemów8.Services.PrimeNumbers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace IntegracjaSystemów8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeController : ControllerBase
    {
        private readonly IPrimeService primeService;

        public PrimeController(IPrimeService primeService)
        {
            this.primeService = primeService;
        }

        [HttpGet]
        [Authorize(Roles = "number", AuthenticationSchemes =
            JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Get()
        {
            return Ok(new { primeNumber = this.primeService.GetPrime() });
        }

    }
}
