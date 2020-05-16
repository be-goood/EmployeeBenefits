namespace BenefitsPortal.Domain.Models
{
    public class MedicalBenefit
    {
        public string EmployeeName { get; set; }

        public decimal BaseEmployeeCost { get; set; }
        //public List<string> Dependents { get; set; }
        public string Dependents { get; set; }
        public decimal EmployeeDiscountAmount { get; set; }
        public decimal TotalEmployeeCost { get; set; }
    }
}
