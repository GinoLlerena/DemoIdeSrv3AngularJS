using System.Linq;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Owin.ResourceAuthorization;

namespace Sistemas.WebResources
{
    public class AuthorizationManager : ResourceAuthorizationManager
    {
        public override Task<bool> CheckAccessAsync(ResourceAuthorizationContext context)
        {
            switch (context.Resource.First().Value)
            {
                case "Unidades":
                    return AuthorizeUnidades(context);
                default:
                    return Nok();
            }
        }

        private Task<bool> AuthorizeUnidades(ResourceAuthorizationContext context)
        {
            switch (context.Action.First().Value)
            {
                case "Read":
                    return Eval(context.Principal.HasClaim("role", "Operator") || context.Principal.HasClaim("role", "Geek"));
                case "Write":
                    return Eval(context.Principal.HasClaim("role", "Geek"));
                default:
                    return Nok();
            }
        }
    }
}