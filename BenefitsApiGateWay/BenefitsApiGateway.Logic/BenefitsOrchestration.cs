using BenefitsApiGateway.Domain.Interfaces;
using BenefitsApiGateway.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsApiGateway.Logic
{
    public class BenefitsOrchestration
    {
        public async Task<List<EmpDependetsBenefitDetails>> GetEmployeeWithCurrentSalaryAsync(IEmployeeRepository employeeRepository)
        {
            await Task.Run(() =>
            {
            });

            var employees = await employeeRepository.GetAllEmployeesAsync();

            
            return new List<EmpDependetsBenefitDetails>();
        }
    }
}
