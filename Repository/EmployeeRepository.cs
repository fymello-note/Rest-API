using CompanyEmployees.Models;
using CompanyEmployees.Repository.Contracts;

namespace CompanyEmployees.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) {
            return FindByCondition(com => com.CompanyId == companyId, trackChanges).ToList();
        }
    } 
}