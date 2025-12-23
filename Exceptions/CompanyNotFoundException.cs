namespace CompanyEmployees.Exceptions
{
    public sealed class CompanyNotFoundException : NotFoudException
    {
        public CompanyNotFoundException(Guid CompanyId) : base($"{CompanyId} does not exist"){} 
    } 
}