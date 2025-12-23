using AutoMapper;
using CompanyEmployees.Models;

namespace CompanyEmployees.Mapping{
    public class MappingProfile : Profile {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>().ForCtorParam("FullAddress", opt => 
                opt.MapFrom(x => string.Join(' ', new object?[] {x.Address, x.Country})));

            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyForCreationDto, Company>();

            CreateMap<EmployeeForCreationDto, Employee>();
        }
    }
}
