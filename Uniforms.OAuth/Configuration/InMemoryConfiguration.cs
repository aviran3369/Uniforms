using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uniforms.OAuth.Configuration
{
    public static class InMemoryConfiguration
    {
        public static IEnumerable<ApiResource> ApiResources()
        {
            return new[] {
                new ApiResource("uniforms", "Uniforms")
            };
        }

        public static IEnumerable<Client> Clients()
        {
            return new[] {
                new Client()
                {
                    ClientId = "uniforms",
                    ClientSecrets = new [] { new Secret("lin.ohana".Sha256() ) },
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = new [] { "uniforms" }
                }
            };
        }

        public static IEnumerable<TestUser> Users()
        {
            return new[] {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "aviran3369@gmail.com",
                    Password = "akO10614@"
                }
            };
        }
    }
}
