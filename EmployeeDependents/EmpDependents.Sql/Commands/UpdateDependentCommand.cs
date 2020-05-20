using EmpDependents.Domain.Entities;
using EmpDependents.Domain.Interfaces;
using EmpDependents.Sql.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmpDependents.Sql.Commands
{
    public  class UpdateDependentCommand : IUpdateCommandNoResult<Dependent>
    {
        private readonly string _connectionString;
        public UpdateDependentCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task ExecuteAsync(Dependent dependent)
        {
            using (var dbContext = new DependentDb(_connectionString))
            {
                //var model = await dbContext.Dependent.AddAsync(dependent);
                dbContext.Entry(dependent).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
