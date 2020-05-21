using System;
using System.ComponentModel.DataAnnotations;

namespace BenefitsPortal.Domain.Models
{
    public class AddDependentModel
    {
        public Guid EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public DateTime Dob { get; set; }
        public int DependentType { get; set; }
    }
}
