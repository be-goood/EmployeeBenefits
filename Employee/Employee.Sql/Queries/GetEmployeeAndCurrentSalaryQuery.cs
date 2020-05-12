using Employee.Domain.Models.Entities;
using Employee.Sql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Employee.Domain.Models.Interfaces;

namespace Employee.Sql.Queries
{
    public class GetEmployeeAndCurrentSalaryQuery : IQuery<EmployeeEntity, Guid>
    {
        private readonly string _connectionString;
        public GetEmployeeAndCurrentSalaryQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<EmployeeEntity> ExecuteQuery(Guid employeeId)
        {
            using (var dbContext = new EmployeeDb(_connectionString))
            {
                return await dbContext.Employee
                    .Where(w => w.Id == employeeId)
                    .Include(i => i.Salary)
                    .FirstOrDefaultAsync();
            }
        }
    }
}
