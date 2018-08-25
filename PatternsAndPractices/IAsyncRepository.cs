using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Basics.DomainModelling;
using System.Threading.Tasks;

namespace Basics.PatternsAndPractices
{
    public interface IAsyncRepository<TEntity, in TKey>
        where TEntity : IIdentifiable<TKey>
    {
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predictate);

        Task<TEntity> GetAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
