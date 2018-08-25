using System;
using Basics.DomainModelling;
using System.Threading.Tasks;

namespace Basics.PatternsAndPractices
{
    public static class RepositoryExtension
    {
        public static bool Exists<TEntity, TKey>(this IRepository<TEntity, TKey> instance, TKey id)
            where TEntity : IIdentifiable<TKey>
        {
            if (instance.IsNull())
                throw new ArgumentNullException(nameof(instance));

            return instance.Exists(id, out TEntity entity);
        }

        public static bool Exists<TEntity, TKey>(this IRepository<TEntity, TKey> instance, TKey id, out TEntity entity)
            where TEntity : IIdentifiable<TKey>
        {
            if (instance.IsNull())
                throw new ArgumentNullException(nameof(instance));

            entity = instance.Get(id);
            return !entity.IsNullOrDefault();
        }

        //public static async Task<bool> ExistsAsync<TEntity, TKey>(this IRepository<TEntity, TKey> instance, TKey id)
        //    where TEntity : IIdentifiable<TKey>
        //{
        //    if (instance.IsNull())
        //        throw new ArgumentNullException(nameof(instance));

        //    return await instance.ExistsAsync(id, out TEntity entity);
        //}

        //public static async Task<bool> ExistsAsync<TEntity, TKey>(this IRepository<TEntity, TKey> instance, TKey id, out TEntity entity)
        //    where TEntity : IIdentifiable<TKey>
        //{
        //    if (instance.IsNull())
        //        throw new ArgumentNullException(nameof(instance));

        //    entity = await instance.GetAsync(id);
        //    return !entity.IsNullOrDefault();
        //}
    }
}
