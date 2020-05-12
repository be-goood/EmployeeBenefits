using Employee.Domain.Models.Entities;
using Employee.Sql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Employee.Domain.Models.Interfaces;

namespace Employee.Sql.Queries
{
    public class GetEmployeeAndSalaryQuery : IQuery<EmployeeEntity, Guid>
    {
        private readonly string _connectionString;
        public GetEmployeeAndSalaryQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<EmployeeEntity> ExecuteQueryAsync(Guid employeeId)
        {
            using (var dbContext = new EmployeeDb(_connectionString))
            {
                var model = await dbContext.Employee
                    .Where(w => w.Id == employeeId)
                    .Include(i => i.Salary)
                    .FirstOrDefaultAsync();

                return model;
            }
        }
    }
}
