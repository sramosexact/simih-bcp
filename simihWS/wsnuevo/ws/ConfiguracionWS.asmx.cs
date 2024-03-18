using Interna.Entity;
using simihWS.Helper;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de ConfiguracionWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ConfiguracionWS : System.Web.Services.WebService
    {

        [WebMethod]
        public int setConfiguracion(Interna.Entity.Configuracion oC)
        {
            return oC.uConfiguracion();
        }

        [WebMethod]
        public List<Configuracion> getConfiguracion(int ID)
        {
            Configuracion oC = new Configuracion();
            oC.ID = ID;
            return oC.rConfiguracion();
        }
        //2022
        [WebMethod]
        public string ListarIndicadores()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }
            Configuracion configuracion = new Configuracion();
            return configuracion.ListarIndicadores();
        }

        [WebMethod]
        public int ModificarIndicador(int iId, int fValor)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }
            Configuracion configuracion = new Configuracion();
            return configuracion.ModificarIndicador(iId, fValor);
        }
        //2022
        [WebMethod]
        public string ListarDiasConfirmacionAutomatica()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }
            Configuracion configuracion = new Configuracion();
            return configuracion.ListarDiasConfirmacionAutomatica();
        }


    }
}
