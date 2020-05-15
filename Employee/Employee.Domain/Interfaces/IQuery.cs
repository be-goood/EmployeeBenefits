using System.Threading.Tasks;

namespace Employee.Domain.Interfaces
{
    public interface IQuery<TResult, TParam>
    {
        Task<TResult> ExecuteQueryAsync(TParam param);
    }
}
