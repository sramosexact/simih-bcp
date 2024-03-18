using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {

        public static List<EstadoVerificacion> ListarEstadoVerificacion()
        {
            //ServiceEstadoVerificacionWS.EstadoVerificacionWS estadoVerificacionWS = new ServiceEstadoVerificacionWS.EstadoVerificacionWS();
            //return deserializarPrueba<EstadoVerificacion>(estadoVerificacionWS.ListarEstadoVerificacion());

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EstadoVerificacionWS + "ListarEstadoVerificacion", null);

                return deserializarPrueba<EstadoVerificacion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


    }
}
