using MedicalBenefits.Domain.Entities;
using MedicalBenefits.Domain.Interfaces;
using MedicalBenefits.Sql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MedicalBenefits.Sql.Queries
{
    public class GetEmployeeCostRulesQuery : IQueryNoParam<CostRule>
    {
        private readonly string _connectionString;
        public GetEmployeeCostRulesQuery(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<CostRule> ExecuteQueryAsync()
        {
            using (var dbContext = new MedicalBenefitsDb(_connectionString))
            {
                var model = await dbContext.CostRules
                    .FirstOrDefaultAsync(w => w.EndDate == null || w.EndDate > DateTime.Now);

                return model;
            }
        }
    }
}
