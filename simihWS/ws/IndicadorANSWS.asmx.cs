using Interna.Entity;
using System.Web.Services;

namespace simihWS.ws
{
    /// <summary>
    /// Descripción breve de IndicadorANSWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class IndicadorANSWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string ListarIndicadores(int iIdPeriodo)
        {
            IndicadorANS indicadorANS = new IndicadorANS();
            return indicadorANS.ListarIndicadores(iIdPeriodo);
        }

        [WebMethod]
        public string ListarGestionOportunaDetalle(int iIdPeriodo)
        {
            IndicadorANS indicadorANS = new IndicadorANS();
            return indicadorANS.ListarGestionOportunaDetalle(iIdPeriodo);
        }

        [WebMethod]
        public string ListarEfectividadEntregaDetalle(int iIdPeriodo)
        {
            IndicadorANS indicadorANS = new IndicadorANS();
            return indicadorANS.ListarEfectividadEntregaDetalle(iIdPeriodo);
        }

        [WebMethod]
        public string ListarProcesadosMesaPartesDetalle(int iIdPeriodo)
        {
            IndicadorANS indicadorANS = new IndicadorANS();
            return indicadorANS.ListarProcesadosMesaPartesDetalle(iIdPeriodo);
        }

        [WebMethod]
        public string ListarReportesDeServiciosDetalle(int iIdPeriodo)
        {
            IndicadorANS indicadorANS = new IndicadorANS();
            return indicadorANS.ListarReportesDeServiciosDetalle(iIdPeriodo);
        }
    }
}
