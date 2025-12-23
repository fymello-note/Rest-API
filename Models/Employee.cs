using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployees.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id {get; set;} 

        [Required(ErrorMessage ="Employee name is required")]
        [MaxLength(20, ErrorMessage ="Maximum length 20 characters for employee name")]
        public string? Name {get; set;}

        [Required(ErrorMessage ="Employee age is required")]
        public int Age {get; set;}

        [Required(ErrorMessage ="Employee position is required")]
        [MaxLength(20, ErrorMessage ="Maximum length 20 characters for employee position")]
        public string? Position {get; set;}

        [ForeignKey(nameof(Company))]
        public Guid CompanyId {get; set;}

        public Company? company {get; set;}
    } 
}