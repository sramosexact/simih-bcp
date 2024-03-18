using JWT;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Configuration;

namespace simihWS.auth
{
    public static class RequestHandler
    {
        public static string[] TokenBuilder(Dictionary<string, object> tokenClaims)
        {
            var token = new JwtBuilder()
                  .WithAlgorithm(new HMACSHA256Algorithm())
                  .WithSecret(AppKey.SECRET)
                  .Issuer("https://localhost:44342")
                  .Audience("57b3789e-9a55-4324-b028-f4460c70f468");
            if (tokenClaims != null)
            {
                foreach (KeyValuePair<string, object> tokenClaim in tokenClaims)
                {
                    token.AddClaim(tokenClaim.Key, tokenClaim.Value);
                }
            }

            token.AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(Convert.ToDouble(WebConfigurationManager.AppSettings.GetValues("expToken")[0].ToString())).ToUnixTimeSeconds());

            JwtBuilder refreshJWRToken = new JwtBuilder();
            refreshJWRToken.WithAlgorithm(new HMACSHA256Algorithm());
            refreshJWRToken.WithSecret(AppKey.SECRET);
            refreshJWRToken.Issuer("https://localhost:44342");
            refreshJWRToken.Audience("57b3789e-9a55-4324-b028-f4460c70f468");
            refreshJWRToken.AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(Convert.ToDouble(WebConfigurationManager.AppSettings.GetValues("expRefreshToken")[0].ToString())).ToUnixTimeSeconds());

            if (tokenClaims != null)
            {
                foreach (KeyValuePair<string, object> tokenClaim in tokenClaims)
                {
                    refreshJWRToken.AddClaim(tokenClaim.Key, tokenClaim.Value);
                }
            }

            var refreshToken = refreshJWRToken.Build();

            return new string[2] { token.Build(), refreshToken };
        }

        public static bool ValidateToken(IOwinContext httpContext)
        {
            string authHeader = httpContext.Request.Headers["Authorization"];

            if (authHeader == null)
            {

                httpContext.Response.StatusCode = 401;
                httpContext.Response.Headers.Add("WWW-Authenticate", new string[] { "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"" });
                return false;
            }

            if (!authHeader.Contains("Bearer"))
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.Headers.Add("WWW-Authenticate", new string[] { "Bearer realm=\"Acceso al SIMIH\" error_description=\"No tiene token de acceso\"" });
                return false;
            }

            string accessToken64 = authHeader.Substring(7);
            byte[] accessTokenByte = Convert.FromBase64String(accessToken64);
            string accessToken = Encoding.ASCII.GetString(accessTokenByte);

            try
            {
                var json = new JwtBuilder()
                    .WithSecret(AppKey.SECRET)
                    .Issuer("https://localhost:44342")
                    .Audience("57b3789e-9a55-4324-b028-f4460c70f468")
                    .MustVerifySignature()
                    .Decode(accessToken);


                //TokenUsuario tokenInvalido = new TokenUsuario();

                //if (tokenInvalido.VerificarTokenUsuario(accessToken).Estado == 0)
                //{
                //    httpContext.Response.StatusCode = 894;
                //    httpContext.Response.ReasonPhrase = "Token inválido";
                //    httpContext.Response.Headers.Add("WWW-Authenticate", new string[] { "Bearer realm=\"Acceso al SIMIH\" error_description=\"El token es invalido\"" });
                //    return false;
                //}

                return true;

            }
            catch (TokenExpiredException)
            {
                httpContext.Response.StatusCode = 498;
                httpContext.Response.ReasonPhrase = "Token expirado";
                httpContext.Response.Headers.Add("WWW-Authenticate", new string[] { "Bearer realm=\"Acceso al SIMIH\" error_description=\"El token ha expirado\"" });
                return false;

            }
            catch (SignatureVerificationException)
            {
                httpContext.Response.StatusCode = 894;
                httpContext.Response.ReasonPhrase = "Token inválido";
                httpContext.Response.Headers.Add("WWW-Authenticate", new string[] { "Bearer realm=\"Acceso al SIMIH\" error_description=\"El token es invalido\"" });
                return false;
            }
        }
    }
}