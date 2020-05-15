using System.Threading.Tasks;

namespace Employee.Domain.Interfaces
{
    public interface IQueryNoParam<TResult>
    {
        Task<TResult> ExecuteQueryAsync();
    }
}
