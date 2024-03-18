using Interna.Entity;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de CampoTipoDocumentoWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class CampoTipoDocumentoWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string ListarCamposTipoDocumento(CampoTipoDocumento oCampoTipoDocumento)
        {
            return oCampoTipoDocumento.ListarCamposTipoDocumento();
        }
    }
}
