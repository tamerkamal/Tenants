using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Base.Helpers.Constants;

namespace Master.Helpers.Configurations
{
    /// <summary>
    /// Cognito configuration
    /// </summary>
    public static class CognitoConfiguration
    {
        private const string CognitoRegion = "ap-southeast-2";

        //private const string CognitoPoolId = "ap-southeast-2_NjZ95nrt4";
        //private const string CognitoAppClientId = "27cogs037uqrr0m6ptgvracrf7";

        private const string CognitoPoolId = "ap-southeast-2_8Rbr8YYn9";
        private const string CognitoAppClientId = "2vme59ik7qqp9tbln4mmgrmhpm";

        private const string CognitoUsernameClaim = "cognito:username";

        private const string ActiveDirectoryPrefix = "tech2ad_STREAM\\";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureService(IServiceCollection services)
        {
            // Cognito conducts authentication with JSON Web Tokens
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = BuildCognitoTokenValidationParameters();
                    options.Events = BuildCognitoJwtBearerEvents();
                });

            // Add an MVC filter to ensure all methods are authenticated
            services.Configure<MvcOptions>(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void Configure(IApplicationBuilder app)
        {
            // Enable authentication services
            app.UseAuthentication();

            // Enable https redirection
            app.UseHttpsRedirection();
        }

        // Build a TokenValidationParameters object for Cognito
        private static TokenValidationParameters BuildCognitoTokenValidationParameters()
        {
            const string issuer = "https://cognito-idp." + CognitoRegion + ".amazonaws.com/" + CognitoPoolId;

            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateLifetime = true,

                //ValidateAudience = true,
                ValidateAudience = false,

                ValidIssuer = issuer,
                ValidAudience = CognitoAppClientId,
                IssuerSigningKeyResolver = CognitoIssuerSigningKeyResolver
            };
        }

        private static IEnumerable<SecurityKey> CognitoIssuerSigningKeyResolver(string token, SecurityToken securityToken, string kid, TokenValidationParameters parameters)
        {
            // Get JsonWebKeySet from AWS
            var json = new WebClient().DownloadString(parameters.ValidIssuer + "/.well-known/jwks.json");

            // Convert the JSON into an object,and fetch the keys
            return JsonConvert.DeserializeObject<JsonWebKeySet>(json).Keys;
        }

        private static JwtBearerEvents BuildCognitoJwtBearerEvents()
        {
            return new JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    if (context.SecurityToken is JwtSecurityToken)
                    {
                        if (context.Principal.Identity is ClaimsIdentity identity)
                        {
                            // Extract the Cognito claim; it may not be present
                            var username = identity.FindFirst(CognitoUsernameClaim)?.Value;
                            if (!string.IsNullOrEmpty(username))
                            {
                                // Remove the weird active directory prefix
                                if (username.StartsWith(ActiveDirectoryPrefix))
                                    username = username.Substring(ActiveDirectoryPrefix.Length);

                                // Add the official StreamLine username claim
                                identity.AddClaim(new Claim(TenantsClaimTypes.UserName, username));
                            }
                        }
                    }

                    return Task.FromResult(0);
                }
            };
        }
    }
}