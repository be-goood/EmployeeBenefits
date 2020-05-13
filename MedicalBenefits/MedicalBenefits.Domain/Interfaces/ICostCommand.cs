using MedicalBenefits.Domain.Models;
using System.Threading.Tasks;

namespace MedicalBenefits.Domain.Interfaces
{
    public interface ICostCommand
    {
        Task ExecuteAsync(Parameters p);
    }
}
