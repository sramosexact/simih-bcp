using Interna.Entity;
using System;
using System.Collections.Generic;
//using System.Messaging;
using System.Web.Services;
using System.Xml.Linq;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de EntregaWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class EntregaWS : System.Web.Services.WebService
    {
        private string queuePathEntregaAgencias = System.Web.Configuration.WebConfigurationManager.AppSettings.GetValues("queuePathEntregaAgencias")[0];
        private string notificacionAgencias = System.Web.Configuration.WebConfigurationManager.AppSettings.GetValues("NotificacionAgencias")[0];

        [WebMethod]
        public List<Tipo> getTipoEntrega()
        {
            Tipo oTE = new Tipo();
            return oTE.rBuscaTipo_Entrega();
        }

        [WebMethod]
        public int setGrabarEntrega(Entrega entEntrega)
        {
            return entEntrega.pcsGrabar();
        }

        [WebMethod]
        public int setIniciarEntrega(Entrega entEntrega)
        {
            return entEntrega.pcsIniciar();
        }

        [WebMethod]
        public int setTerminarEntrega(Entrega entEntrega)
        {
            return entEntrega.pcsTerminar();
        }

        [WebMethod]
        public int setCerrarEntrega(Entrega entEntrega, int iUsuario, int iBandeja, int iExpedicion, int iProceso, int iMotivo)
        {
            return entEntrega.uCerrarEntregaPisos(iUsuario, iBandeja, iExpedicion, iProceso, iMotivo);
        }

        [WebMethod]
        public int setEliminarEntrega(Entrega entEntrega)
        {
            return entEntrega.pcsEliminar();
        }

        [WebMethod]
        public List<Entrega> getListarEntrega(Entrega entEntrega)
        {
            return entEntrega.pcsListar();
        }

        [WebMethod]
        public List<Entrega> getListarEntregaModo(Entrega entEntrega, int PageRecordIndex, int PageWidth)
        {
            return entEntrega.rListarEntregaModo(PageRecordIndex, PageWidth);
        }

        [WebMethod]
        public int getListarEntregaModoCONTAR(Entrega entEntrega)
        {
            return entEntrega.rListarEntregaModoCONTAR();
        }

        [WebMethod]
        public Entrega getEntregaId(int ID)
        {
            Entrega entEntrega = new Entrega();
            return entEntrega.rEntregaId(ID);
        }

        [WebMethod]
        public int setValidarEncasillado(Entrega entEntrega)
        {
            return entEntrega.uValidaEncasillado();
        }

        [WebMethod]
        public int setValidarEncasilladoPDA(Entrega entEntrega)
        {
            return entEntrega.uValidarEncasilladoPDA();
        }

        [WebMethod]
        public int setValidarEncasilladoMasivoPDA(Objeto oLista)
        {
            Entrega oE = new Entrega();
            return oE.uValidarEncasilladoMasivoPDA(oLista);
        }

        [WebMethod]
        public int setProcesarPisosMasivoPDA(Objeto oLista)
        {
            Entrega oE = new Entrega();
            return oE.uProcesarPisosMasivoPDA(oLista);
        }


        [WebMethod]
        public int setEliminarObjetoEntrega(Entrega oEntrega)
        {
            return oEntrega.dObjeto_Entrega();
        }
        [WebMethod]
        public int setReemplazarObjetosEntrega(Entrega oEntrega)
        {
            return oEntrega.uReemplazarObjetosEntrega();
        }
        [WebMethod]
        public int setAgregarObjetosEntrega(Entrega oEntrega)
        {
            return oEntrega.uAgregarObjetosEntrega();
        }

        //Entrega de tarjetas    
        //20/11/2013
        [WebMethod]
        public int setGrabarEntregaTarjeta(Entrega entEntrega)
        {
            return entEntrega.pcsGrabarTarjeta();
        }

        [WebMethod]
        public Entrega getEntregaTarjetaId(int ID)
        {
            Entrega entEntrega = new Entrega();
            return entEntrega.rEntregaTarjetaId(ID);
        }

        [WebMethod]
        public int setTerminarEntregaTarjeta(Entrega entEntrega)
        {
            return entEntrega.pcsTerminarEntregaTarjeta();
        }

        [WebMethod]
        public int setCerrarEntregaTarjeta(Entrega entEntrega)
        {
            return entEntrega.pcsCerrarTarjeta();
        }
        // Jhoel
        // 06-03-14
        //[WebMethod]
        //public List<Entrega> ListarOpciones()
        //{
        //    Entrega oEntrega = new Entrega();
        //    return oEntrega.rListarOpciones();
        //}
        [WebMethod]
        public int setGrabarEntregaExterna(Entrega entEntrega)
        {
            return entEntrega.pcsGrabarExterna();
        }

        [WebMethod]
        public int setGrabarEntregaExternaObjeto(Entrega entEntrega)
        {
            return entEntrega.pcsGrabarExternaObjeto();
        }

        [WebMethod]
        public Entrega getEntregaExternaId(int ID)
        {
            Entrega entEntrega = new Entrega();
            return entEntrega.rEntregaExternaId(ID);
        }
        //Fin


        // pollo
        [WebMethod]
        public List<Entrega> ListarEntregaObjetoWeb(int idGeo)
        {
            Entrega oEntrega = new Entrega();
            return oEntrega.rListarEntregaObjetoWeb(idGeo);
        }

        // alessandro
        [WebMethod]
        public List<Entrega> EntregasAutomaticas(Entrega oEntrega)
        {
            return oEntrega.EntregasAutomaticas();
        }

        [WebMethod]
        public List<Objeto> getListarObjetoEntregaPDA(int IdExpedicion, int Tipo)
        {
            Entrega oE = new Entrega();
            return oE.rListarObjetoEntregaPDA(IdExpedicion, Tipo);
        }

        [WebMethod]
        public int getEntregaAccionCONTAR(int IdExpedicion, int TipoEntrega, int EstadoEntrega)
        {
            Entrega oE = new Entrega();
            return oE.rEntregaAccionCONTAR(IdExpedicion, TipoEntrega, EstadoEntrega);
        }

        [WebMethod]
        public int setEntregaAccionMasivo(int IdExpedicion, int TipoEntrega, int EstadoEntrega)
        {
            Entrega oE = new Entrega();
            return oE.uEntregaAccionMasivo(IdExpedicion, TipoEntrega, EstadoEntrega);
        }

        [WebMethod]
        public int setEntregaInicia(Entrega entEntrega, int iBandeja, int iExpedicion, int iProceso)
        {
            return entEntrega.uIniciaEntrega(iBandeja, iExpedicion, iProceso);
        }
        //2022
        [WebMethod]
        public string getEntregaLista(int iExpedicion, int iTipoEntrega, int iModo)
        {
            Entrega oE = new Entrega();
            string j = oE.rListaEntregas(iExpedicion, iTipoEntrega, iModo);
            return j;
        }

        [WebMethod]
        public int setGrabarEntregaPisos(Entrega entEntrega)
        {
            return entEntrega.cCrearEntrega();
        }
        //2022
        [WebMethod]
        public List<string> getEntregaDetalle(int iEntrega)
        {
            Entrega oE = new Entrega();
            return oE.rEntregaDetalle(iEntrega);
        }
        //2022
        [WebMethod]
        public string ListarAutogeneradosEntregasSucursalRecibidas(int IdUsuario)
        {
            Entrega oE = new Entrega();
            return oE.ListarAutogeneradosEntregasSucursalRecibidas(IdUsuario);
        }
        //2022
        [WebMethod]
        public List<string> EntregaGrupoAgenciaDetalle(int IdGrupo)
        {
            Entrega oE = new Entrega();
            return oE.EntregaAgenciaDetalle(IdGrupo);
        }

        [WebMethod]
        public int setExportarImportarMovil(Entrega oE, int opcion)
        {
            return oE.uExportarImportarMovil(opcion);
        }

        [WebMethod]
        public int setIniciarEntregaPisos(Entrega entEntrega)
        {
            return entEntrega.uIniciarEntregaPisos();
        }

        [WebMethod]
        public int setTerminarEntregaPisos(Entrega oe)
        {
            return oe.uTerminarEntregaPisos();
        }

        [WebMethod]
        public int setCrearEntregaSucursales(int iExpedicion, int iPalomar, int iUsuario)
        {
            Entrega oe = new Entrega();
            return oe.cCrearEntregaSucursales(iExpedicion, iPalomar, iUsuario);
        }
        //2022
        [WebMethod]
        public string rEntregaID(int iEntrega)
        {
            Entrega oE = new Entrega();
            return oE.rEntrega(iEntrega);
        }
        //2022
        [WebMethod]
        public int uEntregaSucursal(int iEntrega, int iUsuario)
        {
            Entrega oE = new Entrega();
            return oE.uEntregaSucursal(iEntrega, iUsuario);
        }
        //2022
        [WebMethod]
        public int uValidaEntregaSucursal(int iEntrega, string sDetalle)
        {
            Entrega oE = new Entrega();
            return oE.uValidaEntregaSucursal(iEntrega, sDetalle);
        }
        //2022
        [WebMethod]
        public int GuardarCambiosEntregaAgencias(int IdEntregaGrupo, string sDetalle)
        {
            Entrega oE = new Entrega();
            return oE.GuardarCambiosEntregaAgencias(IdEntregaGrupo, sDetalle);
        }

        //2022
        [WebMethod]
        public int uRecargarEntregaSucursal(int iEntrega)
        {
            Entrega oE = new Entrega();
            return oE.uRecargarEntregaSucursal(iEntrega);
        }

        [WebMethod]
        public int uRetirarEntregaSucursal(int iEntrega)
        {
            Entrega oE = new Entrega();
            return oE.uRetirarEntregaSucursal(iEntrega);
        }
        //2022
        [WebMethod]
        public int setIniciarEntregaSucursal(int IdEntrega, int IdExpedicion, int IdUsuario, int IdBandeja)
        {
            Entrega oEntrega = new Entrega();
            oEntrega.ID = IdEntrega;
            oEntrega.IdExpedicionOrigen = IdExpedicion;
            oEntrega.IdUsuarioCreador = IdUsuario;
            oEntrega.idTipoValidacion = IdBandeja;
            return oEntrega.uIniciarEntregaSucursal();
        }
        //2022
        [WebMethod]
        public string rEntregaSucursalDestino(int iExpedicion)
        {
            Entrega oE = new Entrega();
            return oE.rEntregaSucursalDestino(iExpedicion);
        }
        // Funcional - frmNuevaEntregaPisos
        [WebMethod]
        public int setCrearEntregaPisos(int iExpedicion, int iOperativoAsignado, string Palomares, int iIdUsuarioLogeado)
        {
            Entrega oe = new Entrega();
            return oe.cCrearEntregaPisos(iExpedicion, iOperativoAsignado, Palomares, iIdUsuarioLogeado);
        }

        //2022
        [WebMethod]
        public int dEntregaSucursal(int iEntrega)
        {
            Entrega oe = new Entrega();
            return oe.dEliminarEntregaSucursal(iEntrega);
        }
        //2022
        [WebMethod]
        public int EliminarEntregasAgenciaVacias(int IdEntregaGrupo)
        {
            Entrega oe = new Entrega();
            return oe.EliminarEntregasAgenciaVacias(IdEntregaGrupo);
        }

        //2022
        [WebMethod]
        public int uModificarEntregaPisos(int idEntrega, int idUsuario, string detalle, int idexpedicion)
        {
            Entrega En = new Entrega();
            return En.uModificaEntregaPisos(idEntrega, idUsuario, detalle, idexpedicion);
        }
        //2022
        [WebMethod]
        public String rRefrescar(int modo, int idTipoEntrega, int IdEntrega, int IdExpedicionOrigen)
        {
            Entrega En = new Entrega();
            En.ID = IdEntrega;
            En.IdExpedicionOrigen = IdExpedicionOrigen;
            return En.refrescar(modo, idTipoEntrega, En);
        }
        //2022
        [WebMethod]
        public int uEntregaPisosIniciar(int idEntrega, int idUsuario, int idExpedicion, int idBandeja)
        {
            Entrega En = new Entrega();
            return En.uEntregaPisosIniciar(idEntrega, idUsuario, idExpedicion, idBandeja);
        }
        //2022
        [WebMethod]
        public int uEntregaPisosTerminar(int idEntrega, int idExpedicion, int idUsuario)
        {
            Entrega En = new Entrega();
            return En.uEntregaPisosTerminar(idEntrega, idExpedicion, idUsuario);
        }

        [WebMethod]
        public int uEntregaPisosCerrar(int idEntrega, int idExpedicion, int idUsuario)
        {
            Entrega En = new Entrega();
            return En.uEntregaPisosTerminar(idEntrega, idExpedicion, idUsuario);
        }
        //2022
        [WebMethod]
        public string uRecepcionEntregaSucursal(int iEntrega, int iExpedicion, int iUsuario)
        {
            Entrega oe = new Entrega();
            return oe.uRecepcionEntregaSucursal(iEntrega, iExpedicion, iUsuario);
        }

        //2022
        [WebMethod]
        public int CustodiaAutogeneradoEntregaSucursal(int iEntrega, int iUsuario, int iExpedicion, string sDetalle)
        {
            Entrega oe = new Entrega();
            return oe.CustodiaAutogeneradosEntregaSucursal(iEntrega, iUsuario, iExpedicion, sDetalle);
        }
        //2022
        [WebMethod]
        public int CustodiarAutogeneradosEntregasSucursal(int iUsuario, string sDetalle)
        {
            Entrega oe = new Entrega();
            return oe.CustodiarAutogeneradosEntregasSucursal(iUsuario, sDetalle);
        }
        //2022
        [WebMethod]
        public string rObtenerDocumentosPorEntregaJson(int IdEntrega)
        {
            Entrega Oo = new Entrega();
            Oo.ID = IdEntrega;
            return Oo.rObtenerDocumentosPorEntregaJson(Oo);
        }

        [WebMethod]
        public int rRefrescarEntregaPisos(Entrega o)
        {
            Entrega Oo = new Entrega();
            return Oo.rRefrescarEntregaPisos(o);
        }
        [WebMethod]
        public int rValidarObjetoEntregaPisos(String json, int idEntrega, DateTime fecha)
        {
            Entrega Oo = new Entrega();
            return Oo.rValidarObjetoEntregaPisos(json, idEntrega, fecha);
        }
        //2022
        [WebMethod]
        public int rEliminarObjetoEntregaPisos(int idEntrega)
        {
            Entrega Oo = new Entrega();
            return Oo.rEliminarObjetoEntregaPisos(idEntrega);
        }
        //2022
        [WebMethod]
        public int rEliminarEntregaPisos(int idEntrega)
        {
            Entrega Oo = new Entrega();
            return Oo.rEliminarEntregaPisos(idEntrega);
        }
        //2022
        [WebMethod]
        public int uGrabarEntregaPisos(string detalle, int idEntrega, int idgeo, int idbandeja, int idusuario, int idexpedicion)
        {
            Entrega Oo = new Entrega();
            return Oo.uGrabarEntregaPisos(detalle, idEntrega, idgeo, idbandeja, idusuario, idexpedicion);
        }
        //2022
        [WebMethod]
        public int uCerrarEntregaPisos1(int idEntrega, int idExpedicion, int idUsuario, int idBandeja, int idGeo)
        {
            Entrega Oo = new Entrega();
            return Oo.uCerrarEntregaPisos1(idEntrega, idExpedicion, idUsuario, idBandeja, idGeo);
        }

        //2022
        [WebMethod]
        public string rEntregaSucursalDestinoRuta(int iExpedicion)
        {
            Entrega oE = new Entrega();
            return oE.rEntregaSucursalDestinoRuta(iExpedicion);
        }

        // Funcional - frmListaEntregaAgencia
        [WebMethod]
        public string rEntregaAgencias(int iExpedicion)
        {
            Entrega oE = new Entrega();
            return oE.rEntregaAgencia(iExpedicion);
        }
        //2022
        [WebMethod]
        public string ListarEntregaGrupoAgencia(int iExpedicion)
        {
            Entrega oE = new Entrega();
            return oE.ListarEntregaGrupoAgencia(iExpedicion);
        }

        /*CESAR 26/11/2015*/
        [WebMethod]
        public int cCrearEntregaAgencia(int iExpedicion, int iColaborador, int iPalomar, DateTime dFecha)
        {
            Entrega oE = new Entrega();
            return oE.cCrearEntregaAgencia(iExpedicion, iColaborador, iPalomar, dFecha);
        }
        //2022
        [WebMethod]
        public int RecargarEntregaAgencia(int iEntrega)
        {
            Entrega oE = new Entrega();
            return oE.RecargarEntregaAgencia(iEntrega);
        }

        /*CESAR 30/11/2015*/
        [WebMethod]
        public int uIniciarEntregaAgencia(int iEntrega, int iExpedicion, int iUsuario, int iBandeja)
        {
            Entrega oE = new Entrega();
            return oE.uIniciarEntregaAgencia(iEntrega, iExpedicion, iUsuario, iBandeja);
        }

        /*CESAR 01/12/2015*/
        [WebMethod]
        public List<string> EntregaAgenciaDetalle(int iEntrega)
        {
            Entrega oE = new Entrega();
            return oE.rEntregaAgenciaDetalle(iEntrega);
        }

        /*CESAR 02/12/2015*/
        [WebMethod]
        public int ValidaEncasilladoMovil(int iEntrega, string sDetalleXml)
        {
            Entrega oE = new Entrega();
            return oE.uValidaEncasilladoMovil(iEntrega, sDetalleXml);
        }
        //2022
        [WebMethod]
        public int uGrabarCambioObjetoEntregaPisos(string detalle, int idEntrega, int idUsuario, int idBandeja, int idExpedicion, int idGeoCasilla, int Tipo)
        {
            Entrega oE = new Entrega();
            return oE.uGrabarCambioObjetoEntregaPisos(detalle, idEntrega, idUsuario, idBandeja, idExpedicion, idGeoCasilla, Tipo);
        }

        [WebMethod]
        public int uEntregaPisosDesvalidarObjeto(int idObjeto, int idEntrega)
        {
            Entrega oE = new Entrega();
            return oE.uEntregaPisosDesvalidarObjeto(idObjeto, idEntrega);
        }
        //2022
        [WebMethod]
        public int setExportarImportarMovilModo(int ID, int opcion, int forma)
        {
            Entrega entrega = new Entrega();
            entrega.ID = ID;
            return entrega.uExportarImportarMovilModo(opcion, forma);
        }

        [WebMethod]
        public string rListarTipoEntregas()
        {

            return new Entrega().rListarTipoEntregas();
        }
        //200
        [WebMethod]
        public string rElementosPorRefrescar(int idEntrega)
        {
            return new Entrega().rElementosPorRefrescar(idEntrega);
        }

        //2022
        [WebMethod]
        public int EliminarEntregaAgencia(string ListaEntregas)
        {
            Entrega oE = new Entrega();
            return oE.EliminarEntregaAgencia(ListaEntregas);
        }
        // Funcional - frmListaEntregaAgencias
        [WebMethod]
        public int IniciarLoteEntregaAgencia(int ID, int IdExpedicion, int idCasilla, string xmlLote)
        {
            Entrega oE = new Entrega();
            Usuario usuario = new Usuario()
            {
                ID = ID,
                IdExpedicion = IdExpedicion,
                idCasilla = idCasilla
            };
            return oE.IniciarLoteEntregaAgencia(usuario, xmlLote);
        }
        //2022
        [WebMethod]
        public int IniciarLoteAgenciasGrupo(int ID, int IdExpedicion, int idCasilla, string xmlLote)
        {
            Entrega oE = new Entrega();
            Usuario usuario = new Usuario()
            {
                ID = ID,
                IdExpedicion = IdExpedicion,
                idCasilla = idCasilla
            };

            int resultadoEntrega = oE.IniciarLoteAgenciasGrupo(usuario, xmlLote);

            //agregar if para activar o desactivar funcionalidad(traer valor de bd)
            //if (resultadoEntrega == 1)
            //{
            //    XDocument xmlDoc = XDocument.Parse(xmlLote);

            //    string loteId = xmlDoc.Root.Element("ENTREGA").Element("IIDENTREGAGRUPO").Value;

            //    //ejecutar procedimiento de notificación por correo
            //    if (notificacionAgencias == "1")
            //    {
            //        NotificarEntregaAgencias(loteId);
            //    }

            //}

            return resultadoEntrega;
        }
        //2023
        //private void NotificarEntregaAgencias(string loteId)
        //{
        //    string queuePath = queuePathEntregaAgencias;
        //    string mensaje = loteId;
        //    using (MessageQueue queue = new MessageQueue(queuePath))
        //    {
        //        Message message = new Message();
        //        message.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
        //        message.Body = mensaje;
        //        queue.Send(message);
        //    }
        //}


        /*César Baltazar - 01/08/2016 */
        [WebMethod]
        public string ListarEntregaAgenciaPorEstado(int iEstado, DateTime dDesde, DateTime dHasta)
        {
            Entrega oE = new Entrega();
            return oE.ListarEntregaAgenciaPorEstado(iEstado, dDesde, dHasta);
        }

        //2022
        [WebMethod]
        public string ListarEntregaAgenciaSeguimiento(int idExpedicion)
        {
            return new Entrega()
            {
                IdExpedicionOrigen = idExpedicion
            }.ListarEntregaAgenciaSeguimiento();
        }
        //2022
        [WebMethod]
        public int EliminarEntregaPisosResultado(int idEntrega, int idExpedicion, int idUsuario, int idBandeja, int idGeo)
        {
            Entrega Oo = new Entrega();
            return Oo.EliminarEntregaPisosResultado(idEntrega, idExpedicion, idUsuario, idBandeja, idGeo);
        }
        // Funcional - frmEntregaPisosPrin
        [WebMethod]
        public int rEstadoEntrega(int idEntrega)
        {
            Entrega Oo = new Entrega();
            return Oo.rEstadoEntrega(idEntrega);
        }
        //2022
        [WebMethod]
        public int CrearEntregaSucursal(int IdExpedicion, int IdPalomar, int IdColaborador, int idUsuarioCreador)
        {
            Entrega oEntrega = new Entrega();
            Expedicion oExpedicion = new Expedicion();
            Palomar oPalomar = new Palomar();
            Operario oColaborador = new Operario();

            oExpedicion.ID = IdExpedicion;
            oPalomar.ID = IdPalomar;
            oColaborador.ID = IdColaborador;
            return oEntrega.CrearEntregaSucursal(oExpedicion, oPalomar, oColaborador, idUsuarioCreador);
        }
        //2022
        [WebMethod]
        public string ListarEntregasSucursalesActivas(int IdExpedicionOrigen)
        {
            Entrega oEntrega = new Entrega();
            oEntrega.IdExpedicionOrigen = IdExpedicionOrigen;
            return oEntrega.ListarEntregasSucursalesActivas();
        }
        // Funcional - frmListaEntregaAgencias

        [WebMethod]
        public int ModificarCantidadBultos(int ID, byte iCantidadBultos)
        {
            Entrega entrega = new Entrega()
            {
                ID = ID,
                iCantidadBultos = iCantidadBultos
            };
            return entrega.ModificarCantidadBultos();
        }
        //2023
        [WebMethod]
        public int GrabarCambiosEntregaAgencias(int IdEntregaGrupo, string elementosJson)
        {
            Entrega oE = new Entrega();
            return oE.GrabarCambiosEntregaAgencias(IdEntregaGrupo, elementosJson);
        }

        //2023
        [WebMethod]
        public int RecargarElementosEntregaAgencia(int idEntregaGrupo)
        {
            Entrega oE = new Entrega();
            return oE.RecargarElementosEntregaAgencia(idEntregaGrupo);
        }
    }
}
