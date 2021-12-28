using Microsoft.AspNetCore.Authorization;
using StreamLine.Api.Security.AuthorizationRequirement;
using System.Threading.Tasks;
using Tenants.Helpers.Enums;

namespace StreamLine.Api.Security.AuthorizationHandler
{
    internal class PermissionAuthorizationHandler //: AuthorizationHandler<PermissionRequirement>
    {
        //private readonly ISecurityManager _securityManager;

        //public PermissionAuthorizationHandler(ISecurityManager securityManager)
        //{
        //    _securityManager = securityManager;
        //}

        //protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        //{
        //    var results = _securityManager.HasPermission(requirement.PermissionId, WorkerGroupTypes.Worker);
        //    if (results >= (int)requirement.PermissionLevel)
        //        context.Succeed(requirement);
        //    else
        //        context.Fail();

        //    return Task.FromResult(0);
        //}
    }
}