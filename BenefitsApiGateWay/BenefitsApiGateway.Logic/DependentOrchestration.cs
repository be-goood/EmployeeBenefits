using BenefitsApiGateway.Domain.Interfaces;
using BenefitsApiGateway.Domain.Models;
using System.Threading.Tasks;

namespace BenefitsApiGateway.Logic
{
    public class DependentOrchestration
    {
        public async Task AddDependetAsync(IDependentRepository dependetRepository, AddDependentModel addDependentModel)
        {
            //todo: add logs and error checking
            await dependetRepository.AddDependentAsync(addDependentModel);
        }

        public async Task UpdateDependetAsync(IDependentRepository dependetRepository, UpdateDependentModel dependetToUpdate)
        {
            //todo: add logs and error checking
            await dependetRepository.UpdateDependentAsync(dependetToUpdate);
        }
    }
}
