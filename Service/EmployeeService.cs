using AutoMapper;
using CompanyEmployees.Exceptions;
using CompanyEmployees.Models;
using CompanyEmployees.Repository.Contracts;
using CompanyEmployees.Service.Contracts;

namespace CompanyEmployees.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            var Employees = _repository.Employee.GetEmployees(companyId, trackChanges);

            if (_repository.Company.GetCompany(false, companyId) == null)
                throw new CompanyNotFoundException(companyId);
            else if (Employees is null)
                throw new EmployeeNotFoundException(companyId);


            return _mapper.Map<List<EmployeeDto>>(Employees);
        }
    }
}
