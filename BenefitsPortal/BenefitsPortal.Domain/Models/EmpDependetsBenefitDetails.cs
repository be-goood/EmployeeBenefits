using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BenefitsPortal.Domain.Models
{
    public class EmpDependetsBenefitDetails
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal BenefitsCost { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal BenefitDiscount { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal TotalBenefitsCost { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal TotalBenefitsDiscount { get; set; }
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal PaycheckDeduction { get; set; }
        public List<DependetsBenefitDetails> Dependents { get; set; } = new List<DependetsBenefitDetails>();
    }
}
