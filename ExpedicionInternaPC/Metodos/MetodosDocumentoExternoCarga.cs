using Interna.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static List<DocumentoExterno> CargarDocumentosExternos(byte IdTipoDocumento, string XmlDocumentosExternos)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.DocumentoExternoCargaWS + "CargarDocumentosExternos", new Dictionary<string, object>() {
                    { "IdExpedicion", (byte)Program.oUsuario.IdExpedicion},
                    { "IdUsuario", Program.oUsuario.ID},
                    { "IdCasillaOrigen", Program.oUsuario.idCasilla},
                    { "IdTipoDocumentoExterno", IdTipoDocumento},
                    { "XmlDocumentosExternos", XmlDocumentosExternos}
                });

                return JsonConvert.DeserializeObject<List<DocumentoExterno>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<DocumentoExterno> CargarDocumentosExternosLote(byte IdTipoDocumento, string XmlDocumentosExternos)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.DocumentoExternoCargaWS + "CargarDocumentosExternosLote", new Dictionary<string, object>() {
                    { "IdExpedicion", (byte)Program.oUsuario.IdExpedicion},
                    { "IdUsuario", Program.oUsuario.ID},
                    { "IdCasillaOrigen", Program.oUsuario.idCasilla},
                    { "IdTipoDocumentoExterno", IdTipoDocumento},
                    { "XmlDocumentosExternos", XmlDocumentosExternos}
                });

                return JsonConvert.DeserializeObject<List<DocumentoExterno>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<DocumentoExterno> RetirarListaDocumentosExternos(string documentosJson)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.DocumentoExternoCargaWS + "RetirarDocumentosExternos", new Dictionary<string, object>(){
                    { "documentos", documentosJson}
                });
                return JsonConvert.DeserializeObject<List<DocumentoExterno>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

    }
}
