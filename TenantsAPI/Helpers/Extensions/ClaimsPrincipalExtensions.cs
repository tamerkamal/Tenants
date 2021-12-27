using TenantsAPI.Helper.Constants;
using System;
using System.Security.Claims;

namespace TenantsAPI.Helper.Extensions
{
    /// <summary>
    /// Add extension methods to <see cref="ClaimsPrincipal"/>
    /// </summary>
    public static class ClaimsPrincipalExtensions
    {
        /// <summary>
        /// Get logged-in username
        /// </summary>
        /// <param name="principal">ClaimsPrincipal</param>
        /// <returns>Return the logged-in username</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string GetLoggedInUserName(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var claim = principal.FindFirst(TenantsAPIClaimTypes.UserName);
            if (claim == null)
                throw new ArgumentNullException($@"Current username cannot be empty.");

            return claim.Value;
        }
    }
}