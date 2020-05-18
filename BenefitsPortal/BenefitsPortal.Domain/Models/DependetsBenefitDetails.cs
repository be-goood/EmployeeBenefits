using System;
using System.ComponentModel.DataAnnotations;

namespace BenefitsPortal.Domain.Models
{
    public class DependetsBenefitDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal BenefitsCost { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal BenefitDiscount { get; set; }
    }
}
