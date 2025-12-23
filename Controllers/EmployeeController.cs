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

        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var Employees = _service.employeeService.GetEmployees(companyId, false);

            return Ok(Employees);
        }
    } 
}