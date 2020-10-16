using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CWM.StoreManager.Backend.WebApi
{
    public class Config
    {
        public static IEnumerable<IdentityResource> Ids
        {
            get
            {
                return new IdentityResource[]
                {
                            new IdentityResources.OpenId(),
                            new IdentityResources.Profile()
                };
            }
        }

        public static IEnumerable<ApiScope> GetApiResources()
        {
            return new List<ApiScope>
            {
                new ApiScope("StoreManagerApi","API for StoreManager")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "StoreManagerApi" }
                }
            };
        }
    }
}
