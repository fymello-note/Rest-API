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
            // try {
            //throw new Exception();
            var companies = _service.companyService.GetAllCompanies(false);

            return Ok(companies);
            // }
            // catch (Exception)
            // {
            //     return StatusCode(500, "Internal server Error");
            // }
        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        public IActionResult GetCompany(Guid id)
        {
            var company = _service.companyService.GetCompany(false, id);

            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreationCompany([FromBody] CompanyForCreationDto company){
            if(company is null) 
                return BadRequest("CompanyForCreationDto is null");

            var companyCreated = _service.companyService.CreateCompany(company);

            return CreatedAtRoute("CompanyById", new {id = companyCreated.Id}, companyCreated);
        }
    }
}
