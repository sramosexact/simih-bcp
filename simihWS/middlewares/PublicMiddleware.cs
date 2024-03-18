using Microsoft.Owin;
using System.Threading.Tasks;

namespace simihWS.middlewares
{
    public class PublicMiddeware : OwinMiddleware
    {
        public PublicMiddeware(OwinMiddleware next) : base(next)
        {

        }

        public async override Task Invoke(IOwinContext httpContext)
        {
            await Next.Invoke(httpContext);
        }
    }
}