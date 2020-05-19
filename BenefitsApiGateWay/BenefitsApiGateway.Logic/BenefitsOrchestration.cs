using BenefitsApiGateway.Domain.Interfaces;
using BenefitsApiGateway.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsApiGateway.Logic
{
    public class BenefitsOrchestration
    {
        public async Task<List<EmpDependetsBenefitDetails>> GetEmployeeWithCurrentSalaryAsync(IEmployeeRepository employeeRepository, IDependentRepository dependentRepository, IBenefitsRepository benefitsRepository)
        {
            var employees = await employeeRepository.GetAllEmployeesAsync();
            var inputEmployees = await GetInputEmployees(employees, dependentRepository);
            var medBenefits = await benefitsRepository.GetEmployeeMedBenefitsAsync(inputEmployees);

            return medBenefits;
        }

        private async Task<List<InputEmployee>> GetInputEmployees(List<Employee> employees, IDependentRepository dependentRepository)
        {
            var inputEmployees = new List<InputEmployee>();
            foreach (var employee in employees)
            {
                var eTemp = new InputEmployee();
                eTemp.Id = employee.Id;
                eTemp.Name = $"{employee.FirstName} {employee.LastName}";

                employee.Dependents = await dependentRepository.GetAllEmployeeDependentsAsync(employee.Id);

                foreach (var d in employee.Dependents)
                {
                    var dTemp = new InputDependent();
                    dTemp.Id = d.Id;
                    dTemp.Name = $"{d.FirstName} {d.LastName}";
                    eTemp.InputDependents.Add(dTemp);
                }
                inputEmployees.Add(eTemp);
            }
            return inputEmployees;
        }
    }
}
