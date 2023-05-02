using IntegracjaSystemów8.Model;
using IntegracjaSystemów8.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IntegracjaSystemów8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticationRequest request)
        {
            var response = userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(response);    
        }

        [Authorize(Roles = "admin", AuthenticationSchemes = 
            JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("getAll")]
        public IActionResult getAllUsers()
        {
            return Ok(this.userService.GetUsers());
        }

        [Authorize(Roles = "user", AuthenticationSchemes =
            JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("count")]
        public IActionResult getUserCount()
        {
            return Ok( new { Count = this.userService.GetUsers().Count() });
        }
    }
}
