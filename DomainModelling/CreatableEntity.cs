using System;

namespace Basics.DomainModelling
{
    public abstract class CreatableEntity<TKey, TUser, TUserKey> :
        IIdentifiable<TKey>,
        ICreatable<TUser, TUserKey>
        where TUser : class, IIdentifiable<TUserKey>,
        IUpdatable<TUser, TUserKey>, IActivatable<TUser, TUserKey>
        where TUserKey : IEquatable<TUserKey>
    {
        protected CreatableEntity() { }

        protected CreatableEntity(TUser createdByUser)
        {
            CreatedByUser = createdByUser ?? throw new ArgumentNullException(nameof(createdByUser));
            WhenCreated = DateTime.Now;
        }

        public virtual TKey Id { get; protected set; }
        public DateTime WhenCreated { get; protected set; }
        public TUser CreatedByUser { get; protected set; }
    }
}
