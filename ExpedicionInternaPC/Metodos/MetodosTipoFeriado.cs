using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static List<TipoFeriado> ListarTiposFeriado()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoFeriadoWS + "ListarTiposFeriado", null);
                return deserializarPrueba<TipoFeriado>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
