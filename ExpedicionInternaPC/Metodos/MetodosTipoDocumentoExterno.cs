using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static List<TipoDocumentoExterno> ListarTipoDocumentoExterno()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoDocumentoExternoWS + "ListarTipoDocumentoExterno", null);

                return deserializarPrueba<TipoDocumentoExterno>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
