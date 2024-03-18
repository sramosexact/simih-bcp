using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static List<Feriado> ListarFeriados()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.FeriadoWS + "ListarFeriados", new Dictionary<string, object>() {
                    { "iIdTipoUsuario", Program.oUsuario.IdTipoAcceso},
                    { "iIdTipoExpedicion",Program.oUsuario.IdTipoExpedicion}
                });

                return deserializarPrueba<Feriado>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int IngresarFeriado(Feriado feriado)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.FeriadoWS + "IngresarFeriado", new Dictionary<string, object>() {
                    { "iIdUsuario", feriado.iIdUsuario},
                    { "dFechaFeriado", feriado.dFechaFeriado},
                    { "iIdTipoFeriado", feriado.iIdTipoFeriado},
                    { "sDescripcionFeriado", feriado.sDescripcionFeriado}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int EliminarFeriado(Feriado feriado)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.FeriadoWS + "EliminarFeriado", new Dictionary<string, object>() {
                    { "iIdFeriado", feriado.iIdFeriado}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
