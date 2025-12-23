using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyEmployees.Models
{
    public class ApiUser
    {
        [Column("UserId")]
        public Guid Id {get; set;}
        
        [Required(ErrorMessage = "User Name is required")]
        [MaxLength(60, ErrorMessage = "Maximum length 60 chararcters")]
        public string? UserName {get; set;}

        [Required(ErrorMessage = "Password is required")]
        [MaxLength(60, ErrorMessage = "Maximum length 60 chararcters for Address")]
        public string? Password {get; set;}

    }
}
