using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployees.Models
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid Id {get; set;}
        
        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(60, ErrorMessage = "Maximum length 60 chararcters")]
        public string? Name {get; set;}

        [Required(ErrorMessage = "Company address is required")]
        [MaxLength(60, ErrorMessage = "Maximum length 60 chararcters for Address")]
        public string? Address {get; set;}
        public string? Country {get; set;}

        public ICollection<Employee>? Employees {get; set;}
    }
}
