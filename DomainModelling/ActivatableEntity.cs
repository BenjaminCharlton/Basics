using System;

namespace Basics.DomainModelling
{
    public abstract class ActivatableEntity<TKey, TUser, TUserKey> :
        AuditableEntity<TKey, TUser, TUserKey>,
        IActivatable<TUser, TUserKey>
        where TKey : IEquatable<TKey>
        where TUser : class, IIdentifiable<TUserKey>, IUpdatable<TUser, TUserKey>, IActivatable<TUser, TUserKey>
        where TUserKey : IEquatable<TUserKey>
    {
        protected ActivatableEntity() { }

        protected ActivatableEntity(TUser createdByUser) : base(createdByUser) { }

        public TUser LastActivatedByUser { get; private set; }
        public DateTime? WhenLastActivated { get; private set; }
        public TUser LastDeactivatedByUser { get; private set; }
        public DateTime? WhenLastDeactivated { get; private set; }
        public bool IsActive { get; private set; }

        protected virtual void Activate(TUser activatedByUser)
        {
            LastActivatedByUser = activatedByUser ?? throw new ArgumentNullException(nameof(activatedByUser));
            WhenLastActivated = DateTime.Now;
            IsActive = true;
        }

        protected virtual void Deactivate(TUser deactivatedByUser)
        {
            LastDeactivatedByUser = deactivatedByUser ?? throw new ArgumentNullException(nameof(deactivatedByUser));
            WhenLastDeactivated = DateTime.Now;
            IsActive = false;
        }
    }
}
