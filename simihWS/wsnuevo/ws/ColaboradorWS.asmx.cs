using Interna.Entity;
using System.Collections.Generic;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de ColaboradorWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ColaboradorWS : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Tipo> GetColaborador(Interna.Entity.Colaborador.Colaboradores c)
        {
            Tipo oC = new Tipo();
            return oC.rColaborador(c);
        }
        [WebMethod]
        public Colaborador GetMotorizados()
        {
            Colaborador c = new Colaborador();
            return c;
        }
    }
}
