using BenefitsPortal.Domain.Models;
using System;
using System.Threading.Tasks;

namespace BenefitsPortal.Domain.Interfaces
{
    public interface IDependentRepository
    {
        Task<Dependent> GetDependentAsync(Guid dependentId);
        Task AddDependentAsync(AddDependentModel newDependent);
        Task UpdateDependentAsync(UpdateDependentModel dependentToUpdate);
    }
}
