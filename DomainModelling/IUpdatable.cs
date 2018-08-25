using System;

namespace Basics.DomainModelling
{
    public interface IUpdatable<out TUser, out TUserKey>
        where TUser : IIdentifiable<TUserKey>, IUpdatable<TUser, TUserKey>, IActivatable<TUser, TUserKey>
        where TUserKey : IEquatable<TUserKey>
    {
        TUser LastUpdatedByUser { get; }

        DateTime? WhenLastUpdated { get; }
    }
}
