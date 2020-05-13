using System;

namespace MedicalBenefits.Domain.Models
{
    public class Dependent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal BenefitsCost { get; set; }
        public decimal BenefitDiscount { get; set; }
    }
}