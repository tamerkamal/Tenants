using Base.Helpers.Constants;

namespace Tenants.Api.Security.AuthorizeAttribute
{

    /// <summary>
    /// 
    /// </summary>
    public class Authorize : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {

        /// <summary>
        /// Creates a new instance of <see cref="Authorize"/> class.
        /// </summary>
        /// <param name="PolicyCode">PolicyCode</param>

        public Authorize(string PolicyCode)
        {
            Policy = $"{AuthorizePolicy.PolicyPrefix}{"|" + PolicyCode }";
        }
    }
}