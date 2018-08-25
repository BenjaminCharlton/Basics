using System;

namespace Basics.DomainModelling
{
    public abstract class AuditableEntity<TKey, TUser, TUserKey> :
        CreatableEntity<TKey, TUser, TUserKey>,
        IUpdatable<TUser, TUserKey>
        where TKey : IEquatable<TKey>
        where TUser : class, IIdentifiable<TUserKey>, IUpdatable<TUser, TUserKey>, IActivatable<TUser, TUserKey>
        where TUserKey : IEquatable<TUserKey>
    {
        protected AuditableEntity() { }

        protected AuditableEntity(TUser createdByUser) : base(createdByUser) { }

        public TUser LastUpdatedByUser { get; private set; }
        public DateTime? WhenLastUpdated { get; private set; }

        protected virtual void Update(TUser updatedByUser)
        {
            LastUpdatedByUser = updatedByUser ?? throw new ArgumentNullException(nameof(updatedByUser));
            WhenLastUpdated = DateTime.Now;
        }
    }
}
