using Interna.Entity;
using System.Collections.Generic;


namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static List<TipoReclamoJefe> ListarTiposReclamoJefe()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoReclamoJefeWS + "ListarTiposReclamoJefe", null);

                return deserializarPrueba<TipoReclamoJefe>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
