using CompanyEmployees.Models;
using CompanyEmployees.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase{
        private readonly IServiceManager _service;

        public EmployeeController(IServiceManager service) {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId) {
            var Employees = _service.employeeService.GetEmployees(companyId, false);

            return Ok(Employees);
        }

        [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid id) {
            return Ok(_service.employeeService.GetEmployee(companyId, id, false));
        }

        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)        {
            if(employee is null)
                return BadRequest("EmployeeForCreationDto object is null");
            
            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var employeeToReturn = _service.employeeService.CreateEmployee(companyId, employee, false);

            return CreatedAtRoute("GetEmployeeForCompany", new {companyId, id=employeeToReturn.Id}, employeeToReturn);
        }
        /*
        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)        {
            if(employee is null)
                return BadRequest("EmployeeForCreationDto object is null");

            var employeeToReturn = _service.employeeService.CreateEmployee(companyId, employee, false);

            return CreatedAtRoute("GetEmployeeForCompany", new {companyId, id=employeeToReturn.Id}, employeeToReturn);
        } */

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid id) {
            _service.employeeService.DeleteEmployeeForCompany(companyId, id, false);

            return NoContent();
        }
    } 
}