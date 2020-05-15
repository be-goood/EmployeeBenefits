using Employee.Domain.Entities;
using Employee.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Employee.Logic
{
    public class EmployeeTransactions
    {
        public async Task<EmployeeEntity> GetEmployeeWithCurrentSalaryAsync(IQuery<EmployeeEntity, Guid> getEmployeeAndSalaryQuery, Guid employeeId)
        {
            EmployeeEntity employee;
            employee = await getEmployeeAndSalaryQuery.ExecuteQueryAsync(employeeId);
            employee.Salary.RemoveAll(r => r.EndDate != null);
            return employee;
        }
    }
}
