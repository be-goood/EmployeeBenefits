using EmpDependents.Domain.Interfaces;
using Employee.Domain.Entities;
using Employee.Domain.Interfaces;
using Employee.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Logic
{
    public class EmployeeTransactions
    {
        public async Task<EmployNoSalaryModel> GetEmployeeWithCurrentSalaryAsync(IQuery<EmployeeEntity, Guid> getEmployeeAndSalaryQuery, Guid employeeId)
        {
            var employee = await getEmployeeAndSalaryQuery.ExecuteQueryAsync(employeeId);
            var employeeNoSalaryModel = new EmployNoSalaryModel()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName
            };
            
            return employeeNoSalaryModel;
        }

        public async Task<List<EmployeeEntity>> GetAllEmployeesWithCurrentSalariesAsync(IQueryNoParam<List<EmployeeEntity>> getAllEmployeesAndSalariesQuery)
        {
            var employees = await getAllEmployeesAndSalariesQuery.ExecuteQueryAsync();
            employees.ForEach(e => e.Salary.RemoveAll(r => r.EndDate != null));
            return employees;
        }

        public async Task AddEmployee(IAddCommandNoResult<EmployeeEntity> addEmployeeCommand, AddEmployeeModel employeeModel)
        {
            //  todo: apply error checking before executing command
            var now = DateTime.Now;
            var employee = new EmployeeEntity();
            employee.FirstName = employeeModel.FirstName;
            employee.LastName = employeeModel.LastName;
            employee.Id = Guid.NewGuid();
            employee.CreatedOn = now;
            employee.CreatedBy = string.Empty;
            employee.UpdatedOn = now;
            employee.UpdatedBy = string.Empty;
            employee.Salary = new List<EmployeeSalary>
            {
                new EmployeeSalary() 
                { 
                    YearlyWages = 2000 * 26, 
                    StartDate = DateTime.Now, 
                    EndDate = null, 
                    CreatedOn = now, 
                    CreatedBy = string.Empty, 
                    UpdatedOn = now, 
                    UpdatedBy = string.Empty 
                }
            };
            await addEmployeeCommand.ExecuteAsync(employee);
        }

        public async Task UpdateEmployee(IUpdateCommandNoResult<EmployeeEntity> updateEmployeeCommand, IQuery<EmployeeEntity, Guid> getEmployeeAndSalaryQuery,
            UpdateEmplyoeeModel employeeModel)
        {
            var employeeToUpdate = await getEmployeeAndSalaryQuery.ExecuteQueryAsync(employeeModel.Id);
            employeeToUpdate.FirstName = employeeModel.FirstName;
            employeeToUpdate.LastName = employeeModel.LastName;
            employeeToUpdate.UpdatedOn = DateTime.Now;

            //  todo: apply error checking before executing command
            await updateEmployeeCommand.ExecuteAsync(employeeToUpdate);
        }
    }
}
