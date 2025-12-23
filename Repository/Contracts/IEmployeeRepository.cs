using CompanyEmployees.Models;

namespace CompanyEmployees.Repository.Contracts
{
    public interface IEmployeeRepository{

        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);

    } 
}