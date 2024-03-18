using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Interna.Entity;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de MensajeriaWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class MensajeriaWS : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Mensajeria> GetListaMensajeria()
        {
            Mensajeria lM = new Mensajeria();           
            return lM.oListaMensajeria();

        }
        [WebMethod]
        public List<Mensajeria> getListaTipoMensajeria(int tipoEntrega)
        {            
            Mensajeria lM = new Mensajeria();
            List<Mensajeria> lista = new List<Mensajeria>();
            lista = lM.oListaTipoMensajeria(tipoEntrega);
            return lista;
        }
        /*Cesar 21/02/2014*/
        [WebMethod]
        public List<Mensajeria> getMensajeriaServicio()
        {
            Mensajeria M = new Mensajeria();
            List<Mensajeria> lista = new List<Mensajeria>();
            lista = M.rMensajeriaServicio();
            return lista;
            
        }
    }
}
