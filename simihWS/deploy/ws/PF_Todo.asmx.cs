using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Interna.Entity.PF;

namespace simihWS.ws
{
    /// <summary>
    /// Descripción breve de PF_Todo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class PF_Todo : System.Web.Services.WebService
    {
        [WebMethod]
        public string ListarPeriodos()
        {
            PF_Periodo pF_Entity = new PF_Periodo();

            return pF_Entity.ListarPeriodos();
        }


        [WebMethod]
        public string ListarEntidadPorPeriodo(int iIdPeriodo, string entidad)
        {
            PF_Entity pF_Entity = new PF_Entity();

            return pF_Entity.ListarEntidadPorPeriodo(iIdPeriodo, entidad);
        }

        [WebMethod]
        public int actualizarAgentesBCP(int iIdPeriodo, int boletas, int facturas)
        {
            PF_AgentesBCP pF_Entity = new PF_AgentesBCP(iIdPeriodo, boletas, facturas);

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarBolsasNaranjas(int iIdPeriodo, int dentroProvincia, int fueraLima, int fueraProvincia)
        {
            PF_BolsasNaranjas pF_Entity = new PF_BolsasNaranjas(iIdPeriodo, dentroProvincia, fueraLima, fueraProvincia);

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarCajasPorServicio(int iIdPeriodo, int limaOPRansa, int multibancaRansa, int multibancaEnotria, int cajasPorCoordinacion)
        {
            PF_CajasPorServicio pF_Entity = new PF_CajasPorServicio(iIdPeriodo, limaOPRansa, multibancaRansa, multibancaEnotria, cajasPorCoordinacion);

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarCelulares(int iIdPeriodo, int celularesLimaColaborador, int celularesLimaBanco, int celularesProvinciaColaborador, int celularesProvinciaBanco)
        {
            PF_Celulares pF_Entity = new PF_Celulares(iIdPeriodo, celularesLimaColaborador,  celularesLimaBanco,  celularesProvinciaColaborador,  celularesProvinciaBanco);

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarChequerasVerbales(int iIdPeriodo, int chequerasLima, int chequerasProvincia, int verbalesCreditoLima, int verbalesCreditoProvincia, int verbalesDebitoLima, int verbalesDebitoProvincia)
        {
            PF_ChequerasVerbales pF_Entity = new PF_ChequerasVerbales(iIdPeriodo, chequerasLima,  chequerasProvincia,  verbalesCreditoLima,  verbalesCreditoProvincia,  verbalesDebitoLima,  verbalesDebitoProvincia);

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarDocumentosProcesadosAgencias(int iIdPeriodo, int poderes, int amortizacionesAFP, int valeConsumo, int bolsasAutosellables, int solicitudesVisanet)
        {
            PF_DocumentosProcesadosAgencias pF_Entity = new PF_DocumentosProcesadosAgencias(iIdPeriodo, poderes,  amortizacionesAFP,  valeConsumo,  bolsasAutosellables,  solicitudesVisanet);

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarDocumentosProcesadosUTD(int iIdPeriodo, int sunass, int tarjetasPresentacion, int periodicosEntregados, int campanasInternas)
        {
            PF_DocumentosProcesadosUTD pF_Entity = new PF_DocumentosProcesadosUTD(iIdPeriodo, sunass,  tarjetasPresentacion,  periodicosEntregados,  campanasInternas);

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarDocumentosRecogidosSerpost(int iIdPeriodo, int recogidosLOP, int recogidosLMO)
        {
            PF_DocumentosRecogidosSerpost pF_Entity = new PF_DocumentosRecogidosSerpost(iIdPeriodo, recogidosLOP,  recogidosLMO);

            return pF_Entity.actualizar();

        }

        [WebMethod]
        public int actualizarMesaPartesLMO(int iIdPeriodo, int cartasCTS, int avisosNoPago, int sbs, int activosFijos, int facturasFisicas, int facturasElectronicas)
        {
            PF_MesaPartesLMO pF_Entity = new PF_MesaPartesLMO(iIdPeriodo, cartasCTS, avisosNoPago,  sbs,  activosFijos,  facturasFisicas,  facturasElectronicas);

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarMesaPartesLOP(int iIdPeriodo, int oficiosLegal, int sellosPersonalBanco, int aduanasVoucher)
        {
            PF_MesaPartesLOP pF_Entity = new PF_MesaPartesLOP(iIdPeriodo, oficiosLegal,  sellosPersonalBanco,  aduanasVoucher);

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarMesaPartesSIS(int iIdPeriodo, int documentosExterior, int embargosCoactivos)
        {
            PF_MesaPartesSIS pF_Entity = new PF_MesaPartesSIS(iIdPeriodo, documentosExterior,  embargosCoactivos);

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarOtros(int iIdPeriodo, int segurosCodigoBarras, int segurosSinCodigoBarras, int solicitudesCreditoLima, int solicitudesCreditoProvincia, int tokenLima, int tokenProvincia)
        {
            PF_Otros pF_Entity = new PF_Otros(iIdPeriodo, segurosCodigoBarras,  segurosSinCodigoBarras,  solicitudesCreditoLima,  solicitudesCreditoProvincia,  tokenLima,  tokenProvincia);

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarValijas(int iIdPeriodo, int enviadasLima, int enviadasProvincia, int incidenciasOperativa, int incidenciasComercial)
        {
            PF_Valijas pF_Entity = new PF_Valijas(iIdPeriodo, enviadasLima,  enviadasProvincia,  incidenciasOperativa,  incidenciasComercial);

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public string ListarAutogeneradosSede(int iIdPeriodo)
        {
            PF_Autogenerado pF_Autogenerado = new PF_Autogenerado(iIdPeriodo);
            return pF_Autogenerado.ListarAutogeneradosSede();

        }

        [WebMethod]
        public string ListarAutogeneradosEntregados(int iIdPeriodo)
        {

            PF_Autogenerado pF_Autogenerado = new PF_Autogenerado(iIdPeriodo);
            return pF_Autogenerado.ListarAutogeneradosEntregados();
        }

        [WebMethod]
        public string ListarAutogeneradosMesaPartes(int iIdPeriodo)
        {

            PF_Autogenerado pF_Autogenerado = new PF_Autogenerado(iIdPeriodo);
            return pF_Autogenerado.ListarAutogeneradosMesaPartes();
        }

        [WebMethod]
        public string ListarAnioPeriodos()
        {
            PF_Periodo pF_Entity = new PF_Periodo();

            return pF_Entity.ListarAnioPeriodos();
        }

        #region PF_EXT


        [WebMethod]
        public int actualizarEecc(int iIdPeriodo, int lima, int provincia)
        {
            PF_EXT_Eecc pF_Entity = new PF_EXT_Eecc();
            pF_Entity.iIdPeriodo = iIdPeriodo;
            pF_Entity.lima = lima;
            pF_Entity.provincia = provincia;

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarGestionCampanas(int iIdPeriodo, int campanasGestionadas, int basesGestionadas,int registrosGestionados)
        {
            PF_EXT_GestionCampanas pF_Entity = new PF_EXT_GestionCampanas();
            pF_Entity.iIdPeriodo = iIdPeriodo;
            pF_Entity.campanasGestionadas = campanasGestionadas;
            pF_Entity.basesGestionadas = basesGestionadas;
            pF_Entity.registrosGestionados = registrosGestionados;

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarProcesadosExpedicion(
            int iIdPeriodo, 
            int documentosLima,
            int documentosProvincia,
            int documentosExterior,
            int tokenExterior,
            int notasAbono,
            int pagares,
            int documentosSerpost,
            int detracciones,
            int retenciones,
            int priorityPass,
            int auditoriasRealizadas
            )
        {
            PF_EXT_ProcesadosExpedicion pF_Entity = new PF_EXT_ProcesadosExpedicion();
            pF_Entity.iIdPeriodo = iIdPeriodo;
            pF_Entity.documentosLima = documentosLima;
            pF_Entity.documentosProvincia = documentosProvincia;
            pF_Entity.documentosExterior = documentosExterior;
            pF_Entity.tokenExterior = tokenExterior;
            pF_Entity.notasAbono = notasAbono;
            pF_Entity.pagares = pagares;
            pF_Entity.documentosSerpost = documentosSerpost;
            pF_Entity.detracciones = detracciones;
            pF_Entity.retenciones = retenciones;
            pF_Entity.priorityPass = priorityPass;
            pF_Entity.auditoriasRealizadas = auditoriasRealizadas;

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarTarjetasExterior(int iIdPeriodo,int debito, int credito)
        {
            PF_EXT_TarjetasExterior pF_Entity = new PF_EXT_TarjetasExterior();
            pF_Entity.iIdPeriodo = iIdPeriodo;
            pF_Entity.debito = debito;
            pF_Entity.credito = credito;

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public int actualizarTarjetasGremio(int iIdPeriodo, int lima, int provincia)
        {
            PF_EXT_TarjetasGremio pF_Entity = new PF_EXT_TarjetasGremio();
            pF_Entity.iIdPeriodo = iIdPeriodo;
            pF_Entity.lima = lima;
            pF_Entity.provincia = provincia;

            return pF_Entity.actualizar();
        }

        [WebMethod]
        public List<string> generarReporteFacturacion(int IdPeriodo)
        {
            PF_ReporteFacturacion oReporteFacturacion = new PF_ReporteFacturacion();
            return oReporteFacturacion.generarReporteFacturacion(IdPeriodo);
        }

        [WebMethod]
        public string generarReporteMonitor(int IdPeriodo)
        {
            PF_ReporteFacturacion oReporteFacturacion = new PF_ReporteFacturacion();
            return oReporteFacturacion.generarReporteMonitor(IdPeriodo);
        }

        [WebMethod]
        public List<string> generarReporteResumenReclamo(int IdPeriodo)
        {
            PF_ReporteFacturacion oReporteFacturacion = new PF_ReporteFacturacion();
            return oReporteFacturacion.generarReporteResumenReclamo(IdPeriodo);
        }

        #endregion









    }
}
