using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static List<IndicadorANS> ListarIndicadores(int iIdPeriodo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.IndicadorANSWS + "ListarIndicadores", new Dictionary<string, object>(){
                    {"iIdPeriodo", iIdPeriodo}
                });

                return deserializarPrueba<IndicadorANS>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<IndicadorANS> ListarGestionOportunaDetalle(int iIdPeriodo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.IndicadorANSWS + "ListarGestionOportunaDetalle", new Dictionary<string, object>(){
                    {"iIdPeriodo", iIdPeriodo}
                });

                return deserializarPrueba<IndicadorANS>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<IndicadorANS> ListarEfectividadEntregaDetalle(int iIdPeriodo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.IndicadorANSWS + "ListarEfectividadEntregaDetalle", new Dictionary<string, object>(){
                    {"iIdPeriodo", iIdPeriodo}
                });

                return deserializarPrueba<IndicadorANS>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<IndicadorANS> ListarProcesadosMesaPartesDetalle(int iIdPeriodo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.IndicadorANSWS + "ListarProcesadosMesaPartesDetalle", new Dictionary<string, object>(){
                    {"iIdPeriodo", iIdPeriodo}
                });

                return deserializarPrueba<IndicadorANS>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<IndicadorANS> ListarReportesDeServiciosDetalle(int iIdPeriodo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.IndicadorANSWS + "ListarReportesDeServiciosDetalle", new Dictionary<string, object>(){
                    {"iIdPeriodo", iIdPeriodo}
                });

                return deserializarPrueba<IndicadorANS>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


    }
}
