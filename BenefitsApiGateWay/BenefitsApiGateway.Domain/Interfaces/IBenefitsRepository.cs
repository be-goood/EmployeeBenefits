using BenefitsApiGateway.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsApiGateway.Domain.Interfaces
{
    public interface IBenefitsRepository
    {
        Task<List<EmpDependetsBenefitDetails>> GetEmployeeMedBenefitsAsync(List<InputEmployee> employees);
    }
}
