using System.Threading.Tasks;

namespace MedicalBenefits.Domain.Interfaces
{
    public interface IQueryNoParam<TResult>
    {
        Task<TResult> ExecuteQueryAsync();
    }
}

