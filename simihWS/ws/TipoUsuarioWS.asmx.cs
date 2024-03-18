using Interna.Entity;
using simihWS.Helper;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de TipoUsuarioWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class TipoUsuarioWS : System.Web.Services.WebService
    {

        //2022
        [WebMethod]
        public string ListarTipoUsuario(TipoUsuario tipoUsuario)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            return tipoUsuario.ListarTipoUsuario();
        }
    }
}
