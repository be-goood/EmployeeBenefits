using System;
using System.ComponentModel.DataAnnotations;

namespace BenefitsPortal.Domain.Models
{
    public class UpdateEmplyoeeModel
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
