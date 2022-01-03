using Microsoft.AspNetCore.Authorization;
using Base.Helpers.Enums;

namespace Master.Api.Security.AuthorizationRequirement
{
    internal class PermissionRequirement : IAuthorizationRequirement
    {
        public int PermissionId { get; }
        public PermissionLevels PermissionLevel { get; }

        public PermissionRequirement(int permissionId, PermissionLevels permissionLevel)
        {
            PermissionId = permissionId;
            PermissionLevel = permissionLevel;
        }
    }
}