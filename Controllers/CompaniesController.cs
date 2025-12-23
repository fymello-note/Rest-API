using CompanyEmployees.Models;
using CompanyEmployees.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase {
        private readonly IServiceManager _service;
        public CompaniesController(IServiceManager service){
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCompanies() {
            try {
                var companies = _service.companyService.GetAllCompanies(false);
                return Ok(companies);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server Error");
            }
        }
    }
}
