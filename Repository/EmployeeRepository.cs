using CompanyEmployees.Models;
using CompanyEmployees.Repository.Contracts;

namespace CompanyEmployees.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }

        public void CreateEmployeeForCompany(Guid companyId, Employee employee){
            employee.CompanyId = companyId;
            Create(employee);
        }

        public Employee? GetEmployee(Guid companyId, Guid id, bool trackChanges)
        {
            return FindByCondition(com => (com.CompanyId == companyId && com.Id == id), trackChanges).FirstOrDefault();
        }

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) {
            return FindByCondition(com => com.CompanyId == companyId, trackChanges).ToList();
        }
    } 
}