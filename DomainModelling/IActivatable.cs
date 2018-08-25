using System;

namespace Basics.DomainModelling
{
    public interface IActivatable<out TUser, out TUserKey>
        where TUser : IIdentifiable<TUserKey>, IUpdatable<TUser, TUserKey>, IActivatable<TUser, TUserKey>
        where TUserKey : IEquatable<TUserKey>
    {
        TUser LastActivatedByUser { get; }
        DateTime? WhenLastActivated { get; }
        TUser LastDeactivatedByUser { get; }
        DateTime? WhenLastDeactivated { get; }
        bool IsActive { get; }
    }
}
