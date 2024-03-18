using Interna.Entity;
using System;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Summary description for ReclamoWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ReclamoWS : System.Web.Services.WebService
    {
        [WebMethod]
        public string ListarReclamoPorExpedicion(int iIdExpedicion)
        {
            Reclamo reclamo = new Reclamo();
            return reclamo.ListarReclamoPorExpedicion(iIdExpedicion);
        }

        [WebMethod]
        public string ListarDetalleReclamo(int iIdReclamo)
        {
            Reclamo reclamo = new Reclamo(iIdReclamo);
            return reclamo.ListarDetalleReclamo();
        }

        [WebMethod]
        public int RegistrarPrimeraRespuesta(int iIdReclamo, int iIdUsuario)
        {
            Reclamo reclamo = new Reclamo(iIdReclamo, iIdUsuario);
            return reclamo.RegistrarPrimeraRespuesta();
        }

        [WebMethod]
        public int RegistrarSolucion(int IdReclamo, int iFundado, int IdTipoReclamoUTD, string AccionInmediata, string Causa,
            int IdTipoResponsable, string PersonaResponsable, string Solucion)
        {
            Reclamo reclamo = new Reclamo();
            reclamo.iIdReclamo = IdReclamo;
            reclamo.iFundado = Convert.ToByte(iFundado);
            reclamo.iIdTipoReclamoUTD = Convert.ToByte(IdTipoReclamoUTD);
            reclamo.sAccionInmediata = AccionInmediata;
            reclamo.sCausa = Causa;
            reclamo.iIdTipoResponsable = Convert.ToByte(IdTipoResponsable);
            reclamo.sPersonaResponsable = PersonaResponsable;
            reclamo.sSolucion = Solucion;
            return reclamo.RegistrarSolucion();
        }

        [WebMethod]
        public string ListarReclamosSolucionadosPorTipoReclamoUTDYExpedicion(byte IdTipoReclamoUTD, DateTime FechaRegistro, int iIdExpedicion)
        {
            Reclamo reclamo = new Reclamo();
            reclamo.iIdTipoReclamoUTD = IdTipoReclamoUTD;
            reclamo.dFechaRegistro = FechaRegistro;
            return reclamo.ListarReclamosSolucionadosPorTipoReclamoUTDYExpedicion(iIdExpedicion);
        }

        [WebMethod]
        public int RegistrarVerificacion(int IdReclamo, byte IdEstadoVerificacion, byte iCalificacion, byte iObservado, string Observacion, byte iIdTipoReclamoJefe)
        {
            Reclamo reclamo = new Reclamo
            {
                iIdReclamo = IdReclamo,
                iIdEstadoVerificacion = IdEstadoVerificacion,
                iCalificacion = iCalificacion,
                iObservado = iObservado,
                sObservacion = Observacion,
                iIdTipoReclamoJefe = iIdTipoReclamoJefe
            };
            return reclamo.RegistrarVerificacion();
        }
        // Funcional - frmReporteReclamosAnalista
        [WebMethod]
        public string GenerarReportePorPeriodo(DateTime dFechaRegistro)
        {
            Reclamo oReclamo = new Reclamo();
            oReclamo.dFechaRegistro = dFechaRegistro;
            return oReclamo.GenerarReportePorPeriodo();
        }

        [WebMethod]
        public int MarcarReclamoPorCorregir(int IdReclamo)
        {
            Reclamo oReclamo = new Reclamo();
            oReclamo.iIdReclamo = IdReclamo;
            return oReclamo.MarcarReclamoPorCorregir();
        }

        [WebMethod]
        public int GuardarCorreccion(int IdReclamo, string Correccion)
        {
            Reclamo oReclamo = new Reclamo();
            oReclamo.iIdReclamo = IdReclamo;
            oReclamo.sCorreccion = Correccion;
            return oReclamo.GuardarCorreccion();
        }

        [WebMethod]
        public string ListarReclamosPorRangoDeFecha(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return new Reclamo().ListarReclamosPorRangoDeFecha(dFechaInicial, dFechaFinal);
        }

        [WebMethod]
        public int RegistrarReclamoDesdeUTD(int iIdUsuario, int iIdUsuarioAtencion, byte iIdTipoReclamoUsuario, string sDocReferencia, string sDetalle, DateTime dFechaAtencion, DateTime dFechaRegistro)
        {
            Reclamo reclamo = new Reclamo
            {
                iIdUsuario = iIdUsuario,
                iIdUsuarioAtencion = iIdUsuarioAtencion,
                iIdTipoReclamoUsuario = iIdTipoReclamoUsuario,
                sDocReferencia = sDocReferencia,
                sDetalle = sDetalle,
                dFechaAtencion = dFechaAtencion,
                dFechaRegistro = dFechaRegistro
            };

            return reclamo.RegistrarReclamoDesdeUTD();
        }

    }
}
