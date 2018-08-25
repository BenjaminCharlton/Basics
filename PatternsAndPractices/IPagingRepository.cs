using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basics.PatternsAndPractices
{
    public interface IPagingRepository<TEntity>
    {
        IEnumerable<TEntity> GetPage(int pageIndex, int pageSize);
    }
}
