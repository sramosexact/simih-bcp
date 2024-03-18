using Interna.Entity;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Summary description for TipoResponsableWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TipoResponsableWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string ListarTipoResponsableActivo()
        {
            TipoResponsable tipoResponsable = new TipoResponsable();
            return tipoResponsable.ListarTipoResponsableActivo();
        }
    }
}
