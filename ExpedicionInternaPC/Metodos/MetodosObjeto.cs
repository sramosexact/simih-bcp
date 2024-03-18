using Interna.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static Objeto RegistrarCorrespondenciaMesaDePartes(Objeto O)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "RegistrarCorrespondenciaMesaDePartes", new Dictionary<string, object>(){
                    {"IdTipoDocumento", O.IdTipoDocumento},
                    { "IdCasillaDe", O.IdCasillaDe},
                    { "IdCasillaPara", O.IdCasillaPara},
                    { "Asunto", O.Asunto},
                    { "Mensaje", O.Mensaje},
                    //{ "IdUsuario", O.IdUsuario},
                    { "ListaXML", O.ListaXML}
                });

                int ID = Convert.ToInt32(response);

                if (ID > 0)
                {
                    string response2 = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ObtenerCabecera", new Dictionary<string, object>(){
                        {"IdObjeto", ID}
                    });

                    return deserializarPrueba<Objeto>(response2)[0];
                }
                return null;
            }
            catch (InvalidTokenException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }


        }



        //2022
        public static List<Objeto> rConsultaElementosReporteGeneralDetalle(
            int idEstado,
            int idTipoEntrega,
            int idExpedicionOrigen,
            int idExpedicionDestino,
            int FechaDe,
            DateTime desde,
            DateTime hasta)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "rConsultaElementosReporteGeneralDetalle", new Dictionary<string, object>(){
                    {"idEstado", idEstado},
                    { "idTipoEntrega", idTipoEntrega},
                    { "idExpedicionOrigen", idExpedicionOrigen},
                    { "idExpedicionDestino", idExpedicionDestino},
                    { "FechaDe", FechaDe},
                    { "desde", desde},
                    { "hasta", hasta}
                });
                return JsonConvert.DeserializeObject<List<Objeto>>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                //return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }



        //2022
        public static List<Objeto> rObjetoExpedicion_Custodiados1(DateTime fechaDesde, DateTime fechaHasta, int Num)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "GetObjetoExpedicion_prueba1", new Dictionary<string, object>(){
                    {"idExpedicionCustodia", Program.oUsuario.IdExpedicion},
                    { "fechaHasta", fechaHasta},
                    { "fechaDesde", fechaDesde},
                    { "num", Num}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }


        //2022
        public static Objeto uObjetoImpresoXML1(String ListaXml)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "SetObjetoImpresoXML1", new Dictionary<string, object>(){
                    { "listaXML", ListaXml},
                    { "idExpedicion", Program.oUsuario.IdExpedicion},
                    { "idUsuario", Program.oUsuario.ID},
                    { "idGeoCasilla", Program.oUsuario.idGeoCasilla},
                    { "idCasilla", Program.oUsuario.idCasilla}
                });

                return deserializarPrueba<Objeto>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static void VerTracking(Objeto objO)
        {
            if (objO != null)
            {
                frmTracking oT = new frmTracking(objO.ID);
                oT.oObjeto = objO;
                oT.Show(Program.oMain);
            }
        }


        //Listado de Tipo de Lotes
        public static List<Tipo> TipoLotes()
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "GetTipoLote", null);

                return deserializarPrueba<Tipo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }



        //Listado de Motivo de Carga
        public static List<Tipo> MotivoCarga(int IdTipo)
        {


            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "GetMotivoCarga2", new Dictionary<string, object>(){
                    {"Tipo", IdTipo}
                });

                return deserializarPrueba<Tipo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        public static List<Tipo> listarTipoEqCoordinador(int indice)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "GetEquipoCoordinador", new Dictionary<string, object>(){
                    { "indice", indice}
                });

                return deserializarPrueba<Tipo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }




        public static List<Objeto> listarEstadoCargaArchivo()
        {


            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "getEstadoCargaArchivo", null);

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }



        //24/06/15
        public static List<Objeto> rObtenerCreados(string bandejaRemitente, string bandejaDestinatario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "R_OBTENERCREADO", new Dictionary<string, object>(){
                    { "bandejaRemitente", bandejaRemitente},
                    { "bandejaDestinatario", bandejaDestinatario},
                    { "idExpedicion", Program.oUsuario.IdExpedicion}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }


        public static List<Objeto> convertObjetos(DataTable data)
        {
            List<Objeto> lista = new List<Objeto>();
            foreach (DataRow r in data.Rows)
            {
                Objeto o = new Objeto();
                o.ConvertDataRowForObjeto(r);
                lista.Add(o);
            }
            return lista;
        }
        //2022
        public static List<Objeto> CorrespondenciaPorCustodiarJSON3(int IdExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "CorrespondenciaPorCustodiarJSON3", new Dictionary<string, object>(){
                    {"IdExpedicion", IdExpedicion}
                });
                List<Objeto> lo = deserializarPrueba<Objeto>(response);
                return lo;
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        public static List<T> deserializarPrueba<T>(string sJson)
        {
            try
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<T>));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(sJson));
                List<T> data = (List<T>)js.ReadObject(ms);
                ms.Close();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //2022
        public static List<String> VerTrackingAutogeneradoDesktop(int ID)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "SeguimientoAutogeneradoDesktop", new Dictionary<string, object>(){
                    {"ID", ID}
                });

                String[] ls = deserializarPrueba<string>(response).ToArray();

                List<string> listaJson = new List<string>();
                if (ls.Count() > 0)
                {
                    foreach (String l in ls)
                    {
                        listaJson.Add(l);
                    }
                }

                return listaJson;
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        /*CESAR BALTAZAR 31/08/2015*/
        public static Boolean serializarJson<T>(StreamWriter sw, List<T> lO)
        {
            try
            {
                MemoryStream stream1 = new MemoryStream();
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<T>));
                js.WriteObject(stream1, lO);
                stream1.Position = 0;
                StreamReader sr = new StreamReader(stream1);
                sw.Write(sr.ReadToEnd());
                sw.Close();
                return true;
            }
            catch
            {
                sw.Close();
                return false;
            }
        }

        //2022
        public static List<Objeto> rOneObjetoCustodia(string autogenerado, string destinatario, string remitente, string fechaDesde, string fechaHasta)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "rOneObjetoCustodia", new Dictionary<string, object>(){
                    { "Autogenerado", autogenerado},
                    { "idExpedicion", Program.oUsuario.IdExpedicion},
                    { "remitente", remitente},
                    { "destinatario", destinatario},
                    { "fechaDesde",  fechaDesde},
                    { "fechaHasta", fechaHasta}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }


        }

        public static StreamReader serializarJson<T>(List<T> lO)
        {
            StreamReader sr = null;
            try
            {
                MemoryStream stream1 = new MemoryStream();
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<T>));
                js.WriteObject(stream1, lO);
                stream1.Position = 0;
                sr = new StreamReader(stream1);
                return sr;
            }
            catch
            {
                sr.Close();
                return null;
            }
        }
        //2022
        public static List<Objeto> ValidarEstadoObjeto(string Autogenerado)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ValidarEstadoObjeto", new Dictionary<string, object>(){
                    { "Autogenerado", Autogenerado}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static List<Objeto> ObjetoOtraSucursal(string sAutogenerado, string sRemitente, string sDestinatario, int iExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "rObjetoOtraSucursal", new Dictionary<string, object>(){
                    { "sAutogenerado", sAutogenerado},
                    { "sRemitente", sRemitente},
                    { "sDestinatario", sDestinatario},
                    { "iExpedicion", iExpedicion}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int uCustodiaAutogeneradoOtraSucursal(int iAutogenerado)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "uCustodiaAutogeneradoOtraSucursal", new Dictionary<string, object>(){
                    { "iAutogenerado", iAutogenerado},
                    { "iUsuario", Program.oUsuario.ID},
                    { "iExpedicion", Program.oUsuario.IdExpedicion},
                    { "iCasilla", Program.oUsuario.idCasilla},
                    { "iGeoCasilla", Program.oUsuario.idGeoCasilla},
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static int uRegularizarObjeto(Objeto obj, int idUsuario, int idBandeja, int idExpedicion, int idGeo)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "uRegularizarObjeto", new Dictionary<string, object>(){
                    { "IdObjeto", obj.ID},
                    { "idUsuario", idUsuario},
                    { "idBandeja", idBandeja},
                    { "idExpedicion", idExpedicion},
                    { "idGeo", idGeo}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Objeto> rObtenerSobrantes(string sAutogenerado)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "rObtenerSobrantes", new Dictionary<string, object>(){
                    { "autogenerado", sAutogenerado},
                    { "idexpedicion", Program.oUsuario.IdExpedicion}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static int uRegularizarObjetoSobrante(Objeto obj)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "uRegularizarObjetoSobrante", new Dictionary<string, object>(){
                    {"IdObjeto", obj.ID},
                    { "idExpedicion", Program.oUsuario.IdExpedicion},
                    {"idUsuario", Program.oUsuario.ID},
                    {"idGeo", Program.oUsuario.idGeo},
                    {"idCasilla", Program.oUsuario.idCasilla}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Objeto> rConsultaAutogeneradoReporte(String Autogenerado)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "rConsultaAutogeneradoReporte", new Dictionary<string, object>(){
                    {"autogenerado", Autogenerado}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Objeto> rConsultaAutogeneradoReporteSegunda(String de, String para, DateTime desde, DateTime hasta)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "rConsultaAutogeneradoReporteSegunda", new Dictionary<string, object>(){
                    {"de", de},
                    {"para", para},
                    {"desde", desde},
                    {"hasta", hasta}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Estado> rListarEstado()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "rListarEstados", null);

                return deserializarPrueba<Estado>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Objeto> rConsultaElementosReporteGeneral(
            int idEstado,
            int idTipoEntrega,
            int idExpedicionOrigen,
            int idExpedicionDestino,
            int FechaDe,
            DateTime desde,
            DateTime hasta)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "rConsultaElementosReporteGeneral", new Dictionary<string, object>(){
                    {"idEstado", idEstado},
                    {"idTipoEntrega", idTipoEntrega},
                    {"idExpedicionOrigen", idExpedicionOrigen},
                    {"idExpedicionDestino", idExpedicionDestino},
                    {"FechaDe", FechaDe},
                    {"desde", desde},
                    {"hasta", hasta}
                });

                //return deserializarPrueba<Objeto>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                return JsonConvert.DeserializeObject<List<Objeto>>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Objeto> rReportesListarElementosCreadosPediente(int idExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "rReportesListarElementosCreadosPediente", new Dictionary<string, object>(){
                    {"idExpedicion", idExpedicion}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Objeto> ListarObjetosPDA(string xmlLote)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ListarObjetosPDA", new Dictionary<string, object>(){
                    {"xmlLote", xmlLote}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int ImportarObjetosValidadosPDA(List<Objeto> ListaObjetosValidados)
        {
            Objeto oo = new Objeto();
            oo.ListaXML = oo.SerializeObjectWindows(ListaObjetosValidados);
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ImportarObjetosValidadosPDA", new Dictionary<string, object>(){
                    {"xmlLote", oo.ListaXML}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        /*César Baltazar - 01/08/2016*/
        public static List<Estado> ListarEstadoEntrega()
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ListarEstadoEntrega", null);

                List<Estado> ListaEstado = new List<Estado>();

                ListaEstado = deserializarPrueba<Estado>(response);

                ListaEstado.Add(new Estado { IdEstado = 0, estado = "TODOS", iActivo = 1 });

                return ListaEstado;
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }


        // Funcional - frmEntregaPisosPrin
        //2022
        public static int ImportarResultadoPDA(Objeto oObjeto)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ImportarResultadoPDA", new Dictionary<string, object>(){
                    {"IdEntrega", oObjeto.IdEntrega},
                    {"sDetalle", oObjeto.Detalle},
                    {"IdUsuario", Program.oUsuario.ID},
                    {"IdCasilla", Program.oUsuario.idCasilla},
                    {"IdExpedicion", Program.oUsuario.IdExpedicion}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static Objeto ListarAutogeneradoCambioEstado(string autogenerado, out int respuesta)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ListarAutogeneradoCambioEstado", new Dictionary<string, object>(){
                        {"autogenerado", autogenerado}
                    });

                Objeto Ores = deserializarPrueba<Objeto>(response)[0];

                if (Ores.ID == 0)
                {
                    respuesta = 0;
                    return null;
                }
                else
                {
                    if (Ores.Estado.Equals("RECIBIDO"))
                    {
                        respuesta = -1;
                        return Ores;
                    }
                    if (Ores.Estado.Equals("CREADO") && Ores.IdExpedicionResponsable != Program.oUsuario.IdExpedicion)
                    {
                        respuesta = -2;
                        return Ores;
                    }
                    if (Ores.Estado.Equals("CUSTODIA") && Ores.IdExpedicionCustodia != Program.oUsuario.IdExpedicion)
                    {
                        respuesta = -3;
                        return Ores;
                    }
                    if (Ores.Estado.Equals("RUTA") && Ores.IdExpedicionCustodia != Program.oUsuario.IdExpedicion)
                    {
                        respuesta = -5;
                        return Ores;
                    }
                    if (Ores.Estado.Equals("RUTA") && (Ores.IdTipoEntrega == 37))
                    {
                        respuesta = -4;
                        return Ores;
                    }
                    if (Ores.Estado.Equals("CONFIRMADO"))
                    {
                        respuesta = -6;
                        return Ores;
                    }
                    if (Ores.Estado.Equals("RETIRADO"))
                    {
                        respuesta = -7;
                        return Ores;
                    }
                    respuesta = 1;
                    return Ores;
                }
            }
            catch (InvalidTokenException)
            {
                throw;
            }



        }

        public static List<Estado> cargarEstadosValidos(int idTipoEstado)
        {                                                           /* Solo sirve para los estados actuales */

            string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "rListarEstados", null);

            List<Estado> estadosTotales = Metodos.deserializarPrueba<Estado>(response);

            return estadosTotales.FindAll(x => x.IdEstado == (6 + (idTipoEstado - 7) * Math.Sign(idTipoEstado - 1)) || x.IdEstado == 6);
        }
        //2022
        public static int cambiarEstadoAutogenerado(int idElemento, int idEstadoActual, int idNuevoEstado, string observacion, byte iIdMotivoCambioEstado)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "CambiarEstadoAutogenerado", new Dictionary<string, object>(){
                    {"idElemento", idElemento},
                    {"idEstadoActual", idEstadoActual},
                    {"idNuevoEstado", idNuevoEstado},
                    {"idUsuario", Program.oUsuario.ID},
                    {"idBandeja", Program.oUsuario.idCasilla},
                    {"idGeo", Program.oUsuario.idGeoCasilla},
                    { "idExpedicion", Program.oUsuario.IdExpedicion},
                    { "observacion", observacion},
                    { "iIdMotivoCambioEstado", iIdMotivoCambioEstado}

                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        // Funcional - frmDocumentosProcesados
        public static Objeto AsociarAutogeneradoDocumentos(Objeto oObjeto)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "AsociarAutogeneradoDocumentos", new Dictionary<string, object>(){
                    {"IdTipoDocumento", oObjeto.IdTipoDocumento},
                    {"IdCasillaDe", oObjeto.IdCasillaDe},
                    {"IdCasillaPara", oObjeto.IdCasillaPara},
                    {"Asunto", oObjeto.Asunto},
                    {"Mensaje", oObjeto.Mensaje},
                    {"IdUsuario", oObjeto.IdUsuario},
                    { "ListaXML", oObjeto.ListaXML}

                });

                int ID = Convert.ToInt32(response);

                if (ID > 0)
                {
                    string response2 = Requester.AuthorizationTask(RutaWS.ObjetoWS + "GetObtener_Cabecera", new Dictionary<string, object>(){
                    {"IdObjeto", ID}

                    });

                    return deserializarPrueba<Objeto>(response2)[0];
                }
                else
                {
                    return null;
                }
            }
            catch (InvalidTokenException)
            {
                throw;
            }






        }
        //2022
        public static Objeto ListarGeoAnteriorDeObjeto(Objeto objeto)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ListarGeoAnteriorDeObjeto", new Dictionary<string, object>(){
                    {"Autogenerado", objeto.Autogenerado}
                });

                if (deserializarPrueba<Objeto>(response).Count == 0)
                {
                    return null;
                }
                return deserializarPrueba<Objeto>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Objeto> ListarObjetosGeoCambiadoDeAgencia(string objetos)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ListarObjetosGeoCambiadoDeAgencia", new Dictionary<string, object>(){
                    {"objetos", objetos}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static int RetirarObjetoDeEntregaPisos(Objeto objeto)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "RetirarObjetoDeEntregaPisos", new Dictionary<string, object>(){
                    {"IdObjeto", objeto.ID},
                    {"IdExpedicionCustodia", objeto.IdExpedicionCustodia},
                    {"IdUsuario", objeto.IdUsuario},
                    {"IdCasillaDe", objeto.IdCasillaDe},
                    {"IdGeoBandejaFisica", objeto.IdGeoBandejaFisica}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static List<Objeto> RecibirObjetosMasivoContingencia(Objeto oObjeto)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "RecibirObjetosMasivoContingencia", new Dictionary<string, object>(){
                    { "Detalle", oObjeto.Detalle},
                    { "IdUsuario", oObjeto.IdUsuario},
                    { "IdExpedicionCustodia", oObjeto.IdExpedicionCustodia}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static List<Objeto> ValidarEstadoSobrante(string Autogenerado)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ValidarEstadoSobrante", new Dictionary<string, object>(){
                    { "Autogenerado", Autogenerado}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2023
        public static int ImportarResultadoPisosPDA(Objeto oObjeto)
        {
            List<ObjetoPiso> lp = JsonConvert.DeserializeObject<List<ObjetoPiso>>(oObjeto.Detalle);
            Objeto ob = new Objeto();
            string xml = ob.SerializeObjectWindows(lp);

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ImportarResultadoPisosPDA", new Dictionary<string, object>(){
                    {"IdEntrega", oObjeto.IdEntrega},
                    {"sDetalle", oObjeto.Detalle},
                    {"IdUsuario", Program.oUsuario.ID},
                    {"IdCasilla", Program.oUsuario.idCasilla},
                    {"IdExpedicion", Program.oUsuario.IdExpedicion}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2023
        public static List<Objeto> ConsultaElementosReporteGeneral(
            int idEstado,
            int idTipoEntrega,
            int idExpedicionOrigen,
            int idExpedicionDestino,
            int FechaDe,
            DateTime desde,
            DateTime hasta)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ConsultaElementosReporteGeneral", new Dictionary<string, object>(){
                    {"idEstado", idEstado},
                    {"idTipoEntrega", idTipoEntrega},
                    {"idExpedicionOrigen", idExpedicionOrigen},
                    {"idExpedicionDestino", idExpedicionDestino},
                    {"FechaDe", FechaDe},
                    {"desde", desde},
                    {"hasta", hasta}
                });

                //return deserializarPrueba<Objeto>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                return JsonConvert.DeserializeObject<List<Objeto>>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2023
        public static List<Objeto> ConsultaElementosReporteGeneralDetalle(
            int idEstado,
            int idTipoEntrega,
            int idExpedicionOrigen,
            int idExpedicionDestino,
            int FechaDe,
            DateTime desde,
            DateTime hasta)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ConsultaElementosReporteGeneralDetalle", new Dictionary<string, object>(){
                    {"idEstado", idEstado},
                    { "idTipoEntrega", idTipoEntrega},
                    { "idExpedicionOrigen", idExpedicionOrigen},
                    { "idExpedicionDestino", idExpedicionDestino},
                    { "FechaDe", FechaDe},
                    { "desde", desde},
                    { "hasta", hasta}
                });
                return JsonConvert.DeserializeObject<List<Objeto>>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                //return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2023
        public static List<ReporteEntregaIntersucursales> ReporteEntregaIntersucursales(DateTime desde, DateTime hasta)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ReporteEntregaIntersucursales", new Dictionary<string, object>(){
                    { "desde", desde},
                    { "hasta", hasta}
                });
                return JsonConvert.DeserializeObject<List<ReporteEntregaIntersucursales>>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
    }
}