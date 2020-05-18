using System.Threading.Tasks;

namespace EmpDependents.Domain.Interfaces
{
    public interface ICommand<TResult, TParam>
    {
        Task<TResult> ExecuteAsync(TParam param);
    }
}
