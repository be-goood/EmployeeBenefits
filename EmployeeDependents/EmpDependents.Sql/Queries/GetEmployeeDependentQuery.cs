using EmpDependents.Domain.Entities;
using EmpDependents.Domain.Interfaces;
using EmpDependents.Sql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmpDependents.Sql.Queries
{
    public class GetEmployeeDependentQuery : IQuery<Dependent, Guid>
    {
        private readonly string _connectionString;
        public GetEmployeeDependentQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Dependent> ExecuteQueryAsync(Guid id)
        {
            using (var dbContext = new DependentDb(_connectionString))
            {
                var model = await dbContext.Dependent
                    .Where(w => w.Id == id)
                    .FirstOrDefaultAsync();

                return model;
            }
        }
    }
}
