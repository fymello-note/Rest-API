using AutoMapper;
using CompanyEmployees.Models;
using CompanyEmployees.Repository.Contracts;
using CompanyEmployees.Service.Contracts;

namespace CompanyEmployees.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repository = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies = _repository.Company.GetAllCompanies(trackChanges);
                return _mapper.Map<IEnumerable<CompanyDto>>(companies);
            } catch (Exception ex) {
                Console.WriteLine($"Something wrong {ex}");
                throw;
            }
        }
/*         public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies = _repository.Company.GetAllCompanies(trackChanges).Select(companies => 
                    new CompanyDto(companies.Id, companies.Name??"", 
                    companies.Address??"" + ", " + companies.Country??""));
                return companies;
            } catch (Exception ex) {
                Console.WriteLine($"Something wrong {ex}");
                throw;
            }
        } */
    }
}
