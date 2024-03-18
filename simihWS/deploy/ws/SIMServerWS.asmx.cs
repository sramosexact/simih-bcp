using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Interna.Entity;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de SIMServerWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class SIMServerWS : System.Web.Services.WebService
    {

        [WebMethod]
        public int LoginPC( Mensaje oM  )
        {
            // registrar la IP en la tabla para contactar
            return oM.cLogin();
        }

        [WebMethod]
        public int LogoutPC(Mensaje oM)
        {
            // eliminar la IP en la tabla para contactar
            return oM.cLogout();
        }

        [WebMethod]
        public int SendMessage( Mensaje oM )
        {
            // manda un mensaje para todos
            return oM.cMensaje();
        }
    }
}
