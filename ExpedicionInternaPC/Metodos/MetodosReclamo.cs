using Interna.Entity;
using Interna.Entity.Estructuras;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static List<ListaReclamoView> ListarReclamoPorExpedicion(int iIdExpedicion)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ReclamoWS + "ListarReclamoPorExpedicion", new Dictionary<string, object>(){
                    {"iIdExpedicion", iIdExpedicion}
                });

                return deserializarPrueba<ListaReclamoView>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static ListaReclamoView ListarDetalleReclamo(int iIdReclamo)
        {


            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ReclamoWS + "ListarDetalleReclamo", new Dictionary<string, object>(){
                    {"iIdReclamo", iIdReclamo}
                });

                return deserializarPrueba<ListaReclamoView>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static int RegistrarPrimeraRespuesta(int iIdReclamo, int iIdUsuario)
        {
            //ServiceReclamoWS.ReclamoWS reclamoWS = new ServiceReclamoWS.ReclamoWS();
            //return reclamoWS.RegistrarPrimeraRespuesta(iIdReclamo, iIdUsuario);

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ReclamoWS + "RegistrarPrimeraRespuesta", new Dictionary<string, object>(){
                    {"iIdReclamo", iIdReclamo},
                    {"iIdUsuario", iIdUsuario}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int RegistrarReclamoDesdeUTD(int iIdUsuario, int iIdUsuarioAtencion, byte iIdTipoReclamoUsuario, string sDocReferencia, string sDetalle, DateTime dFechaAtencion, DateTime dFechaRegistro)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ReclamoWS + "RegistrarReclamoDesdeUTD", new Dictionary<string, object>(){
                    {"iIdUsuario", iIdUsuario},
                    {"iIdUsuarioAtencion", iIdUsuarioAtencion},
                    {"iIdTipoReclamoUsuario", iIdTipoReclamoUsuario},
                    {"sDocReferencia", sDocReferencia},
                    {"sDetalle", sDetalle},
                    {"dFechaAtencion", dFechaAtencion},
                    {"dFechaRegistro", dFechaRegistro}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int RegistrarSolucion(Reclamo oReclamo)
        {
            //ServiceReclamoWS.ReclamoWS reclamoWS = new ServiceReclamoWS.ReclamoWS();
            //ServiceReclamoWS.Reclamo oReclamoWS = new ServiceReclamoWS.Reclamo();
            //oReclamo.CopyToObject(oReclamoWS);
            //return reclamoWS.RegistrarSolucion(oReclamoWS);
            //(int IdReclamo, int iFundado, int IdTipoReclamoUTD, string AccionInmediata, string Causa, 
            //int IdTipoResponsable, string PersonaResponsable, string Solucion)
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ReclamoWS + "RegistrarSolucion", new Dictionary<string, object>(){
                    {"IdReclamo", oReclamo.iIdReclamo},
                    {"iFundado", oReclamo.iFundado},
                    {"IdTipoReclamoUTD", oReclamo.iIdTipoReclamoUTD },
                    {"AccionInmediata", oReclamo.sAccionInmediata },
                    {"Causa", oReclamo.sCausa },
                    {"IdTipoResponsable", oReclamo.iIdTipoResponsable },
                    {"PersonaResponsable", oReclamo.sPersonaResponsable },
                    {"Solucion", oReclamo.sSolucion }
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<ListaReclamoView> ListarReclamosSolucionadosPorTipoReclamoUTDYExpedicion(Reclamo oReclamo, int iIdExpedicion)
        {
            //ServiceReclamoWS.ReclamoWS reclamoWS = new ServiceReclamoWS.ReclamoWS();
            //ServiceReclamoWS.Reclamo oReclamoWS = new ServiceReclamoWS.Reclamo();
            //oReclamo.CopyToObject(oReclamoWS);
            //return deserializarPrueba<ListaReclamoView>(reclamoWS.ListarReclamosSolucionadosPorTipoReclamoUTDYExpedicion(oReclamoWS, iIdExpedicion));
            ////(byte IdTipoReclamoUTD, int IdExpedicion, DateTime FechaRegistro, int iIdExpedicion)
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ReclamoWS + "ListarReclamosSolucionadosPorTipoReclamoUTDYExpedicion", new Dictionary<string, object>(){
                    {"IdTipoReclamoUTD", oReclamo.iIdTipoReclamoUTD},
                    {"iIdExpedicion", iIdExpedicion},
                    {"FechaRegistro", oReclamo.dFechaRegistro }
                });

                return deserializarPrueba<ListaReclamoView>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }



        }

        public static int RegistrarVerificacion(Reclamo oReclamo)
        {
            //ServiceReclamoWS.ReclamoWS reclamoWS = new ServiceReclamoWS.ReclamoWS();
            //ServiceReclamoWS.Reclamo oReclamoWS = new ServiceReclamoWS.Reclamo();
            //oReclamo.CopyToObject(oReclamoWS);
            //return reclamoWS.RegistrarVerificacion(oReclamoWS);

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ReclamoWS + "RegistrarVerificacion", new Dictionary<string, object>(){
                    {"IdReclamo", oReclamo.iIdReclamo},
                    {"IdEstadoVerificacion", oReclamo.iIdEstadoVerificacion},
                    {"iCalificacion", oReclamo.iCalificacion},
                    {"iObservado", oReclamo.iObservado},
                    {"Observacion", oReclamo.sObservacion},
                    { "iIdTipoReclamoJefe", oReclamo.iIdTipoReclamoJefe}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<ListaReclamoView> GenerarReportePorPeriodo(Reclamo oReclamo)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ReclamoWS + "GenerarReportePorPeriodo", new Dictionary<string, object>(){
                    {"dFechaRegistro", oReclamo.dFechaRegistro}
                });

                return deserializarPrueba<ListaReclamoView>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int MarcarReclamoPorCorregir(Reclamo oReclamo)
        {
            //ServiceReclamoWS.ReclamoWS reclamoWS = new ServiceReclamoWS.ReclamoWS();
            //ServiceReclamoWS.Reclamo oReclamoWS = new ServiceReclamoWS.Reclamo();
            //oReclamo.CopyToObject(oReclamoWS);
            //return reclamoWS.MarcarReclamoPorCorregir(oReclamoWS);

            //

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ReclamoWS + "MarcarReclamoPorCorregir", new Dictionary<string, object>(){
                    {"IdReclamo", oReclamo.iIdReclamo}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static int GuardarCorreccion(Reclamo oReclamo)
        {
            //ServiceReclamoWS.ReclamoWS reclamoWS = new ServiceReclamoWS.ReclamoWS();
            //ServiceReclamoWS.Reclamo oReclamoWS = new ServiceReclamoWS.Reclamo();
            //oReclamo.CopyToObject(oReclamoWS);
            //return reclamoWS.GuardarCorreccion(oReclamoWS);
            ////int IdReclamo, string Correccion)

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ReclamoWS + "GuardarCorreccion", new Dictionary<string, object>(){
                    {"IdReclamo", oReclamo.iIdReclamo},
                    {"Correccion", oReclamo.sCorreccion}
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
