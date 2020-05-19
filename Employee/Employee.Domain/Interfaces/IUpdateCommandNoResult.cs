using System.Threading.Tasks;

namespace EmpDependents.Domain.Interfaces
{
    public interface IUpdateCommandNoResult<TParam>
    {
        Task ExecuteAsync(TParam param);
    }
}
