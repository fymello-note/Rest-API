using CompanyEmployees.Models;
using CompanyEmployees.Repository.Contracts;

namespace CompanyEmployees.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        } 

        // public IEnumerable<Company> GetAllCompanies(bool trackChanges) {
        //     return FindAll(trackChanges).OrderBy(c => c.Name).ToList();
        // }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) {
            return FindAll(trackChanges).OrderBy(c => c.Name).ToList();
        }

        public Company? GetCompany(bool trackChanges, Guid Id) {
            return FindByCondition(compa => compa.Id == Id, trackChanges).FirstOrDefault();
        }
    } 
}