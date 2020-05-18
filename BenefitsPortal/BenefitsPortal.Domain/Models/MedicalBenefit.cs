using System;
using System.ComponentModel.DataAnnotations;

namespace BenefitsPortal.Domain.Models
{
    public class MedicalBenefit
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public string Dependents { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        //[DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal BaseEmployeeCost { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        //[DisplayFormat(DataFormatString = "{0:#.####}")] 
        public decimal EmployeeDiscountAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        //[DisplayFormat(DataFormatString = "{0:#.####}")] 
        public decimal TotalEmployeeCost { get; set; }
    }
}
