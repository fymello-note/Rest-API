namespace CompanyEmployees.Exceptions
{
    public sealed class EmployeeNotFoundException : NotFoudException
    {
        public EmployeeNotFoundException(Guid CompanyId) : base($"Employee for company '{CompanyId}' does not exist"){} 
    } 
}