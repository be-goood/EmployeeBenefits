using System;

namespace BenefitsApiGateway.Domain.Models
{
    public class EmployeeSalary
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public decimal YearlyWages { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
