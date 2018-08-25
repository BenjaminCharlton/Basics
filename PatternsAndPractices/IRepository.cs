using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Basics.DomainModelling;

namespace Basics.PatternsAndPractices
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : IIdentifiable<TKey>
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity FindOne(Expression<Func<TEntity, bool>> predictate);

        TEntity Get(TKey id);

        IEnumerable<TEntity> GetAll();

        void Remove(TKey id);

        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
