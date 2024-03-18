using Interna.Entity.PF;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static List<T> ListarEntidadPorPeriodo<T>(int iIdPeriodo, string entidad)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "ListarEntidadPorPeriodo", new Dictionary<string, object>(){
                {"iIdPeriodo",iIdPeriodo},
                {"entidad", entidad }
            });

                return deserializarPrueba<T>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static List<PF_Periodo> ListarPeriodos()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "ListarPeriodos", null);
                return deserializarPrueba<PF_Periodo>(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }

        public static List<PF_Periodo> ListarAnioPeriodos()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "ListarAnioPeriodos", null);
                return deserializarPrueba<PF_Periodo>(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }

        public static int actualizarAgentesBCP(int iIdPeriodo, int boletas, int facturas)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarAgentesBCP", new Dictionary<string, object>(){
                     {"iIdPeriodo",iIdPeriodo},
                {"boletas",boletas},
                {"facturas", facturas }
            });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }


        public static int actualizarBolsasNaranjas(int iIdPeriodo, int dentroProvincia, int fueraLima, int fueraProvincia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarBolsasNaranjas", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo},
                    {"dentroProvincia",dentroProvincia},
                    {"fueraLima", fueraLima },
                    {"fueraProvincia", fueraProvincia }
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }


        public static int actualizarCajasPorServicio(int iIdPeriodo, int limaOPRansa, int multibancaRansa, int multibancaEnotria, int cajasPorCoordinacion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarCajasPorServicio", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo},
                    {"limaOPRansa",limaOPRansa},
                    {"multibancaRansa", multibancaRansa },
                    { "multibancaEnotria", multibancaEnotria},
                    { "cajasPorCoordinacion", cajasPorCoordinacion}
                });
                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }



        }


        public static int actualizarCelulares(int iIdPeriodo, int celularesLimaColaborador, int celularesLimaBanco, int celularesProvinciaColaborador, int celularesProvinciaBanco)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarCelulares", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo},
                {"celularesLimaColaborador",celularesLimaColaborador},
                {"celularesLimaBanco", celularesLimaBanco },
                { "celularesProvinciaColaborador", celularesProvinciaColaborador},
                { "celularesProvinciaBanco", celularesProvinciaBanco}
            });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }


        public static int actualizarChequerasVerbales(int iIdPeriodo, int chequerasLima, int chequerasProvincia, int verbalesCreditoLima, int verbalesCreditoProvincia, int verbalesDebitoLima, int verbalesDebitoProvincia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarChequerasVerbales", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo},
                {"chequerasLima",chequerasLima},
                {"chequerasProvincia", chequerasProvincia },
                {"verbalesCreditoLima",verbalesCreditoLima},
                {"verbalesCreditoProvincia", verbalesCreditoProvincia },
                { "verbalesDebitoLima", verbalesDebitoLima},
                { "verbalesDebitoProvincia", verbalesDebitoProvincia}
            });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }


        public static int actualizarDocumentosProcesadosAgencias(int iIdPeriodo, int poderes, int amortizacionesAFP, int valeConsumo, int bolsasAutosellables, int solicitudesVisanet)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarDocumentosProcesadosAgencias", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo},
                {"poderes",poderes},
                {"amortizacionesAFP", amortizacionesAFP },
                {"valeConsumo",valeConsumo},
                {"bolsasAutosellables", bolsasAutosellables },
                {"solicitudesVisanet",solicitudesVisanet}
            });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }


        public static int actualizarDocumentosProcesadosUTD(int iIdPeriodo, int sunass, int tarjetasPresentacion, int periodicosEntregados, int campanasInternas)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarDocumentosProcesadosUTD", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo},
                {"sunass",sunass},
                {"tarjetasPresentacion", tarjetasPresentacion },
                { "periodicosEntregados",periodicosEntregados},
                {"campanasInternas", campanasInternas }
            });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }


        public static int actualizarDocumentosRecogidosSerpost(int iIdPeriodo, int recogidosLOP, int recodigosLMO)
        {
            try
            {

                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarDocumentosRecogidosSerpost", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo},
                {"recogidosLOP",recogidosLOP},
                {"recogidosLMO", recodigosLMO }
            });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        public static int actualizarMesaPartesLMO(int iIdPeriodo, int cartasCTS, int avisosNoPago, int sbs, int activosFijos, int facturasFisicas, int facturasElectronicas)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarMesaPartesLMO", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo},
                {"cartasCTS",cartasCTS},
                {"avisosNoPago", avisosNoPago },
                {"sbs",sbs},
                {"activosFijos", activosFijos },
                    { "facturasFisicas",facturasFisicas},
                {"facturasElectronicas", facturasElectronicas }
            });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }


        public static int actualizarMesaPartesLOP(int iIdPeriodo, int oficiosLegal, int sellosPersonalBanco, int aduanasVoucher)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarMesaPartesLOP", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo},
                {"oficiosLegal",oficiosLegal},
                {"sellosPersonalBanco", sellosPersonalBanco },
                {"aduanasVoucher", aduanasVoucher }
            });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }


        public static int actualizarMesaPartesSIS(int iIdPeriodo, int documentosExterior, int embargosCoactivos)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarMesaPartesSIS", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo},
                {"documentosExterior",documentosExterior},
                {"embargosCoactivos", embargosCoactivos }
            });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }


        public static int actualizarOtros(int iIdPeriodo, int segurosCodigoBarras, int segurosSinCodigoBarras, int solicitudesCreditoLima, int solicitudesCreditoProvincia, int tokenLima, int tokenProvincia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarOtros", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo},
                {"segurosCodigoBarras",segurosCodigoBarras},
                {"segurosSinCodigoBarras", segurosSinCodigoBarras },
                {"solicitudesCreditoLima",solicitudesCreditoLima},
                {"solicitudesCreditoProvincia", solicitudesCreditoProvincia },
                {"tokenLima",tokenLima},
                {"tokenProvincia", tokenProvincia }
            });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }


        public static int actualizarValijas(int iIdPeriodo, int enviadasLima, int enviadasProvincia, int incidenciasOperativa, int incidenciasComercial)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarValijas", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo},
                {"enviadasLima",enviadasLima},
                {"enviadasProvincia", enviadasProvincia },
                {"incidenciasOperativa",incidenciasOperativa},
                {"incidenciasComercial", incidenciasComercial }
            });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }

        public static List<PF_Autogenerado> ListarAutogeneradosSede(int iIdPeriodo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "ListarAutogeneradosSede", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo}
            });

                return deserializarPrueba<PF_Autogenerado>(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }

        public static List<PF_Autogenerado> ListarAutogeneradosEntregados(int iIdPeriodo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "ListarAutogeneradosEntregados", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo }
            });

                return deserializarPrueba<PF_Autogenerado>(response);
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }

        public static PF_Autogenerado ListarAutogeneradosMesaPartes(int iIdPeriodo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "ListarAutogeneradosMesaPartes", new Dictionary<string, object>(){
                    { "iIdPeriodo", iIdPeriodo }
            });

                return deserializarPrueba<PF_Autogenerado>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static PF_Valijas ListarValijasLimaPeriodo(DateTime dFechaPeriodo)
        {
            try
            {
                string response = Requester.SimpleTaskRVA(RutaWS.RegistroWS + "ListarValijasLimaPeriodo", new Dictionary<string, object>(){
                    { "dFechaPeriodo", dFechaPeriodo }
            });

                return deserializarPrueba<PF_Valijas>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static int ListarBolsasNaranjasPeriodo(DateTime dFechaPeriodo)
        {
            try
            {
                string response = Requester.SimpleTaskRVA(RutaWS.RegistroWS + "ListarBolsasNaranjasPeriodo", new Dictionary<string, object>(){
                    { "dFechaPeriodo", dFechaPeriodo }
            });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        #region PF_EXT

        public static int actualizarEecc(int iIdPeriodo, int lima, int provincia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarEecc", new Dictionary<string, object>(){
                    {"iIdPeriodo",iIdPeriodo},
                    {"lima", lima },
                    {"provincia", provincia }
                });
                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int actualizarGestionCampanas(int iIdPeriodo, int campanasGestionadas, int basesGestionadas, int registrosGestionados)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarGestionCampanas", new Dictionary<string, object>(){
                    {"iIdPeriodo",iIdPeriodo},
                    {"campanasGestionadas", campanasGestionadas },
                    {"basesGestionadas", basesGestionadas },
                    {"registrosGestionados", registrosGestionados }
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int actualizarProcesadosExpedicion(
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
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarProcesadosExpedicion", new Dictionary<string, object>(){
                    {"iIdPeriodo",iIdPeriodo},
                    {"documentosLima", documentosLima },
                    {"documentosProvincia", documentosProvincia },
                    {"documentosExterior", documentosExterior },
                    {"tokenExterior", tokenExterior },
                    {"notasAbono", notasAbono },
                    {"pagares", pagares },
                    {"documentosSerpost", documentosSerpost },
                    {"detracciones", detracciones },
                    {"retenciones", retenciones },
                    {"priorityPass", priorityPass },
                    {"auditoriasRealizadas", auditoriasRealizadas }
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int actualizarTarjetasExterior(int iIdPeriodo, int debito, int credito)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarTarjetasExterior", new Dictionary<string, object>(){
                    {"iIdPeriodo",iIdPeriodo},
                    {"debito", debito },
                    {"credito", credito }
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int actualizarTarjetasGremio(int iIdPeriodo, int lima, int provincia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "actualizarTarjetasGremio", new Dictionary<string, object>(){
                    {"iIdPeriodo",iIdPeriodo},
                    {"lima", lima },
                    {"provincia", provincia }
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }


        public static List<List<PF_ReporteFacturacion>> generarReporteFacturacion(PF_Periodo oPeriodo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "generarReporteFacturacion", new Dictionary<string, object>(){
                    {"IdPeriodo", oPeriodo.iId}
                });
                string s = response.Substring(1, response.Length - 2).Trim().Replace("\"[", "[").Replace("]\"", "]").Replace("\\", "");
                string[] ss = Regex.Split(s, "],");

                List<List<PF_ReporteFacturacion>> listaReporteFacturacion = new List<List<PF_ReporteFacturacion>>();

                string response2 = Requester.SimpleTaskRVA(RutaWS.ReporteRVAWS + "valijasRecibidasPorPeriodoLimaProvincia", new Dictionary<string, object>(){
                    { "Anio", oPeriodo.anioPeriodo}
                });

                List<PF_ReporteFacturacion> listaPF = new List<PF_ReporteFacturacion>();
                listaPF = deserializarPrueba<PF_ReporteFacturacion>(response2);


                for (int i = 0; i < ss.Length; i++)
                {
                    ss[i] = ss[i].Trim();
                    ss[i] += "]";
                    listaReporteFacturacion.Add(deserializarPrueba<PF_ReporteFacturacion>(ss[i].Trim()));
                }

                //Cantidad de valijas enviadas y recibidas por UTD Oficinas Lima
                listaReporteFacturacion[8][1].enero = listaPF[0].enero;
                listaReporteFacturacion[8][1].febrero = listaPF[0].febrero;
                listaReporteFacturacion[8][1].marzo = listaPF[0].marzo;
                listaReporteFacturacion[8][1].abril = listaPF[0].abril;
                listaReporteFacturacion[8][1].mayo = listaPF[0].mayo;
                listaReporteFacturacion[8][1].junio = listaPF[0].junio;
                listaReporteFacturacion[8][1].julio = listaPF[0].julio;
                listaReporteFacturacion[8][1].agosto = listaPF[0].agosto;
                listaReporteFacturacion[8][1].setiembre = listaPF[0].setiembre;
                listaReporteFacturacion[8][1].octubre = listaPF[0].octubre;
                listaReporteFacturacion[8][1].noviembre = listaPF[0].noviembre;
                listaReporteFacturacion[8][1].diciembre = listaPF[0].diciembre;

                //Cantidad de valijas enviadas y recibidas por UTD Oficinas Provincia
                listaReporteFacturacion[9][1].enero = listaPF[1].enero;
                listaReporteFacturacion[9][1].febrero = listaPF[1].febrero;
                listaReporteFacturacion[9][1].marzo = listaPF[1].marzo;
                listaReporteFacturacion[9][1].abril = listaPF[1].abril;
                listaReporteFacturacion[9][1].mayo = listaPF[1].mayo;
                listaReporteFacturacion[9][1].junio = listaPF[1].junio;
                listaReporteFacturacion[9][1].julio = listaPF[1].julio;
                listaReporteFacturacion[9][1].agosto = listaPF[1].agosto;
                listaReporteFacturacion[9][1].setiembre = listaPF[1].setiembre;
                listaReporteFacturacion[9][1].octubre = listaPF[1].octubre;
                listaReporteFacturacion[9][1].noviembre = listaPF[1].noviembre;
                listaReporteFacturacion[9][1].diciembre = listaPF[1].diciembre;

                //Bolsas Naranjas
                listaReporteFacturacion[14][0].enero = listaPF[2].enero;
                listaReporteFacturacion[14][0].febrero = listaPF[2].febrero;
                listaReporteFacturacion[14][0].marzo = listaPF[2].marzo;
                listaReporteFacturacion[14][0].abril = listaPF[2].abril;
                listaReporteFacturacion[14][0].mayo = listaPF[2].mayo;
                listaReporteFacturacion[14][0].junio = listaPF[2].junio;
                listaReporteFacturacion[14][0].julio = listaPF[2].julio;
                listaReporteFacturacion[14][0].agosto = listaPF[2].agosto;
                listaReporteFacturacion[14][0].setiembre = listaPF[2].setiembre;
                listaReporteFacturacion[14][0].octubre = listaPF[2].octubre;
                listaReporteFacturacion[14][0].noviembre = listaPF[2].noviembre;
                listaReporteFacturacion[14][0].diciembre = listaPF[2].diciembre;

                return listaReporteFacturacion;
            }
            catch (InvalidTokenException)
            {
                throw;
            }
            catch (AggregateException e)
            {
                throw e.InnerException;
            }

        }

        public static List<PF_ReporteFacturacion> generarReporteMonitor(int IdPeriodo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "generarReporteMonitor", new Dictionary<string, object>(){
                    {"IdPeriodo",IdPeriodo}
                });
                return deserializarPrueba<PF_ReporteFacturacion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
            catch (Exception ae)
            {
                throw ae;
            }
        }

        //public static PF_Valijas ListarValijasLimaPeriodo(DateTime dFechaPeriodo)
        //{
        //    try
        //    {
        //        string response = Requester.SimpleTaskRVA(RutaWS.RegistroWS + "ListarValijasLimaPeriodo", new Dictionary<string, object>(){
        //            { "dFechaPeriodo", dFechaPeriodo }
        //    });

        //        return deserializarPrueba<PF_Valijas>(response)[0];
        //    }
        //    catch (InvalidTokenException)
        //    {
        //        throw;
        //    }
        //}


        public static List<List<PF_ReporteFacturacion>> generarReporteResumenReclamo(int IdPeriodo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PF_TodoWS + "generarReporteResumenReclamo", new Dictionary<string, object>(){
                    {"IdPeriodo", IdPeriodo}
                });
                string s = response.Substring(1, response.Length - 2).Trim().Replace("\"[", "[").Replace("]\"", "]").Replace("\\", "");
                string[] ss = Regex.Split(s, "],");

                List<List<PF_ReporteFacturacion>> listaReporteResumenReclamo = new List<List<PF_ReporteFacturacion>>();



                for (int i = 0; i < ss.Length; i++)
                {
                    ss[i] = ss[i].Trim();
                    ss[i] += "]";
                    listaReporteResumenReclamo.Add(deserializarPrueba<PF_ReporteFacturacion>(ss[i].Trim()));
                }

                return listaReporteResumenReclamo;
            }
            catch (InvalidTokenException)
            {
                throw;
            }
            catch (AggregateException e)
            {
                throw e.InnerException;
            }

        }

        #endregion



    }
}
