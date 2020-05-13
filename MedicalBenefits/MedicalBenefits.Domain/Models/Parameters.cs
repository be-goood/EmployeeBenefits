using MedicalBenefits.Domain.Entities;
using MedicalBenefits.Domain.Interfaces;
using System.Collections.Generic;

namespace MedicalBenefits.Domain.Models
{
    public class Parameters
    {
        public List<Employee> Employees = new List<Employee>();
        public IQueryNoParam<CostRule> GetEmployeeCostRulesQuery;
        public CostRule CostRule = new CostRule();
    }
}
