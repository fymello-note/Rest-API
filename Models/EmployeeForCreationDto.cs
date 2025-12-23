using System.ComponentModel.DataAnnotations;

namespace CompanyEmployees.Models {
    //public record EmployeeForCreationDto(string Name, int Age, string Position); 

    public record EmployeeForCreationDto{
        [Required(ErrorMessage ="Employee name is required")]
        [MaxLength(20, ErrorMessage ="Maximum length 20 characters for employee name")]
        public string? Name {get; init;}

        [Required(ErrorMessage ="Age is required")]
        public int Age;

        [Required(ErrorMessage ="Position is required")]
        [MaxLength(20, ErrorMessage ="Maximum length 20 characters for employee position")]
        public string? Position {get; init;}
    };

}