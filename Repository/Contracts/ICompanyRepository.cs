using CompanyEmployees.Models;

namespace CompanyEmployees.Repository.Contracts
{
    public interface ICompanyRepository {
        //IEnumerable<Company> GetAllCompanies(bool trackChanges); 


        IEnumerable<Company> GetAllCompanies(bool trackChanges); 

        Company? GetCompany(bool trackChanges, Guid Id);
    } 
}