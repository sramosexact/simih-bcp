
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Text;
using Interna.Entity;
using System;
using System.Messaging;

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
        private string queuePathEntregaPisos = System.Web.Configuration.WebConfigurationManager.AppSettings.GetValues("queuePathEntregaPisos")[0];
        //2022
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ListarClientes()
        {
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            string clientesJson = new JavaScriptSerializer().Serialize(oU.rListadoCliente("0"));

            //string queuePath = ".\\private$\\notificacionEntregaEnBandeja";
            string queuePath = queuePathEntregaPisos;
            //string mensaje = clientesJson;
            string mensaje = queuePathEntregaPisos;
            using (MessageQueue queue = new MessageQueue(queuePath))
            {
                Message message = new Message();
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
                message.Body = mensaje;


                queue.Send(message);
                Console.WriteLine("Mensaje enviado: " + mensaje);
            }

            return clientesJson;
        }

        



    }
}
