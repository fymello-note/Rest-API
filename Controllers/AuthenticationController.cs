using CompanyEmployees.Models;
using CompanyEmployees.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase {
        
        private readonly IServiceManager _service;
        public AuthenticationController(IServiceManager service){
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDbo user) {
            if(!await _service.AuthenticationService.ValidateUser(user)){
                return Unauthorized();
            }

            return Ok(new {
                Token = _service.AuthenticationService.CreateToken()
            });
        }
    } 
}