using System;
using System.ComponentModel.DataAnnotations;

namespace BenefitsPortal.Domain.Models
{
    public class Dependent
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Name => $"{FirstName} {LastName}";
    }
}
