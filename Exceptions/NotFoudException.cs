namespace CompanyEmployees.Exceptions
{
    public abstract class NotFoudException : Exception {
        protected NotFoudException(string message) : base(message){} 
    } 
}