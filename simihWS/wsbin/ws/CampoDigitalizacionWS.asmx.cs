using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Interna.Entity;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de CampoDigitalizacionWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class CampoDigitalizacionWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string ListarCamposPorTipoDocumento(short IdTipoDocumento)
        {
            TipoDocumento oTipoDocumento = new TipoDocumento();
            oTipoDocumento.iIdTipoDocumento = IdTipoDocumento;
            CampoDigitalizacion oCampoDigitalizacion = new CampoDigitalizacion();
            return oCampoDigitalizacion.ListarCamposPorTipoDocumento(oTipoDocumento);
        }

        [WebMethod]
        public string ListarCamposActivosPorTipoDocumento(short IdTipoDocumento)
        {
            TipoDocumento oTipoDocumento = new TipoDocumento();
            oTipoDocumento.iIdTipoDocumento = IdTipoDocumento;
            CampoDigitalizacion oCampoDigitalizacion = new CampoDigitalizacion();
            return oCampoDigitalizacion.ListarCamposActivosPorTipoDocumento(oTipoDocumento);
        }
    }
}
