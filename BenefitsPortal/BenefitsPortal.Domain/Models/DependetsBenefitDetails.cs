using System;

namespace BenefitsPortal.Domain.Models
{
    public class DependetsBenefitDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal BenefitsCost { get; set; }
        public decimal BenefitDiscount { get; set; }
    }
}
