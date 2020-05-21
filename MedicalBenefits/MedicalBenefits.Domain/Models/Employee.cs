using System;
using System.Collections.Generic;

namespace MedicalBenefits.Domain.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal BenefitsCost { get; set; }
        public decimal BenefitDiscount { get; set; }
        public decimal TotalBenefitsCost { get; set; }
        public decimal TotalBenefitsDiscount { get; set; }
        public decimal PaycheckDeduction { get; set; }
        public List<Dependent> Dependents { get; set; } = new List<Dependent>();
    }
}