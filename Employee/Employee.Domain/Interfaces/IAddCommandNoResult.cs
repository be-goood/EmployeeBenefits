using System.Threading.Tasks;

namespace EmpDependents.Domain.Interfaces
{
    public interface IAddCommandNoResult<TParam>
    {
        Task ExecuteAsync(TParam param);
    }
}
