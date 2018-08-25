using System;

namespace Basics.DomainModelling
{
    public abstract class ApprovableEntity<TKey, TUser, TUserKey> :
        AuditableEntity<TKey, TUser, TUserKey>,
        IApprovable<TUser, TUserKey>
        where TKey : IEquatable<TKey>
        where TUser : class, IIdentifiable<TUserKey>, IUpdatable<TUser, TUserKey>, IActivatable<TUser, TUserKey>
        where TUserKey : IEquatable<TUserKey>
    {
        protected ApprovableEntity() { }

        protected ApprovableEntity(TUser createdByUser) : base(createdByUser){ }

        public TUser LastApprovedByUser { get; private set; }

        public DateTime? WhenLastApproved { get; private set; }

        public TUser LastRejectedByUser { get; private set; }

        public DateTime? WhenLastRejected { get; private set; }

        public Status Status { get; private set; }

        protected virtual void Approve(TUser approvedByUser)
        {
            LastApprovedByUser = approvedByUser ?? throw new ArgumentNullException(nameof(approvedByUser));
            WhenLastApproved = DateTime.Now;
            Status = Status.Approved;
        }

        protected virtual void Reject(TUser rejectedByUser, Status newStatus = Status.Rejected)
        {
            LastRejectedByUser = rejectedByUser ?? throw new ArgumentNullException(nameof(rejectedByUser));
            WhenLastRejected = DateTime.Now;
            Status = newStatus;
        }
    }
}
