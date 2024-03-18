
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace simihWS.ws
{
    /// <summary>
    /// Descripción breve de PublicWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    //Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class PublicWS : System.Web.Services.WebService
    {
        //2022
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarClientes()
        {
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            string clientesJson = new JavaScriptSerializer().Serialize(oU.rListadoCliente("0"));
            return clientesJson;
        }



    }
}
