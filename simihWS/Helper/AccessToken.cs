using Interna.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Web;

namespace simihWS.Helper
{
    public class AccessToken
    {
        HttpContext httpContext;
        JwtSecurityToken tokenS;
        private string accessTokenString = "";
        public AccessToken(HttpContext httpContext)
        {
            this.httpContext = httpContext;
            string authHeader = httpContext.Request.Headers["Authorization"];

            string accessToken64 = authHeader.Substring(7);
            byte[] accessTokenByte = Convert.FromBase64String(accessToken64);
            string accessToken = Encoding.ASCII.GetString(accessTokenByte);
            accessTokenString = accessToken;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(accessToken);
            tokenS = jsonToken as JwtSecurityToken;
        }

        public string GetUpn()
        {
            return tokenS.Claims.First(claim => claim.Type == "upn").Value;
        }

        public List<GrupoAzure> GetGroups()
        {
            List<GrupoAzure> grupoAzureList = new List<GrupoAzure>();

            List<System.Security.Claims.Claim> groups = tokenS.Claims.Where(claim => claim.Type == "groups").ToList();

            foreach (System.Security.Claims.Claim c in groups)
            {
                GrupoAzure g = new GrupoAzure();
                g.sValorGrupo = c.Value;
                grupoAzureList.Add(g);
            }
            return grupoAzureList;
        }

        public string GetCasilla()
        {
            return tokenS.Claims.First(claim => claim.Type == "casilla").Value;
        }

        public string GetAccessToken()
        {
            return this.accessTokenString;
        }

        public string GetIdUsuario()
        {
            return tokenS.Claims.First(claim => claim.Type == "id").Value;
        }
    }
}