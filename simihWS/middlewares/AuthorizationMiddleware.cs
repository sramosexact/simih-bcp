using Microsoft.Owin;
using simihWS.auth;
using System.Threading.Tasks;

namespace simihWS.middlewares
{
    public class AuthorizationMiddleware : OwinMiddleware
    {
        public AuthorizationMiddleware(OwinMiddleware next) : base(next)
        {

        }

        public async override Task Invoke(IOwinContext httpContext)
        {
            if (RequestHandler.ValidateToken(httpContext))
            {
                await Next.Invoke(httpContext);
            }
            else
            {
                return;
            }
        }
    }
}