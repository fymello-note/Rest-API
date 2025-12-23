namespace CompanyEmployees.Exceptions
{
    public sealed class EmployeeNotFoundException : NotFoudException
    {
        public EmployeeNotFoundException(Guid CompanyId, Guid Id) : base($"Employee '{Id}' for company '{CompanyId}' does not exist"){} 
    } 
}