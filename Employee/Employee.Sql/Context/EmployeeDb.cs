using Employee.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Sql.Context
{
    public class EmployeeDb : DbContext
    {
        private string _connectionString = string.Empty;
        public EmployeeDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<EmployeeEntity> Employee { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<EmployeeSalary> Salary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
