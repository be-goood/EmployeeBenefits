using BenefitsApiGateway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsApiGateway.Domain.Interfaces
{
    public interface IDependentRepository
    {
        Task<List<Dependent>> GetAllEmployeeDependentsAsync(Guid employeeId);
        Task AddDependentAsync(AddDependentModel newDependent);
        Task UpdateDependentAsync(UpdateDependentModel dependentToUpdate);
    }
}
