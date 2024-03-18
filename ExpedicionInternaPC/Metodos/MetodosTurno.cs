using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static List<Turno> ListarTurnos()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TurnoWS + "ListarTurno", null);

                return deserializarPrueba<Turno>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static Turno CrearTurno(Turno turn)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TurnoWS + "CrearTurno", new Dictionary<string, object>() {
                    { "sDescripcionTurno", turn.sDescripcionTurno},
                    { "listaAgencias", turn.listaAgencias}

                });
                return deserializarPrueba<Turno>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
