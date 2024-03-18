using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static List<TipoResponsable> ListarTipoResponsableActivo()
        {
            //ServiceTipoResponsableWS.TipoResponsableWS tipoResponsableWS = new ServiceTipoResponsableWS.TipoResponsableWS();
            //return deserializarPrueba<TipoResponsable>(tipoResponsableWS.ListarTipoResponsableActivo());

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoResponsableWS + "ListarTipoResponsableActivo", null);

                return deserializarPrueba<TipoResponsable>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
