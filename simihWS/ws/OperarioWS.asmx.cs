using Interna.Entity;
using System.Collections.Generic;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de OperarioWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class OperarioWS : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Operario> GetListaOperario(int expedicion)
        {
            List<Operario> oL = new List<Operario>();
            Operario oOperario = new Operario();
            oOperario.IdExpedicion = expedicion;
            oL = oOperario.oLista(oOperario);
            return oL;
        }

        //2022
        [WebMethod]
        public string GetOperarios(int iExpedicion)
        {
            Operario o = new Operario();
            return o.rListaOperario(iExpedicion);
        }
    }
}
