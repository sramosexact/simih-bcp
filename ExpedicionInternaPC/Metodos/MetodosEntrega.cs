using Interna.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static List<Entrega> EntregaLista(int iExpedicion, int iTipoEntrega, int iModo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "getEntregaLista", new Dictionary<string, object>(){
                    {"iExpedicion", iExpedicion},
                    {"iTipoEntrega", iTipoEntrega},
                    {"iModo", iModo}
                });

                return deserializarPrueba<Entrega>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }



        //2022
        public static List<string> EntregaDetalle(int iEntrega)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "getEntregaDetalle", new Dictionary<string, object>(){
                    {"iEntrega", iEntrega}
                });

                string[] sl = deserializarPrueba<string>(response).ToArray();

                List<string> sLista = new List<string>();
                if (sl.Length > 0)
                {
                    foreach (String s in sl)
                    {
                        sLista.Add(s);
                    }
                }
                return sLista;
            }
            catch (InvalidTokenException)
            {
                throw;
            }


        }
        //2022
        public static List<Objeto> ListarAutogeneradosEntregasSucursalRecibidas()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "ListarAutogeneradosEntregasSucursalRecibidas", new Dictionary<string, object>(){
                    {"IdUsuario", Program.oUsuario.ID }
                });
                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }


        }
        //2022
        public static List<string> EntregaGrupoAgenciaDetalle(int IdGrupo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "EntregaGrupoAgenciaDetalle", new Dictionary<string, object>(){
                    {"IdGrupo", IdGrupo}
                });

                string[] sl = deserializarPrueba<string>(response).ToArray();

                List<string> sLista = new List<string>();
                if (sl.Length > 0)
                {
                    foreach (String s in sl)
                    {
                        sLista.Add(s);
                    }
                }
                return sLista;
            }
            catch (InvalidTokenException)
            {
                throw;
            }


        }



        //2022
        public static List<Entrega> EntregaID(int iEntrega)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "rEntregaID", new Dictionary<string, object>(){
                    {"iEntrega", iEntrega}
                });

                return deserializarPrueba<Entrega>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static int ActualizarEntregaSucursal(int iEntrega, int iUsuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "uEntregaSucursal", new Dictionary<string, object>(){
                    {"iEntrega", iEntrega},
                    {"iUsuario", iUsuario}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int ValidarEntregaSucursal(int iEntrega, string sDetalle)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "uValidaEntregaSucursal", new Dictionary<string, object>(){
                    {"iEntrega", iEntrega},
                    {"sDetalle", sDetalle}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int GuardarCambiosEntregaAgencias(int IdEntregaGrupo, string sDetalle)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "GuardarCambiosEntregaAgencias", new Dictionary<string, object>(){
                    {"IdEntregaGrupo", IdEntregaGrupo},
                    {"sDetalle", sDetalle}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int RecargarEntregaSucursal(int iEntrega)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "uRecargarEntregaSucursal", new Dictionary<string, object>(){
                    {"iEntrega", iEntrega}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }


        //2022
        public static int IniciarEntregaSucursal(int iEntrega, int iExpedicion, int iUsuario, int iBandeja)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "setIniciarEntregaSucursal", new Dictionary<string, object>(){
                    {"IdEntrega", iEntrega},
                    {"IdExpedicion", iExpedicion},
                    {"IdUsuario", iUsuario},
                    {"IdBandeja", iBandeja}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }



        }
        //2022
        public static List<Entrega> ListaEntregaSucursalDestino(int iExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "rEntregaSucursalDestino", new Dictionary<string, object>(){
                    {"iExpedicion", iExpedicion}
                });

                return deserializarPrueba<Entrega>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        // Funcional - frmNuevaEntregaPisos
        public static int CrearEntregaPisos(int iExpedicion, int iColaborador, string Palomares)
        {
            //ServiceEntregaWS.EntregaWS olWS = new ServiceEntregaWS.EntregaWS();
            //ServiceEntregaWS.Entrega ows = new ServiceEntregaWS.Entrega();
            //return olWS.setCrearEntregaPisos(iExpedicion, iColaborador, Palomares, Program.oUsuario.ID);

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "setCrearEntregaPisos", new Dictionary<string, object>(){
                    {"iExpedicion", iExpedicion},
                    {"iOperativoAsignado", iColaborador},
                    {"Palomares", Palomares},
                    {"iIdUsuarioLogeado", Program.oUsuario.ID}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int ModificarEntregaPisos(int idEntrega, int iColaborador, string detalle, int idexpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "uModificarEntregaPisos", new Dictionary<string, object>(){
                    {"idEntrega", idEntrega},
                    {"idUsuario", iColaborador},
                    {"detalle", detalle},
                    {"idexpedicion", idexpedicion}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static int EliminarEntregaSucursal(int iEntrega)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "dEntregaSucursal", new Dictionary<string, object>(){
                    {"iEntrega", iEntrega}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }


        }
        //2022
        public static int EliminarEntregasAgenciaVacias(int IdEntregaGrupo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "EliminarEntregasAgenciaVacias", new Dictionary<string, object>(){
                    {"IdEntregaGrupo", IdEntregaGrupo}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static Entrega rRefrescar(int modo, int idTipoEntrega, Entrega oo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "rRefrescar", new Dictionary<string, object>(){
                    {"modo", modo},
                    {"idTipoEntrega", idTipoEntrega},
                    {"IdEntrega", oo.ID},
                    {"IdExpedicionOrigen", oo.IdExpedicionOrigen}
                });

                return deserializarPrueba<Entrega>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static int uEntregaPisosIniciar(int idEntrega, int idUsuario, int idExpedicion, int idBandeja)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "uEntregaPisosIniciar", new Dictionary<string, object>(){
                    {"idEntrega", idEntrega},
                    {"idUsuario", idUsuario},
                    {"idExpedicion", idExpedicion},
                    {"idBandeja", idBandeja}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int uEntregaPisosTerminar(int idEntrega, int idExpedicion, int idUsuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "uEntregaPisosTerminar", new Dictionary<string, object>(){
                    {"idEntrega", idEntrega},
                    {"idExpedicion", idExpedicion},
                    {"idUsuario", idUsuario}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Entrega> RecepcionEntregaSucursal(int iEntrega, int iExpedicion, int iUsuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "uRecepcionEntregaSucursal", new Dictionary<string, object>(){
                    {"iEntrega", iEntrega},
                    {"iExpedicion", iExpedicion},
                    {"iUsuario", iUsuario}
                });

                return deserializarPrueba<Entrega>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static int CustodiaAutogeneradoEntregaSucursal(int iEntrega, int iUsuario, int iExpedicion, string sDetalle)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "CustodiaAutogeneradoEntregaSucursal", new Dictionary<string, object>(){
                    { "iEntrega", iEntrega},
                    { "iUsuario", iUsuario},
                    { "iExpedicion", iExpedicion},
                    { "sDetalle", sDetalle}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int CustodiarAutogeneradosEntregasSucursal(int iUsuario, string sDetalle)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "CustodiarAutogeneradosEntregasSucursal", new Dictionary<string, object>(){
                    { "iUsuario", iUsuario},
                    { "sDetalle", sDetalle}
                });
                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Objeto> rObtenerDocumentosPorEntregaJson(Entrega Oo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "rObtenerDocumentosPorEntregaJson", new Dictionary<string, object>(){
                    { "IdEntrega", Oo.ID}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        //2022
        public static int rEliminarObjetoEntregaPisos(int idEntrega)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "rEliminarObjetoEntregaPisos", new Dictionary<string, object>(){
                    { "idEntrega", idEntrega}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int rEliminarEntregaPisos(int idEntrega)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "rEliminarEntregaPisos", new Dictionary<string, object>(){
                    { "idEntrega", idEntrega}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int uGrabarEntregaPisos(string detalle, int idEntrega)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "uGrabarEntregaPisos", new Dictionary<string, object>(){
                    {"detalle", detalle},
                    {"idEntrega", idEntrega},
                    {"idgeo", Program.oUsuario.idGeo},
                    {"idbandeja", Program.oUsuario.idCasilla},
                    {"idusuario", Program.oUsuario.ID},
                    {"idexpedicion", Program.oUsuario.IdExpedicion}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int uCerrarEntregaPisos1(int idEntrega, int idExpedicion, int idUsuario, int idBandeja, int idGeo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "uCerrarEntregaPisos1", new Dictionary<string, object>(){
                    {"idEntrega", idEntrega},
                    {"idExpedicion", idExpedicion},
                    {"idUsuario", idUsuario},
                    {"idBandeja", idBandeja},
                    {"idGeo", idGeo}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Entrega> ListaEntregaSucursalDestinoRuta(int iExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "rEntregaSucursalDestinoRuta", new Dictionary<string, object>(){
                    {"iExpedicion", iExpedicion}
                });

                return deserializarPrueba<Entrega>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        // Funcional - frmListaEntregaAgencia
        public static List<Entrega> ListaEntregaAgencias(int iExpedicion)
        {
            /*ServiceEntregaWS.EntregaWS olWS = new ServiceEntregaWS.EntregaWS();
            string j = olWS.rEntregaAgencias(iExpedicion);*/

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "rEntregaAgencias", new Dictionary<string, object>(){
                    {"iExpedicion", iExpedicion}
                });

                return deserializarPrueba<Entrega>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }


        }
        //2022
        public static List<Entrega> ListarEntregaGrupoAgencia(int iExpedicion)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "ListarEntregaGrupoAgencia", new Dictionary<string, object>(){
                    {"iExpedicion", iExpedicion}
                });

                return deserializarPrueba<Entrega>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }


        }

        /*CESAR 26/11/2015*/
        public static int CrearEntregaAgencia(int iExpedicion, int iColaborador, int iPalomar, DateTime dFecha)
        {
            //ServiceEntregaWS.EntregaWS olWS = new ServiceEntregaWS.EntregaWS();
            //ServiceEntregaWS.Entrega ows = new ServiceEntregaWS.Entrega();
            //return olWS.cCrearEntregaAgencia(iExpedicion, iColaborador, iPalomar, dFecha);

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "cCrearEntregaAgencia", new Dictionary<string, object>(){
                    {"iExpedicion", iExpedicion},
                    {"iColaborador", iColaborador},
                    {"iPalomar", iPalomar},
                    {"dFecha", dFecha}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static int RecargarEntregaAgencia(int iEntrega)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "RecargarEntregaAgencia", new Dictionary<string, object>(){
                    {"iEntrega", iEntrega}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }


        //2022
        public static int uGrabarCambioObjetoEntregaPisos(string detalle, int idEntrega, int Tipo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "uGrabarCambioObjetoEntregaPisos", new Dictionary<string, object>(){
                    {"detalle", detalle},
                    {"idEntrega", idEntrega},
                    {"idUsuario", Program.oUsuario.ID},
                    {"idBandeja", Program.oUsuario.idCasilla},
                    {"idExpedicion", Program.oUsuario.IdExpedicion},
                    {"idGeoCasilla", Program.oUsuario.idGeoCasilla},
                    {"Tipo", Tipo}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static int ExportarImportarMovilModo(int ID, int opcion, int forma) // 1 EXPORTAR  2 IMPORTAR
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "setExportarImportarMovilModo", new Dictionary<string, object>(){
                    {"ID", ID},
                    {"opcion", opcion},
                    {"forma", forma}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        //2022
        public static List<Objeto> rElementosPorRefrescar(int idEntrega)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "rElementosPorRefrescar", new Dictionary<string, object>(){
                    {"idEntrega", idEntrega}
                });

                return deserializarPrueba<Objeto>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int EliminarEntregaAgencia(string sLote)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "EliminarEntregaAgencia", new Dictionary<string, object>(){
                    {"ListaEntregas", sLote}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        // Funcional - frmListaEntregaAgencias
        public static int IniciarLoteEntregaAgencia(string xmlLote)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "IniciarLoteEntregaAgencia", new Dictionary<string, object>(){
                    {"ID", Program.oUsuario.ID},
                    { "IdExpedicion", Program.oUsuario.IdExpedicion},
                    { "idCasilla", Program.oUsuario.idCasilla},
                    { "xmlLote", xmlLote}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int IniciarLoteAgenciasGrupo(string xmlLote)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "IniciarLoteAgenciasGrupo", new Dictionary<string, object>(){
                    {"ID", Program.oUsuario.ID},
                    { "IdExpedicion", Program.oUsuario.IdExpedicion},
                    { "idCasilla", Program.oUsuario.idCasilla},
                    { "xmlLote", xmlLote}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        /*César Baltazar - 01/08/2016 */
        public static List<Entrega> ListarEntregaAgenciaPorEstado(int iEstado, DateTime dDesde, DateTime dHasta)
        {
            //ServiceEntregaWS.EntregaWS wsEntrega = new ServiceEntregaWS.EntregaWS();
            //return deserializarPrueba<Entrega>(wsEntrega.ListarEntregaAgenciaPorEstado(iEstado, dDesde, dHasta));

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "ListarEntregaAgenciaPorEstado", new Dictionary<string, object>(){
                    {"iEstado", iEstado},
                    {"dDesde", dDesde},
                    {"dHasta", dHasta}
                });

                return deserializarPrueba<Entrega>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Entrega> ListarEntregaAgenciaSeguimiento()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "ListarEntregaAgenciaSeguimiento", new Dictionary<string, object>() {
                    { "idExpedicion", Program.oUsuario.IdExpedicion}
                });

                return deserializarPrueba<Entrega>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static int EliminarEntregaPisosResultado(int idEntrega, int idExpedicion, int idUsuario, int idBandeja, int idGeo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "EliminarEntregaPisosResultado", new Dictionary<string, object>(){
                    {"idEntrega", idEntrega},
                    {"idExpedicion", idExpedicion},
                    {"idUsuario", idUsuario},
                    {"idBandeja", idBandeja},
                    {"idGeo", idGeo}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        // Funcional - frmEntregaPisosPrin
        public static int rEstadoEntrega(int idEntrega)
        {
            //return new ServiceEntregaWS.EntregaWS().rEstadoEntrega(idEntrega);
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "rEstadoEntrega", new Dictionary<string, object>(){
                    {"idEntrega", idEntrega}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int CrearEntregaSucursal(Expedicion oExpedicion, Palomar oPalomar, Operario oColaborador)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "CrearEntregaSucursal", new Dictionary<string, object>(){
                    {"IdExpedicion", oExpedicion.ID},
                    {"IdPalomar", oPalomar.ID},
                    {"IdColaborador", oColaborador.ID},
                    {"idUsuarioCreador", Program.oUsuario.ID}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Entrega> ListarEntregasSucursalesActivas(Entrega oEntrega)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "ListarEntregasSucursalesActivas", new Dictionary<string, object>(){
                    {"IdExpedicionOrigen", oEntrega.IdExpedicionOrigen}
                });

                return deserializarPrueba<Entrega>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        // Funcional - frmListaEntregaAgencias
        public static int ModificarCantidadBultos(Entrega oEntrega)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "ModificarCantidadBultos", new Dictionary<string, object>(){
                    {"ID", oEntrega.ID},
                    { "iCantidadBultos", oEntrega.iCantidadBultos}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static List<string> EntregaAgenciaDetalleGrupo(int IdGrupo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "EntregaGrupoAgenciaDetalle", new Dictionary<string, object>(){
                    {"IdGrupo", IdGrupo}
                });

                return JsonConvert.DeserializeObject<List<string>>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });


            }
            catch (InvalidTokenException)
            {
                throw;
            }


        }

        //2023
        public static int GrabarCambiosEntregaAgencias(int IdEntregaGrupo, string elementosJson)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "GrabarCambiosEntregaAgencias", new Dictionary<string, object>(){
                    {"IdEntregaGrupo", IdEntregaGrupo},
                    {"elementosJson", elementosJson}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2023
        public static int RecargarElementosEntregaAgencia(int idEntregaGrupo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.EntregaWS + "RecargarElementosEntregaAgencia", new Dictionary<string, object>(){
                    {"idEntregaGrupo", idEntregaGrupo}
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