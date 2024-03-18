using Interna.Entity;
using System.Web.Services;


namespace simihWS.ws
{
    /// <summary>
    /// Descripción breve de ReportePeriodoWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ReportePeriodoWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string ListarReportesPeriodo(int iIdPeriodo)
        {
            ReportePeriodo reportePeriodo = new ReportePeriodo(iIdPeriodo);
            return reportePeriodo.ListarReportesPeriodo();
        }



        [WebMethod]
        public int ActualizarReportesPeriodo(string sListaEstadosReporte)
        {
            ReportePeriodo reportePeriodo = new ReportePeriodo();
            return reportePeriodo.ActualizarReportesPeriodo(sListaEstadosReporte);
        }
    }
}
