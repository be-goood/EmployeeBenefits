using EmpDependents.Domain.Entities;
using EmpDependents.Domain.Interfaces;
using EmpDependents.Sql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpDependents.Sql.Queries
{
    public class GetEmployeeDependentsQuery : IQuery<List<Dependent>, Guid>
    {
        private readonly string _connectionString;
        public GetEmployeeDependentsQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Dependent>> ExecuteQueryAsync(Guid employeeId)
        {
            using (var dbContext = new DependentDb(_connectionString))
            {
                var model = await dbContext.Dependent
                    .Where(w => w.EmployeeId == employeeId)
                    .ToListAsync();

                return model;
            }
        }
    }
}
