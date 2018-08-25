using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basics.PatternsAndPractices
{
    public interface IAsyncPagingRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetPageAsync(int pageIndex, int pageSize);
    }
}
