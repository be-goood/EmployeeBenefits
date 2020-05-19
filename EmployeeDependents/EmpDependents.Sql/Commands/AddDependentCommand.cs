using EmpDependents.Domain.Entities;
using EmpDependents.Domain.Interfaces;
using EmpDependents.Sql.Context;
using System.Threading.Tasks;

namespace EmpDependents.Sql.Commands
{
    public  class AddDependentCommand : IAddCommandNoResult<Dependent>
    {
        private readonly string _connectionString;
        public AddDependentCommand(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task ExecuteAsync(Dependent dependent)
        {
            using (var dbContext = new DependentDb(_connectionString))
            {
                var model = await dbContext.Dependent.AddAsync(dependent);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
