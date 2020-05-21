using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BenefitsPortal.Domain.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public List<Dependent> Dependents { get; set; } = new List<Dependent>();
    }
}
