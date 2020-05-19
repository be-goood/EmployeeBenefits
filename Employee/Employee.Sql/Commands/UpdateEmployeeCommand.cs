using EmpDependents.Domain.Interfaces;
using Employee.Domain.Entities;
using Employee.Sql.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmpDependents.Sql.Commands
{
    public  class UpdateEmployeeCommand : IUpdateCommandNoResult<EmployeeEntity>
    {
        private readonly string _connectionString;
        public UpdateEmployeeCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task ExecuteAsync(EmployeeEntity employee)
        {
            using (var dbContext = new EmployeeDb(_connectionString))
            {
                //var model = await dbContext.Employee.AddAsync(employee);
                dbContext.Entry(employee).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
