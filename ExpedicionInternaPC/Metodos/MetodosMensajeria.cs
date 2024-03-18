using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {

        /*CESAR 21/02/2014*/
        public static List<Mensajeria> ListarMensajeriaServicio()
        {


            try
            {
                string response = Requester.AuthorizationTask(RutaWS.MensajeriaWS + "getMensajeriaServicio", null);

                return deserializarPrueba<Mensajeria>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

    }
}
