using System;

namespace Basics.DomainModelling
{
    public abstract class UpdatableEntity<TUser, TUserKey> :
        IUpdatable<TUser, TUserKey>
        where TUser : class, IIdentifiable<TUserKey>, IUpdatable<TUser, TUserKey>, IActivatable<TUser, TUserKey>
        where TUserKey : IEquatable<TUserKey>
    {
        public int? LastUpdatedByUserId { get; private set; }
        public DateTime? WhenLastUpdated { get; private set; }
        public TUser LastUpdatedByUser { get; private set; }

        protected virtual void Update(TUser updatedByUser)
        {
            LastUpdatedByUser = updatedByUser ?? throw new ArgumentNullException(nameof(updatedByUser));
            WhenLastUpdated = DateTime.Now;
        }
    }
}
