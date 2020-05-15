using System.Threading.Tasks;

namespace EmpDependents.Domain.Interfaces
{
    public interface IQuery<TResult, TParam>
    {
        Task<TResult> ExecuteQueryAsync(TParam param);
    }
}
