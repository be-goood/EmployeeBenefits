using BenefitsApiGateway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsApiGateway.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeWithDependentsAsync(Guid employeeId);
        Task<List<Employee>> GetAllEmployeesAsync();

        Task AddEmployeesAsync(AddEmployeeModel newEmployee);

        Task UpdateEmployeesAsync(UpdateEmplyoeeModel employeeToUpdate);
    }
}
