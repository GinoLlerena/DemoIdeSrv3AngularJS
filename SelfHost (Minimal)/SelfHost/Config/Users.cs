using System.Collections.Generic;
using System.Security.Claims;
using Thinktecture.IdentityServer.Core;
using Thinktecture.IdentityServer.Core.Services.InMemory;

namespace SelfHost.Config
{
    static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>
            {
                new InMemoryUser{Subject = "1", Username = "pedro", Password = "pedro",
                    Claims = new Claim[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "Pedro Palotes"),
                        new Claim(Constants.ClaimTypes.GivenName, "Pedro"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Palotes"),
                        new Claim(Constants.ClaimTypes.Email, "pedropalotes@email.com"),
                        new Claim(Constants.ClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(Constants.ClaimTypes.Role, "Admin"),
                        new Claim(Constants.ClaimTypes.Role, "Operator"),
                        new Claim(Constants.ClaimTypes.WebSite, "http://pedropalotes.com"),
                        new Claim(Constants.ClaimTypes.Address, "{ \"street_address\": \"La Calle del Camino\", \"locality\": \"Trujillo\", \"postal_code\": 5144, \"country\": \"Perú\" }")
                    }
                },
                new InMemoryUser{Subject = "2", Username = "fulano", Password = "fulano",
                    Claims = new Claim[]
                    {
                        new Claim(Constants.ClaimTypes.Name, "Fulano Ortega"),
                        new Claim(Constants.ClaimTypes.GivenName, "Fulano"),
                        new Claim(Constants.ClaimTypes.FamilyName, "Ortega"),
                        new Claim(Constants.ClaimTypes.Email, "fulanoortega@email.com"),
                        new Claim(Constants.ClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(Constants.ClaimTypes.Role, "Developer"),
                        new Claim(Constants.ClaimTypes.Role, "Geek"),
                        new Claim(Constants.ClaimTypes.WebSite, "http://fulanoortega.com"),
                        new Claim(Constants.ClaimTypes.Address, "{ \"street_address\": \"La Calle del Camino\", \"locality\": \"Trujillo\", \"postal_code\": 5144, \"country\": \"Perú\" }")
                    }
                },
            };
        }
    }
}