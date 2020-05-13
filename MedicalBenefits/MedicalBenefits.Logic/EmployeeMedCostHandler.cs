using MedicalBenefits.Domain.Interfaces;
using MedicalBenefits.Domain.Models;
using System.Threading.Tasks;

namespace MedicalBenefits.Logic
{
    public class EmployeeMedCostHandler : ICostCommand
    {
        public async Task ExecuteAsync(Parameters p)
        {
            await SetUpData(p);
            await ApplyCostsAsync(p);
        }

        public async Task SetUpData(Parameters p)
        {
            p.CostRule = await p.GetEmployeeCostRulesQuery.ExecuteQueryAsync();
        }

        public async Task ApplyCostsAsync(Parameters p)
        {
            await Task.Run(() =>
            {
                foreach (var employee in p.Employees)
                {
                    employee.BenefitsCost = p.CostRule.BaseEmployeeCost;
                    employee.BenefitDiscount = GetDiscountAmount(employee.Name, p.CostRule.BaseEmployeeCost, p.CostRule.DiscountPercentage);
                    foreach (var dependent in employee.Dependents)
                    {
                        dependent.BenefitsCost = p.CostRule.BaseDependentCost;
                        dependent.BenefitsCost = GetDiscountAmount(dependent.Name, p.CostRule.BaseDependentCost, p.CostRule.DiscountPercentage);
                    }
                }
            });
        }

        public decimal GetDiscountAmount(string name, decimal baseCost, decimal discountPercentage)
        {
            if (name.StartsWith('A'))
            {
                return baseCost * discountPercentage;
            }

            return 0;
        }
    }
}
