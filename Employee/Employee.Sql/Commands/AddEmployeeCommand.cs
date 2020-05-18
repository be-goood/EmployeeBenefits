using EmpDependents.Domain.Interfaces;
using Employee.Domain.Entities;
using Employee.Sql.Context;
using System.Threading.Tasks;

namespace EmpDependents.Sql.Commands
{
    public  class AddEmployeeCommand : ICommandNoResult<EmployeeEntity>
    {
        private readonly string _connectionString;
        public AddEmployeeCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task ExecuteAsync(EmployeeEntity employee)
        {
            using (var dbContext = new EmployeeDb(_connectionString))
            {
                var model = await dbContext.Employee.AddAsync(employee);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
