namespace CompanyEmployees.Exceptions
{
    public sealed class EmployeesNotFoundException : NotFoudException
    {
        public EmployeesNotFoundException(Guid CompanyId) : base($"Employee for company '{CompanyId}' does not exist"){} 
    } 
}