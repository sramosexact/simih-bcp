using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static List<ReportePeriodo> ListarReportesPeriodo(int iIdPeriodo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ReportePeriodoWS + "ListarReportesPeriodo", new Dictionary<string, object>(){
                    {"iIdPeriodo", iIdPeriodo}
                });

                return deserializarPrueba<ReportePeriodo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static int ActualizarReportesPeriodo(string sListaEstadosReporte)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ReportePeriodoWS + "ActualizarReportesPeriodo", new Dictionary<string, object>(){
                    {"sListaEstadosReporte", sListaEstadosReporte}
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
