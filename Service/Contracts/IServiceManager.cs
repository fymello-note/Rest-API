namespace CompanyEmployees.Service.Contracts
{
    public interface IServiceManager {
        ICompanyService companyService { get; }
        IEmployeeService employeeService { get; }
        IAuthenticationService AuthenticationService {get;}
    }
}
