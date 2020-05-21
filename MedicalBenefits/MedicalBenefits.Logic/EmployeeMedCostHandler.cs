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
            ApplyCostsToEachEmployee(p);
        }

        private async Task SetUpData(Parameters p)
        {
            foreach(var ie in p.InputEmployees)
            {
                var employee = new Employee();
                employee.Id = ie.Id;
                employee.Name = ie.Name;
                foreach(var id in ie.InputDependents)
                {
                    var dependant = new Dependent();
                    dependant.Id = id.Id;
                    dependant.Name = id.Name;
                    employee.Dependents.Add(dependant);
                }
                p.Employees.Add(employee);
            }
            p.CostRule = await p.GetEmployeeCostRulesQuery.ExecuteQueryAsync();
        }

        private void ApplyCostsToEachEmployee(Parameters p)
        {
            foreach (var employee in p.Employees)
            {
                employee.BenefitsCost = p.CostRule.BaseEmployeeCost;
                employee.BenefitDiscount = GetDiscountAmount(employee.Name, p.CostRule.BaseEmployeeCost, p.CostRule.DiscountPercentage);
                employee.TotalBenefitsCost = employee.BenefitsCost - employee.BenefitDiscount;
                employee.TotalBenefitsDiscount = employee.BenefitDiscount;

                foreach (var dependent in employee.Dependents)
                {
                    dependent.BenefitsCost = p.CostRule.BaseDependentCost;
                    dependent.BenefitDiscount = GetDiscountAmount(dependent.Name, p.CostRule.BaseDependentCost, p.CostRule.DiscountPercentage);
                    employee.TotalBenefitsCost += dependent.BenefitsCost - dependent.BenefitDiscount;
                    employee.TotalBenefitsDiscount += dependent.BenefitDiscount;
                }
            }
        }

        private decimal GetDiscountAmount(string name, decimal baseCost, decimal discountPercentage)
        {
            if (name.StartsWith('A'))
            {
                return baseCost * discountPercentage;
            }

            return 0;
        }
    }
}
