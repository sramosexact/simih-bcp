using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static List<TipoUsuario> ListarTipoUsuario(TipoUsuario oTipoUsuario)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoUsuarioWS + "ListarTipoUsuario", new Dictionary<string, object>(){
                    {"tipoUsuario", oTipoUsuario}
                });

                return deserializarPrueba<TipoUsuario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
    }
}
