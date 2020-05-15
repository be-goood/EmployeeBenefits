using System;

namespace BlazorPortal.Data
{
    public class EmployeeBenefits
    {
        public string EmployeeName { get; set; }

        public string BenefitPlan { get; set; }
        public DateTime CoverageBeginDate { get; set; }
        public DateTime DeducationBeginDate { get; set; }
        public string Coverage { get; set; }
        public decimal CalculatedCoverage { get; set; }
        public string Dependents { get; set; }
        public string Beneficiaries { get; set; }
        public decimal SemiMonthlyEmployeeCost { get; set; }
        public decimal SemiMonthlyEmployerContributions { get; set; }


        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
