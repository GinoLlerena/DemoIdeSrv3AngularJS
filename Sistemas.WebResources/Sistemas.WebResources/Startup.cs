using Owin;
using Microsoft.Owin;
using Thinktecture.IdentityServer.AccessTokenValidation;
using System.IdentityModel.Tokens;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(Sistemas.WebResources.Startup))]

namespace Sistemas.WebResources
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();
            
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://localhost:44333/core",
                RequiredScopes = new[] { "webapi" }
            });

            app.UseResourceAuthorization(new AuthorizationManager());
            
            app.UseWebApi(WebApiConfig.Register());
            

        }


    }
}
