using EmpDependents.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmpDependents.Sql.Context
{
    public class DependentDb : DbContext
    {
        private string _connectionString = string.Empty;
        public DependentDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Dependent> Dependent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
