using Interna.Core;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace simihWS.middlewares
{
    public class AzureAuthenticationMiddleware : OwinMiddleware
    {
        public string Domain = System.Web.Configuration.WebConfigurationManager.AppSettings.GetValues("Domain")[0];
        public string Audience = System.Web.Configuration.WebConfigurationManager.AppSettings.GetValues("Audience")[0];

        public AzureAuthenticationMiddleware(OwinMiddleware next) : base(next)
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

            if (!authHeader.Contains("Bearer"))
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.Headers.Add("WWW-Authenticate", new string[] { "Bearer realm=\"Acceso al SIMIH\" error_description=\"No tiene token de acceso\"" });
                return;
            }

            string token = authHeader.Substring(7);
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var ver = tokenS.Claims.First(claim => claim.Type == "ver").Value;
            var iss = tokenS.Claims.First(claim => claim.Type == "iss").Value;

            ErrorLog errorLog = new ErrorLog();
            string auth0Domain = Domain;
            string auth0Audience = "";
            string UrlDocumentoDescubrimiento = "";

            if (ver == "2.0")
            {
                auth0Audience = Audience;
                UrlDocumentoDescubrimiento = $@"https://login.microsoftonline.com/{auth0Domain}/v2.0/.well-known/openid-configuration";
            }
            else
            {
                auth0Audience = $@"api://{Audience}";
                if (iss.Contains("sts.windows.net"))
                {
                    UrlDocumentoDescubrimiento = $@"https://sts.windows.net/{auth0Domain}/.well-known/openid-configuration";
                }
                else
                {
                    UrlDocumentoDescubrimiento = $@"https://login.microsoftonline.com/{auth0Domain}/.well-known/openid-configuration";
                }

            }

            var stsDiscoveryEndpoint = String.Format(CultureInfo.InvariantCulture, UrlDocumentoDescubrimiento, auth0Domain);//String.Format(CultureInfo.InvariantCulture, UrlDocumentoDescubrimiento, auth0Domain);
            OpenIdConnectConfiguration openIdConfig;

            try
            {
                IConfigurationManager<OpenIdConnectConfiguration> configurationManager =
                new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint, new OpenIdConnectConfigurationRetriever());
                openIdConfig = await configurationManager.GetConfigurationAsync(CancellationToken.None);
            }
            catch (Exception ex)
            {
                errorLog.EscribirLog(ex);
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ReasonPhrase = "Error de Servidor";
                httpContext.Response.Headers.Add("WWW-Authenticate", new string[] { "Bearer realm=\"Acceso al SIMIH\" error_description=\"Error de Servidor\"" });
                return;
            }

            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidIssuer = openIdConfig.Issuer,
                ValidAudience = auth0Audience,
                IssuerSigningKeys = openIdConfig.SigningKeys
            };

            SecurityToken validatedToken;
            JwtSecurityTokenHandler jwtHandler = new JwtSecurityTokenHandler();

            try
            {
                var user = jwtHandler.ValidateToken(token, validationParameters, out validatedToken);
            }
            catch (SecurityTokenExpiredException)
            {
                httpContext.Response.StatusCode = 498;
                httpContext.Response.ReasonPhrase = "Token expirado";
                httpContext.Response.Headers.Add("WWW-Authenticate", new string[] { "Bearer realm=\"Acceso al SIMIH\" error_description=\"El token ha expirado\"" });
                return;
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                httpContext.Response.StatusCode = 894;
                httpContext.Response.ReasonPhrase = "Token inválido";
                httpContext.Response.Headers.Add("WWW-Authenticate", new string[] { "Bearer realm=\"Acceso al SIMIH\" error_description=\"El token es invalido\"" });
                return;
            }
            catch (Exception ex)
            {
                errorLog.EscribirLog(ex);
                httpContext.Response.StatusCode = 500;
                httpContext.Response.ReasonPhrase = "Error de Servidor";
                httpContext.Response.Headers.Add("WWW-Authenticate", new string[] { "Bearer realm=\"Acceso al SIMIH\" error_description=\"Error de Servidor\"" });
                return;
            }

            await Next.Invoke(httpContext);

        }

    }
}