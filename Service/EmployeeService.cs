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

        public EmployeeDto CreateEmployee(Guid companyId, EmployeeForCreationDto employee, bool trackChanges){
            if (_repository.Company.GetCompany(trackChanges, companyId) is null) {
                throw new CompanyNotFoundException(companyId);
            }

            var employeeEntity = _mapper.Map<Employee>(employee);
            _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            _repository.Save();

            return _mapper.Map<EmployeeDto>(employeeEntity);
        }

        public void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges){
            if (_repository.Company.GetCompany(trackChanges, companyId) is null) {
                throw new CompanyNotFoundException(companyId);
            }

            var employeeToDelete = _repository.Employee.GetEmployee(companyId, id, trackChanges);
            if(employeeToDelete is null) {
                throw new EmployeeNotFoundException(companyId, id);
            }
            _repository.Employee.DeleteEmployee(employeeToDelete);
            _repository.Save();
        }

        public EmployeeDto? GetEmployee(Guid companyId, Guid Id, bool trackChanges) {
            if (_repository.Company.GetCompany(false, companyId) is null)
                throw new CompanyNotFoundException(companyId);
            
            var Employees = _repository.Employee.GetEmployee(companyId, Id, trackChanges);

            if (Employees is null)
                throw new EmployeeNotFoundException(companyId, Id);


            return _mapper.Map<EmployeeDto>(Employees);
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges) {
            if (_repository.Company.GetCompany(false, companyId) is null)
                throw new CompanyNotFoundException(companyId);

            var Employees = _repository.Employee.GetEmployees(companyId, trackChanges);

            if (Employees is null)
                throw new EmployeesNotFoundException(companyId);


            return _mapper.Map<List<EmployeeDto>>(Employees);
        }
    }
}
