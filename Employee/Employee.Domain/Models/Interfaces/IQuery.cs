using System.Threading.Tasks;

namespace Employee.Domain.Models.Interfaces
{
    public interface IQuery<TResult, TParam>
    {
        Task<TResult> ExecuteQueryAsync(TParam param);
    }
}
