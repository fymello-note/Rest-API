using AutoMapper;
using CompanyEmployees.Exceptions;
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

        public CompanyDto CreateCompany(CompanyForCreationDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);
            _repository.Company.CreateCompany(companyEntity);
            _repository.Save();
            return _mapper.Map<CompanyDto>(companyEntity);
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges) {
            /*             try
                        { */
            var companies = _repository.Company.GetAllCompanies(trackChanges);
            return _mapper.Map<IEnumerable<CompanyDto>>(companies);
            /*             } catch (Exception ex) {
                            Console.WriteLine($"Something wrong {ex}");
                            throw;
                        } */
        }

        public CompanyDto? GetCompany(bool trackChanges, Guid Id) {
            var company = _repository.Company.GetCompany(trackChanges, Id);

            if (company is null)
                throw new CompanyNotFoundException(Id);

            return _mapper.Map<CompanyDto>(company);
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
