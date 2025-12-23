using CompanyEmployees.Models;

namespace CompanyEmployees.Service.Contracts
{
    public interface ICompanyService {

        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges); 
        
    }
}