using BenefitsPortal.Domain.Models;
using System;
using System.Threading.Tasks;

namespace BenefitsPortal.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeWithDependentsAsync(Guid employeeId);
        Task AddEmployeesAsync(AddEmployeeModel newEmployee);

        Task UpdateEmployeesAsync(UpdateEmplyoeeModel employeeToUpdate);
    }
}
