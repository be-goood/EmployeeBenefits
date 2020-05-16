using BenefitsPortal.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsPortal.Domain.Interfaces
{
    public interface IEBenefitsRepository
    {
        Task<List<EmployeeBenefits>> GetEmployeeBenefitstAsync();
        Task<List<MedicalBenefit>> GetEmployeeMedBenefitsTestAsync();
    }
}
