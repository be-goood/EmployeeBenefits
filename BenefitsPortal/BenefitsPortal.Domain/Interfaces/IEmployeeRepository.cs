using BenefitsPortal.Domain.Models;
using System.Threading.Tasks;

namespace BenefitsPortal.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddEmployeesAsync(AddEmployeeModel newEmployee);

        Task UpdateEmployeesAsync(UpdateEmplyoeeModel employeeToUpdate);
    }
}
