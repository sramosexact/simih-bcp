using Interna.Entity;
using System.Collections.Generic;


namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static List<CampoDigitalizacion> ListarCamposPorTipoDocumento(TipoDocumento oTipoDocumento)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CampoDigitalizacionWS + "ListarCamposPorTipoDocumento", new Dictionary<string, object>(){
                    {"IdTipoDocumento", oTipoDocumento.iIdTipoDocumento}
                });

                return deserializarPrueba<CampoDigitalizacion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<CampoDigitalizacion> ListarCamposActivosPorTipoDocumento(TipoDocumento oTipoDocumento)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CampoDigitalizacionWS + "ListarCamposActivosPorTipoDocumento", new Dictionary<string, object>(){
                    {"IdTipoDocumento", oTipoDocumento.iIdTipoDocumento}
                });

                return deserializarPrueba<CampoDigitalizacion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
