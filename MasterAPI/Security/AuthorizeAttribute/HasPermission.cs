using Base.Helpers.Constants;
using Base.Helpers.Enums;

namespace Master.Api.Security.AuthorizeAttribute
{
    /// <summary>
    /// 
    /// </summary>
    public class HasPermission : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="HasPermission"/> class.
        /// </summary>
        /// <param name="permissionId">PermissionId</param>
        /// <param name="permissionLevel">PermissionLevels</param>
        public HasPermission(int permissionId, PermissionLevels permissionLevel)
        {
            Policy = $"{Permissions.PolicyPrefix}{"|" + permissionId + "|" + (int)permissionLevel}";
        }
    }
}