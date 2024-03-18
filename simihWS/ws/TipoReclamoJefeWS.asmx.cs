using Interna.Entity;
using System.Web.Services;

namespace simihWS.ws
{
    /// <summary>
    /// Descripción breve de TipoReclamoJefeWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class TipoReclamoJefeWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string ListarTiposReclamoJefe()
        {
            TipoReclamoJefe tipoReclamoJefe = new TipoReclamoJefe();
            return tipoReclamoJefe.ListarTiposReclamoJefe();
        }
    }
}
