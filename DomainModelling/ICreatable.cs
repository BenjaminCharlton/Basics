using System;

namespace Basics.DomainModelling
{
    public interface ICreatable<out TUser, out TUserKey>
        where TUser : IIdentifiable<TUserKey>, IUpdatable<TUser, TUserKey>, IActivatable<TUser, TUserKey>
        where TUserKey : IEquatable<TUserKey>
    {
        TUser CreatedByUser { get; }
        DateTime WhenCreated { get; }
    }
}
