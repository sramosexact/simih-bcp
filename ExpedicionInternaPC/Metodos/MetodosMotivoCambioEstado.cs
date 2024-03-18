using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static List<MotivoCambioEstado> ListarMotivoCambioEstadoPorTipoEstado(int iIdTipoEstado)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.MotivoCambioEstadoWS + "listarMotivoCambioEstadoPorTipoEstado", new Dictionary<string, object>(){
                    {"iIdTipoEstado", iIdTipoEstado}
                });

                return deserializarPrueba<MotivoCambioEstado>(response);

            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
    }
}
