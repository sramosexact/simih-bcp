using Microsoft.Owin;
using System.Threading.Tasks;

namespace simihWS.middlewares
{
    public class AuthenticationMiddleware : OwinMiddleware
    {

        public AuthenticationMiddleware(OwinMiddleware next) : base(next)
        {

        }


        public async override Task Invoke(IOwinContext httpContext)
        {
            string authHeader = httpContext.Request.Headers["Authorization"];

            if (authHeader == null)
            {

                httpContext.Response.StatusCode = 401;
                httpContext.Response.Headers.Add("WWW-Authenticate", new string[] { "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"" });
                return;
            }

            if (!authHeader.Contains("Basic"))
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.Headers.Add("WWW-Authenticate", new string[] { "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"" });
                return;
            }

            await Next.Invoke(httpContext);
        }
    }
}