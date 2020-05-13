using MedicalBenefits.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalBenefits.Sql.Context
{
    public class MedicalBenefitsDb : DbContext
    {
        private string _connectionString = string.Empty;
        public MedicalBenefitsDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<CostRule> CostRules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
