using CompanyEmployees.Models;

namespace CompanyEmployees.Service.Contracts {
    public interface IAuthenticationService {
        // Task per fare funzioni asincrone
        Task<bool> ValidateUser(UserForAuthenticationDbo userForAuthenticationDbo); 
        Task<string> CreateToken();
    }
    
}