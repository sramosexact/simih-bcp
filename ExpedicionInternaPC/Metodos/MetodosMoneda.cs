using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {

        //2022
        public static List<Moneda> ListarMonedasMesaDePartes()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.MonedaWS + "ListarMonedasMesaDePartes", null);

                return deserializarPrueba<Moneda>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

    }
}
