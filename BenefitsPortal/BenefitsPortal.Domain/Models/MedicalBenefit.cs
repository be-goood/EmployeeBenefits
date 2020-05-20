using System;
using System.ComponentModel.DataAnnotations;

namespace BenefitsPortal.Domain.Models
{
    public class MedicalBenefit
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public string Dependents { get; set; }

        public decimal BaseEmployeeCost { get; set; }

        public decimal EmployeeDiscountAmount { get; set; }

        public decimal TotalEmployeeCost { get; set; }
    }
}
