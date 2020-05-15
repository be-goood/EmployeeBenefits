using BenefitsApiGateway.Domain.Interfaces;
using BenefitsApiGateway.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsApiGateway.Logic
{
    public class BenefitsOrchestration
    {
        public async Task<List<EmpDependetsBenefitDetails>> GetEmployeeWithCurrentSalaryAsync(IEmployeeRepository employeeRepository, IDependentRepository dependentRepository)
        {
            await Task.Run(() =>
            {
            });

            var employees = await employeeRepository.GetAllEmployeesAsync();
            var empDependetsBenefitDetailsList = new List<EmpDependetsBenefitDetails>();

            //var options = new ParallelOptions { MaxDegreeOfParallelism = 5 };
            //Parallel.ForEach(employees, options, employee =>
            //    GetDependents(employee, dependentRepository)
            //);

            foreach (var employee in employees)
            {
                employee.Dependents = await dependentRepository.GetAllEmployeeDependentsAsync(employee.Id);
            }


            return new List<EmpDependetsBenefitDetails>();
        }

        public async void GetDependents(Employee employee, IDependentRepository dependentRepository)
        {
            employee.Dependents =  await dependentRepository.GetAllEmployeeDependentsAsync(employee.Id);
        }
    }

}
