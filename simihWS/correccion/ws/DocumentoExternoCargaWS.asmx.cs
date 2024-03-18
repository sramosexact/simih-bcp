using Interna.Entity;
using simihWS.Helper;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de DocumentoExternoWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class DocumentoExternoCargaWS : System.Web.Services.WebService
    {
        //2022
        [WebMethod]
        public string CargarDocumentosExternos(byte IdExpedicion, int IdUsuario, int IdCasillaOrigen, byte IdTipoDocumentoExterno, string XmlDocumentosExternos)
        {
            DocumentoExternoCarga oDocumentoExterno = new DocumentoExternoCarga();
            return oDocumentoExterno.CargarDocumentosExternos(IdExpedicion, IdUsuario, IdCasillaOrigen, IdTipoDocumentoExterno, XmlDocumentosExternos);
        }

        //2024
        [WebMethod]
        public string CargarDocumentosExternosLote(byte IdExpedicion, int IdUsuario, int IdCasillaOrigen, byte IdTipoDocumentoExterno, string XmlDocumentosExternos)
        {
            DocumentoExternoCarga oDocumentoExterno = new DocumentoExternoCarga();
            return oDocumentoExterno.CargarDocumentosExternosLote(IdExpedicion, IdUsuario, IdCasillaOrigen, IdTipoDocumentoExterno, XmlDocumentosExternos);
        }

        //2022
        [WebMethod]
        public string RetirarDocumentosExternos(string documentos)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string upn = accessToken.GetUpn();
            DocumentoExternoCarga oDocumentoExterno = new DocumentoExternoCarga();
            return oDocumentoExterno.RetirarDocumentosExternos(upn, documentos);

        }
    }
}
