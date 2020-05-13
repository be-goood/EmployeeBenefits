using MedicalBenefits.Domain.Interfaces;
using MedicalBenefits.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalBenefits.Logic
{
    public class CostRules
    {
        public async Task CalculateCostAsync(Parameters p)
        {
            foreach(var command in GetCostCommands())
            {
                await command.ExecuteAsync(p);
            }
        }

        private static List<ICostCommand> GetCostCommands()
        {
            var commands = new List<ICostCommand>();

            commands.Add(new EmployeeMedCostHandler());

            return commands;
        }
    }
}
