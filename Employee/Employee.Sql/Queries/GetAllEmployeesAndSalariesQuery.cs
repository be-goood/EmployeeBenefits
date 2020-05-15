using Employee.Sql.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Employee.Domain.Entities;
using Employee.Domain.Interfaces;
using System.Collections.Generic;

namespace Employee.Sql.Queries
{
    public class GetAllEmployeesAndSalariesQuery : IQueryNoParam<List<EmployeeEntity>>
    {
        private readonly string _connectionString;
        public GetAllEmployeesAndSalariesQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<EmployeeEntity>> ExecuteQueryAsync()
        {
            using (var dbContext = new EmployeeDb(_connectionString))
            {
                var model = await dbContext.Employee
                    .Include(i => i.Salary)
                    .ToListAsync();

                return model;
            }
        }
    }
}
