using CompanyEmployees.Models;

namespace CompanyEmployees.Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);

        EmployeeDto? GetEmployee(Guid companyId, Guid Id, bool trackChanges);

        EmployeeDto CreateEmployee(Guid companyId, EmployeeForCreationDto employee, bool trackChanges);
    } 
}