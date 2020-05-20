using BenefitsPortal.Domain.Models;
using System.Threading.Tasks;

namespace BenefitsPortal.Domain.Interfaces
{
    public interface IDependentRepository
    {
        Task AddDependentAsync(AddDependentModel newDependent);
        Task UpdateDependentAsync(UpdateDependentModel dependentToUpdate);
    }
}
