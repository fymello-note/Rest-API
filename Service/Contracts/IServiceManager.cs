namespace CompanyEmployees.Service.Contracts
{
    public interface IServiceManager
    {
        public ICompanyService companyService { get; }
        public IEmployeeService employeeService { get; }
    }
}
