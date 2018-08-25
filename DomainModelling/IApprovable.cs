using System;

namespace Basics.DomainModelling
{
    public interface IApprovable<out TUser, out TUserKey>
        where TUser : IIdentifiable<TUserKey>, IUpdatable<TUser, TUserKey>, IActivatable<TUser, TUserKey>
        where TUserKey : IEquatable<TUserKey>
    {
        TUser LastApprovedByUser { get; }
        DateTime? WhenLastApproved { get; }
        TUser LastRejectedByUser { get; }
        DateTime? WhenLastRejected { get; }
        Status Status { get; }
    }
}
