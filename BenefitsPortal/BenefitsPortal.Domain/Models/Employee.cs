using System;
using System.Collections.Generic;

namespace BenefitsPortal.Domain.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Dependent> Dependents { get; set; } = new List<Dependent>();
    }
}
