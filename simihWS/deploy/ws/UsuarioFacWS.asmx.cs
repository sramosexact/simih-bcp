using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de UsuarioFacWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class UsuarioFacWS : System.Web.Services.WebService
    {
        [WebMethod]
        public List<Interna.Entity.UsuarioFac> ConsultaTotal(int RecordIndex, int PageWidth)
        {
            Interna.Entity.UsuarioFac oUsuario = new Interna.Entity.UsuarioFac();
            return oUsuario.rConsultaTotal(RecordIndex, PageWidth);
        }

        [WebMethod]
        public int ConsultaTotalCONTAR()
        {
            Interna.Entity.UsuarioFac oUsuario = new Interna.Entity.UsuarioFac();

            return oUsuario.rConsultaTotalCONTAR();
        }
        /*Implementado 01/10/2015*/
        [WebMethod]
        public List<String> ConsultaTotalJson()
        {
            Interna.Entity.UsuarioFac oUsuario = new Interna.Entity.UsuarioFac();
            return oUsuario.rConsultaTotalJson();
        }
    }
}
