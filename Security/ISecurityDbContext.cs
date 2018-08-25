using System.Collections.Generic;

namespace Basics.Security
{
    public interface ISecurityDbContext<TUser, TRole>
        where TUser : class
    {
        IEnumerable<TUser> Users { get; set; }
        IEnumerable<TRole> Roles { get; set; }
        IEnumerable<TRole> UserRoles { get; set; }
    }
}
