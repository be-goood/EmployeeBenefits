using System.ComponentModel.DataAnnotations;

namespace BenefitsPortal.Domain.Models
{
    public class AddEmployeeModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
