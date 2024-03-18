using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Interna.Entity;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de MonedaWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class MonedaWS : System.Web.Services.WebService
    {
        //2022
        [WebMethod]
        public string ListarMonedasMesaDePartes() 
        {
            Moneda oMoneda = new Moneda();
            return oMoneda.ListarMonedasMesaDePartes();
        }
    }
}
