using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Interna.Entity;
using System.Web.Services.Protocols;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using System.Text;
using System.Web.Script.Services;
using simihWS.auth;
using System.Web.Script.Serialization;
using System.IdentityModel.Tokens.Jwt;
using Interna.Core;


namespace simihWS.ws
{
    /// <summary>
    /// Descripción breve de SeguridadAzure
    /// </summary>

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class SeguridadAzureWS : System.Web.Services.WebService
    {
        //2022
        [WebMethod]
        public string LoginWeb()
        {
            string respuestaJson = "";

            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];
            string accessToken = authHeader.Substring(7);
            TokenUsuario tokenValido = new TokenUsuario();
            tokenValido.RegistrarTokenPorValidar(accessToken);
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(accessToken);
            var tokenS = jsonToken as JwtSecurityToken;
            var upn = tokenS.Claims.First(claim => claim.Type == "upn").Value;
            var groups = tokenS.Claims.Where(claim => claim.Type == "roles").ToList();
            var ver = tokenS.Claims.First(claim => claim.Type == "ver");

            List<GrupoAzure> grupoAzureList = new List<GrupoAzure>();

            foreach (System.Security.Claims.Claim c in groups)
            {
                GrupoAzure g = new GrupoAzure();
                g.sValorGrupo = c.Value;
                grupoAzureList.Add(g);
            }

            Usuario usuarioBD = new Usuario();
            Casilla oC = new Casilla();
            Interna.Core.Methods oM = new Interna.Core.Methods();

            usuarioBD = usuarioBD.ValidarUsuarioAzure(upn, grupoAzureList, 0);

            if (usuarioBD == null || usuarioBD.ID == 0)
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            usuarioBD.Descripcion = oM.Encriptar(usuarioBD.ID.ToString());
            //usuarioBD.descripcionCasilla = new JavaScriptSerializer().Serialize(oC.CasillaUsuario(usuarioBD.ID));
            usuarioBD.descripcionCasilla = new JavaScriptSerializer().Serialize(oC.BandejasUsuario(usuarioBD.ID));
            usuarioBD.alias = oC.rObtenerConfiguracionls(usuarioBD.idCasilla);
            //usuarioBD.ID = 0;

            List<string> listaGrupos = new List<string>();

            grupoAzureList.ForEach(x => listaGrupos.Add(x.sValorGrupo));

            string[] gruposAzure = listaGrupos.ToArray();

            Dictionary<string, object> sClaims = new Dictionary<string, object>();
            sClaims.Add("upn", upn);
            sClaims.Add("groups", gruposAzure);
            sClaims.Add("casilla", usuarioBD.idCasilla.ToString());
            sClaims.Add("id", usuarioBD.ID.ToString());

            string[] tokens = RequestHandler.TokenBuilder(sClaims);
            Response response = new Response(tokens[0], tokens[1], usuarioBD);
            respuestaJson = new JavaScriptSerializer().Serialize(response);

            TokenUsuario tokenUsuario = new TokenUsuario();
            tokenUsuario.RegistrarTokenUsuario(tokens[0], usuarioBD.ID);

            return respuestaJson;

        }

        //2022
        [WebMethod]
        public string LoginDesktopAzure()
        {
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];
            string accessToken = authHeader.Substring(7);
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(accessToken);
            var tokenS = jsonToken as JwtSecurityToken;
            var upn = tokenS.Claims.First(claim => claim.Type == "upn").Value;
            var groups = tokenS.Claims.Where(claim => claim.Type == "roles").ToList();

            List<GrupoAzure> grupoAzureList = new List<GrupoAzure>();

            foreach (System.Security.Claims.Claim c in groups)
            {
                GrupoAzure g = new GrupoAzure();
                g.sValorGrupo = c.Value;
                grupoAzureList.Add(g);
            }

            ErrorLog errorLog = new ErrorLog();

            Usuario oU = new Usuario();
            try
            {
                Usuario usuarioBD = oU.ValidarUsuarioAzureDesktop(upn, grupoAzureList);
                if (usuarioBD == null || usuarioBD.ID == 0)
                {
                    httpContext.Response.StatusCode = 401;
                    httpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                    return "";
                }


                List<string> listaGrupos = new List<string>();

                grupoAzureList.ForEach(x => listaGrupos.Add(x.sValorGrupo));

                string[] gruposAzure = listaGrupos.ToArray();

                Dictionary<string, object> sClaims = new Dictionary<string, object>();
                sClaims.Add("upn", upn);
                sClaims.Add("groups", gruposAzure);
                sClaims.Add("casilla", usuarioBD.idCasilla.ToString());
                sClaims.Add("id", usuarioBD.ID.ToString());

                string[] tokens = RequestHandler.TokenBuilder(sClaims);
                Response response = new Response(tokens[0], tokens[1], usuarioBD);
                string respuestaJson = new JavaScriptSerializer().Serialize(response);

                TokenUsuario tokenUsuario = new TokenUsuario();
                tokenUsuario.RegistrarTokenUsuario(tokens[0], usuarioBD.ID);
                return respuestaJson;
            }
            catch(Exception ex)
            {
                errorLog.EscribirLog(ex);
                return "";
            }
            

            
        }




    }
}
