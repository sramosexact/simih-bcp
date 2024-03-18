using Interna.Entity;
using Newtonsoft.Json;
using simihWS.auth;
using simihWS.Helper;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de Auth
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class Auth : System.Web.Services.WebService
    {

        [WebMethod]
        public string refreshToken()
        {

            AccessToken accessToken = new AccessToken(HttpContext.Current);
            string upn = accessToken.GetUpn();
            List<GrupoAzure> grupoAzureList = accessToken.GetGroups();
            string casilla = accessToken.GetCasilla();
            int idUsuario = int.Parse(accessToken.GetIdUsuario());

            List<string> listaGrupos = new List<string>();

            grupoAzureList.ForEach(x => listaGrupos.Add(x.sValorGrupo));
            string[] gruposAzure = listaGrupos.ToArray();

            Dictionary<string, object> sClaims = new Dictionary<string, object>();
            sClaims.Add("upn", upn);
            sClaims.Add("groups", gruposAzure);
            sClaims.Add("casilla", casilla);
            sClaims.Add("id", idUsuario);

            string[] tokens = RequestHandler.TokenBuilder(sClaims);

            Dictionary<string, string> dTokens = new Dictionary<string, string>() {
                {"token",tokens[0] },
                {"refreshToken",tokens[1] }
            };

            TokenUsuario tokenUsuario = new TokenUsuario();
            tokenUsuario.RegistrarTokenUsuario(tokens[0], idUsuario);

            return JsonConvert.SerializeObject(dTokens);
        }
    }
}
