using Interna.Entity;
using System.Collections.Generic;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de ServicioWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ServicioWS : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Servicio> getServicio()
        {
            Servicio oS = new Servicio();
            return oS.rServicio();
        }
        [WebMethod]
        public int setMantenimiento()
        {
            Mensaje oM = new Mensaje();
            return oM.rProcesoMantenimiento();
        }

    }
}
