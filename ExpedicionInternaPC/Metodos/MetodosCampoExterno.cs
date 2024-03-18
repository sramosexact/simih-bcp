using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static List<CampoExterno> ListarDetalleDocumento(CampoExterno campoExterno)
        {
            //ServiceCampoExternoWS.CampoExternoWS campoExternoWS = new ServiceCampoExternoWS.CampoExternoWS();
            //ServiceCampoExternoWS.CampoExterno oCampoExternoWS = new ServiceCampoExternoWS.CampoExterno();
            //campoExterno.CopyToObject(oCampoExternoWS);
            //return deserializarPrueba<CampoExterno>(campoExternoWS.ListarDetalleDocumento(oCampoExternoWS)); 

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CampoExternoWS + "ListarDetalleDocumento", new Dictionary<string, object>(){
                    {"IdDocumento", campoExterno.iIdDocumento}
                });

                return deserializarPrueba<CampoExterno>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
