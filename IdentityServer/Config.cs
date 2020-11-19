using IdentityServer4.Models;

using System.Collections.Generic;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiScope> GetApiScope()
        {
            return new List<ApiScope>
            {
                new ApiScope("apiscope")

            };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource()
                {
                    Name="myresourceapi",
                    DisplayName="My Resource API",
                    Scopes = new List<string>
                    {
                        "apiscope",

                    }
                },
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // for public api
                new Client
                {
                    ClientId = "secret_client_id",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "apiscope" }
                },
            };
        }
    }
}
