using Interna.Entity;
using System;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Summary description for TipoReclamoUTDWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TipoReclamoUTDWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string ListarTipoReclamoUTDActivo()
        {
            TipoReclamoUTD tipoReclamoUTD = new TipoReclamoUTD();
            return tipoReclamoUTD.ListarTipoReclamoUTDActivo();
        }

        [WebMethod]
        public string ListarResumenTipoReclamoMes(DateTime fecha)
        {
            TipoReclamoUTD tipoReclamoUTD = new TipoReclamoUTD();
            return tipoReclamoUTD.ListarResumenTipoReclamoMes(fecha);
        }

        [WebMethod]
        public string ListarCantidadPorTiposReclamo(DateTime fechaInicio, DateTime fechaFin)
        {
            TipoReclamoUTD tipoReclamoUTD = new TipoReclamoUTD();
            return tipoReclamoUTD.ListarCantidadPorTiposReclamo(fechaInicio, fechaFin);
        }




    }
}
