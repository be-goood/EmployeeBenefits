using BenefitsApiGateway.Domain.Interfaces;
using BenefitsApiGateway.Domain.Models;
using System.Threading.Tasks;

namespace BenefitsApiGateway.Logic
{
    public class EmployeeOrchestration
    {
        public async Task AddEmployeeAsync(IEmployeeRepository employeeRepository, AddEmployeeModel addEmployeeModel)
        {
            //todo: add logs and error checking
            await employeeRepository.AddEmployeesAsync(addEmployeeModel);
        }

        public async Task UpdateEmployeeAsync(IEmployeeRepository employeeRepository, UpdateEmplyoeeModel employeeToUpdate)
        {
            //todo: add logs and error checking
            await employeeRepository.UpdateEmployeesAsync(employeeToUpdate);
        }
    }
}
