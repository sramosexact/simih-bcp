using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public partial class Metodos
    {
        //2022
        public static List<Interna.Entity.TipoExpedicion> ListarTipoExpedicion()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoExpedicionWS + "ListarTipoExpedicion", null);

                return deserializarPrueba<Interna.Entity.TipoExpedicion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

    }
}
