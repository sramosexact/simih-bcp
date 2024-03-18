using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static List<TipoReclamoUsuario> ListarTipoReclamoUsuario()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoReclamoUsuarioWS + "ListarTipoReclamoUsuario", null);

                return deserializarPrueba<TipoReclamoUsuario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
