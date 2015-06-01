using System.Collections.Generic;
using System.Linq;
using Thinktecture.IdentityServer.Core;
using Thinktecture.IdentityServer.Core.Models;

namespace Thinktecture.IdentityServer.Host.Config
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new[]
                {
                    ////////////////////////
                    // identity scopes
                    ////////////////////////

                    StandardScopes.OpenId,
                    StandardScopes.Profile,
                    StandardScopes.Email,
                    
                    ////////////////////////
                    // resource scopes
                    ////////////////////////
                    new Scope
                    {
                        Name = "webapi",
                        DisplayName = "IdentityManager",
                        Type = ScopeType.Resource,
                        Emphasize = true,
                        ShowInDiscoveryDocument = false,
                        
                        Claims = new List<ScopeClaim>
                        {
                            new ScopeClaim(Constants.ClaimTypes.Name),
                            new ScopeClaim(Constants.ClaimTypes.Role)
                        }
                    }
                };
        }
    }
}