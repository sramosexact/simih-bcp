using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Interna.Entity;
using simihWS.Helper;

namespace simihWS
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]    
    [System.Web.Script.Services.ScriptService]
    public class MotivoCambioEstadoWS : System.Web.Services.WebService
    {
        //2022
        [WebMethod]
        public string ListarMotivoCambioEstadoPorTipoEstado(int iIdTipoEstado)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            MotivoCambioEstado motivoCambioEstado = new MotivoCambioEstado();
            return motivoCambioEstado.ListarMotivoCambioEstadoPorTipoEstado(iIdTipoEstado);
        }
    }
}
