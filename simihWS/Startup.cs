using Microsoft.Owin;
using Owin;
using simihWS.middlewares;
//using System.Web.Cors;

[assembly: OwinStartup(typeof(simihWS.Startup))]

namespace simihWS
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            app.Map("/ws/PublicWS.asmx", app2 =>
            {
                app2.Use(typeof(PublicMiddeware));
            });

            app.Map("/ws/SeguridadWS.asmx", app3 =>
            {

                app3.Use(typeof(AuthenticationMiddleware));

            });

            app.Map("/ws/SeguridadAzureWS.asmx", app4 =>
            {
                app4.Use(typeof(AzureAuthenticationMiddleware));
            });


            app.Use(typeof(AuthorizationMiddleware));
        }
    }
}
