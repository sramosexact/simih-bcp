using Interna.Entity;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Summary description for CampoExternoWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CampoExternoWS : System.Web.Services.WebService
    {
        // Funcional - frmDocumentosProcesados
        [WebMethod]
        public string ListarDetalleDocumento(int IdDocumento)
        {
            CampoExterno campoExterno = new CampoExterno();
            return campoExterno.ListarDetalleDocumento(IdDocumento);
        }
    }
}
