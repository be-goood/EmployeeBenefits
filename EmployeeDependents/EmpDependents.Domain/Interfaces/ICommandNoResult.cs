using System.Threading.Tasks;

namespace EmpDependents.Domain.Interfaces
{
    public interface ICommandNoResult<TParam>
    {
        Task ExecuteAsync(TParam param);
    }
}
