using System;

namespace Basics.DomainModelling
{
    public interface IIdentifiable : IIdentifiable<int>
    { }

    public interface IIdentifiable<out TKey>
    {
        TKey Id { get; }
    }
}
