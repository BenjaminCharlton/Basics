using System;
using System.Threading.Tasks;
using Basics.DomainModelling;
using Microsoft.AspNetCore.Authorization;

namespace Basics.Security
{
    public class MustBeCreatorAuthorizationHandler<TUser, TUserKey, TResource> :
        AuthorizationHandler<MustBeCreatorRequirement, TResource>
        where TResource : ICreatable<TUser, TUserKey>
        where TUser : class, IIdentifiable<TUserKey>, IUpdatable<TUser, TUserKey>, IActivatable<TUser, TUserKey>
        where TUserKey : IEquatable<TUserKey>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            MustBeCreatorRequirement requirement,
            TResource resource)
        {
            var user = context.User as TUser;
            if (!user.IsNullOrDefault())
            {
                if (user.Equals(resource.CreatedByUser))
                {
                    return Task.CompletedTask;
                }
            }
            return new Task(new Action(() => { }));
        }
    }
}
