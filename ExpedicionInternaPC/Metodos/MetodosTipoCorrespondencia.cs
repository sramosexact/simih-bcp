using Interna.Entity;
using System.Collections.Generic;


namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //private static ServiceTipoCorrespondenciaWS.TipoCorrespondenciaWS oTipoCorrespondenciaWS = new ServiceTipoCorrespondenciaWS.TipoCorrespondenciaWS();

        //2022
        public static List<TipoCorrespondencia> ListarTiposCorrespondenciaEnMesaDePartes()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoCorrespondenciaWS + "ListarTiposCorrespondenciaEnMesaDePartes", null);

                return deserializarPrueba<TipoCorrespondencia>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<TipoCorrespondencia> ListarTipoCorrespondencia()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoCorrespondenciaWS + "ListarTipoCorrespondencia", null);

                return deserializarPrueba<TipoCorrespondencia>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
