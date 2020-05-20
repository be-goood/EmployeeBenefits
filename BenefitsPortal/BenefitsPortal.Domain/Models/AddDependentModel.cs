using System;

namespace BenefitsPortal.Domain.Models
{
    public class AddDependentModel
    {
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public DateTime Dob { get; set; }
        public int DependentType { get; set; }
    }
}
