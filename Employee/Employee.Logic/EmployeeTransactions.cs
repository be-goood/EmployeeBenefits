using Employee.Domain.Entities;
using Employee.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Logic
{
    public class EmployeeTransactions
    {
        public async Task<EmployeeEntity> GetEmployeeWithCurrentSalaryAsync(IQuery<EmployeeEntity, Guid> getEmployeeAndSalaryQuery, Guid employeeId)
        {
            var employee = await getEmployeeAndSalaryQuery.ExecuteQueryAsync(employeeId);
            employee.Salary.RemoveAll(r => r.EndDate != null);
            return employee;
        }

        public async Task<List<EmployeeEntity>> GetAllEmployeesWithCurrentSalariesAsync(IQueryNoParam<List<EmployeeEntity>> getAllEmployeesAndSalariesQuery)
        {
            var employees = await getAllEmployeesAndSalariesQuery.ExecuteQueryAsync();
            employees.ForEach(e => e.Salary.RemoveAll(r => r.EndDate != null));
            return employees;
        }
    }
}
