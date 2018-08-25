using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Security
{
    public interface IAccountManager<TUser, TUserKey, TRole, TRoleKey>
        where TUser : class
        where TUserKey : IEquatable<TUserKey>
        where TRoleKey : IEquatable<TRoleKey>
    {
        Task<bool> CheckPasswordAsync(TUser user, string password);
        Task<Tuple<bool, string[]>> CreateRoleAsync(TRole role, IEnumerable<string> claims);
        Task<Tuple<bool, string[]>> CreateUserAsync(TUser user, IEnumerable<string> roles, string password);
        Task<Tuple<bool, string[]>> DeleteRoleAsync(TRole role);
        Task<Tuple<bool, string[]>> DeleteRoleAsync(string roleName);
        Task<Tuple<bool, string[]>> DeleteUserAsync(TUser user);
        Task<Tuple<bool, string[]>> DeleteUserAsync(TUserKey userId);
        Task<TRole> GetRoleByIdAsync(TRoleKey roleId);
        Task<TRole> GetRoleByNameAsync(string roleName);
        Task<TRole> GetRoleLoadRelatedAsync(string roleName);
        Task<List<TRole>> GetRolesLoadRelatedAsync(int page, int pageSize);
        Task<Tuple<TUser, string[]>> GetUserAndRolesAsync(TUserKey userId);
        Task<TUser> GetUserByEmailAsync(string email);
        Task<TUser> GetUserByIdAsync(TUserKey userId);
        Task<TUser> GetUserByUserNameAsync(string userName);
        Task<IList<string>> GetUserRolesAsync(TUser user);
        Task<List<Tuple<TUser, string[]>>> GetUsersAndRolesAsync(int page, int pageSize);
        Task<Tuple<bool, string[]>> ResetPasswordAsync(TUser user, string newPassword);
        Task<bool> TestCanDeleteRoleAsync(TRoleKey roleId);
        Task<bool> TestCanDeleteUserAsync(TUserKey userId);
        Task<Tuple<bool, string[]>> UpdatePasswordAsync(TUser user, string currentPassword, string newPassword);
        Task<Tuple<bool, string[]>> UpdateRoleAsync(TRole role, IEnumerable<string> claims);
        Task<Tuple<bool, string[]>> UpdateUserAsync(TUser user);
        Task<Tuple<bool, string[]>> UpdateUserAsync(TUser user, IEnumerable<string> roles);
    }
}
