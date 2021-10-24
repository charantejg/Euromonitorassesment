using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer.Data
{
    public static class Config
    {
        public static List<Client> Clients = new List<Client>
        {
               // used for the Single page application
                new Client
                {
                    ClientId = "bookSubscribe-web",
                    AllowedGrantTypes = new List<string> { GrantType.AuthorizationCode },
                    RequireClientSecret = false,
                    RequireConsent = false,
                    RedirectUris = new List<string> { "http://localhost:4200/signin-callback.html" },
                    PostLogoutRedirectUris = new List<string> { "http://localhost:4200/" },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "bookSubscribe-web", "write", "read", "openid", "profile", "email" },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:4200",
                    },
                    AccessTokenLifetime = 86400
                },
                // used for third party
                new Client
                {
                    ClientId = "bookSubscribe-third-party",
                    AllowedGrantTypes = new List<string> { GrantType.ClientCredentials },
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "OnlineBookSubscription-api" },
                    AccessTokenLifetime = 86400
                }
        };

        public static List<ApiResource> ApiResources = new List<ApiResource>
        {
            new ApiResource
            {
                Name = "OnlineBookSubscription-api",
                DisplayName = "Online book subscription API",
                Scopes = new List<string>
                {
                    "write",
                    "read"
                }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes = new List<ApiScope>
        {
            new ApiScope("openid"),
            new ApiScope("profile"),
            new ApiScope("email"),
            new ApiScope("read"),
            new ApiScope("write"),
            new ApiScope("OnlineBookSubscription-api")
        };
    }
}
