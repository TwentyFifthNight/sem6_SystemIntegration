using Server.Model;
using Server.Services.Data;
using Server.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.IdentityModel.Protocols.WsTrust;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController: ControllerBase
    {
        private readonly IDataService dataService;

        public DataController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpGet("pollutions")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult GetPollutionsData()
        {
            //pobranie województwa użytkownika
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return BadRequest(new { message = "Invalid token" });

            dynamic? response = dataService.GetPollutionsData(identity.FindFirst(ClaimTypes.StateOrProvince).Value);

            if (response == null)
                return BadRequest(new { message = "Error while preparing data" });
            return Ok(response);
        }

        
        [HttpGet("industries")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetIndustriesData()
        {
            //pobranie województwa użytkownika
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null)
                return BadRequest(new { message = "Invalid token" });

            dynamic? response = await dataService.GetIndustriesData(identity.FindFirst(ClaimTypes.StateOrProvince).Value);
            if (response == null)
                return BadRequest(new { message = "Error while preparing data" });

            return Ok(response);
        }
    }
}
