using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Interna.Entity;
using System.Data;
using simihWS.Helper;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Messaging;

namespace simihWS
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class ObjetoWS : System.Web.Services.WebService
    {
        private string queuePathEntregaPisos = System.Web.Configuration.WebConfigurationManager.AppSettings.GetValues("queuePathEntregaPisos")[0];
        private string notificacionPisos = System.Web.Configuration.WebConfigurationManager.AppSettings.GetValues("NotificacionPisos")[0];
        
        [WebMethod]
        public List<Tipo> GetTipo_Formato_Tipo(Tipo oTT)
        {
            Tipo oT = new Tipo();
            return oT.rBuscaTipo_Formato_Documento(oTT);
        }
        //2022
        [WebMethod]
        public string RegistrarCorrespondenciaMesaDePartes(int IdTipoDocumento, int IdCasillaDe, int IdCasillaPara, string Asunto, string Mensaje, string ListaXML)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "-1";
            }

            string upn = accessToken.GetUpn();

            Objeto oO = new Objeto();
            oO.IdTipoDocumento = IdTipoDocumento;
            oO.IdCasillaDe = Convert.ToInt32(accessToken.GetCasilla()); ;
            oO.IdCasillaPara = IdCasillaPara;
            oO.Asunto = Asunto;
            oO.Mensaje = Mensaje;
            //oO.IdUsuario = IdUsuario;
            oO.ListaXML = ListaXML;
            return oO.RegistrarCorrespondenciaMesaDePartes(upn).ToString();
        }

        [WebMethod]
        public int SetObjectoEXTERNA(Interna.Entity.Objeto oO)
        {
            return oO.iObjectoEXTERNA();
        }

        [WebMethod]
        public Objeto GetObjeto_key()
        {
            Objeto O = new Objeto();
            return O.rObtenerUltimoKey();
        }
        //2022
        [WebMethod]
        public string ObtenerCabecera(int IdObjeto)
        {
            Objeto O = new Objeto();
            return O.ObtenerCabecera(IdObjeto);
        }

        [WebMethod]
        public List<Objeto> GetObtener_Detalle(int IdObjeto)
        {
            Objeto oO = new Objeto();
            oO.ID = IdObjeto;
            return oO.rObtenerDetalle(oO);
        }

        [WebMethod]
        public List<ObjetoDetalle> GetObtener_Detalle2(Interna.Entity.ObjetoDetalle oO)
        {
            // ObjetoDetalle O = new ObjetoDetalle();
            return oO.rObtenerDetalle(oO);
        }

        [WebMethod]
        public List<Objeto> GetObjetosRecibidos(int id)
        {
            Objeto O = new Objeto();
            return O.rObtenerRecibidos(id);
        }

        [WebMethod]
        public List<Objeto> GetObjetosTracking(Interna.Entity.Objeto oO)
        {
            Objeto O = new Objeto();
            return O.rObtenerTracking(oO);
        }

        [WebMethod]
        public int SetObjecto_Recibir(Interna.Entity.Objeto oO)
        {
            return oO.uObjecto_Recibir();
        }

        [WebMethod]
        public int SetObjeto_Entrega(Interna.Entity.Objeto oO)
        {
            return oO.uObjeto_Entrega();
        }

        [WebMethod]
        public int SetObjeto_NoEntrega(Interna.Entity.Objeto oO)
        {
            return oO.uObjeto_NoEntrega();
        }

        [WebMethod]
        public List<Objeto> GetObjetosActivos(Interna.Entity.Objeto oC)
        {
            Objeto O = new Objeto();
            return O.rObjetosActivos_WEB_1(oC);
        }

        [WebMethod]
        public List<Objeto> GetObjetosActivosWEB_2(Interna.Entity.Objeto oC)
        {
            Objeto O = new Objeto();
            return O.rObjetosActivos_WEB_2(oC);
        }

        [WebMethod]
        public List<ObjetoDetalle> GetObjetosActivos2(int objeto)
        {
            Objeto O = new Objeto();
            return O.rObjetosActivos(objeto);
        }

        [WebMethod]
        public List<Objeto> GetObjetosHistorico(Interna.Entity.Objeto oC)
        {
            Objeto O = new Objeto();
            return O.rObjetosHistorico(oC);
        }

        [WebMethod]
        public List<Objeto> GetObjetosHistoricoSalida(Interna.Entity.Objeto oC)
        {
            Objeto O = new Objeto();
            return O.rObjetosHistoricoSalidas(oC);
        }

        [WebMethod]
        public List<Objeto> GetObjetosHistoricoRetirado(Interna.Entity.Objeto oC)
        {
            Objeto O = new Objeto();
            return O.rObjetosHistoricoRetirado(oC);
        }

        [WebMethod]
        public List<Objeto> GetObjetosDocumentosPorEnviar(Interna.Entity.Objeto oO)
        {
            Objeto O = new Objeto();
            return O.rObtenerDocumentosPorEnviar(oO);
        }

        /* POR MORIR */
        [WebMethod]
        public List<Objeto> GetObjetosDocumentosTodos(Interna.Entity.Objeto oO)
        {
            Objeto O = new Objeto();
            return O.rObtenerDocumentosTodos(oO);
        }

        [WebMethod]
        public List<Objeto> CorrespondenciaPorCustodiar(int IdExpedicion, int iBandeja, int PageRecordIndex, int PageWidth)
        {
            Objeto O = new Objeto();
            return O.rCorrespondenciaPorCustodiar(IdExpedicion, iBandeja, PageRecordIndex, PageWidth);
        }

        [WebMethod]
        public String CorrespondenciaPorCustodiarJSON(int IdExpedicion, int iBandeja, int PageRecordIndex, int PageWidth)
        {
            Objeto O = new Objeto();
            return O.MetodoPrueba(IdExpedicion, iBandeja, PageRecordIndex, PageWidth);

        }
        //PRUEBA DOCUMENTOS POR IMPRIMIR
        [WebMethod]
        public String CorrespondenciaPorCustodiarJSON2(int IdExpedicion, int iBandeja, int PageRecordIndex, int PageWidth)
        {
            Objeto O = new Objeto();
            return O.MetodoPrueba2(IdExpedicion, iBandeja);
        }

        [WebMethod]
        public int CorrespondenciaPorCustodiarCONTAR(int IdExpedicion, int iBandeja)
        {
            Objeto O = new Objeto();
            return O.rCorrespondenciaPorCustodiarCONTAR(IdExpedicion, iBandeja);
        }

        [WebMethod]
        public List<Objeto> GetObjetosDocumentosPorEntrega(Interna.Entity.Entrega oO)
        {
            Objeto O = new Objeto();
            return O.rObtenerDocumentosPorEntrega(oO);
        }

        [WebMethod]
        public Objeto GetObjetoCustodia(string autogenerado)
        {
            Objeto O = new Objeto();
            return O.rObjetoCustodia(autogenerado);
        }

        [WebMethod]
        public int SetObjectoCustodia(int idObjeto, int idOperario, int idExpedicion, int idMensajeria)
        {
            Objeto O = new Objeto();
            return O.uObjetoCustodia(idObjeto, idOperario, idExpedicion, idMensajeria);
        }

        [WebMethod]
        public int SetObjetoComunCustodia(Interna.Entity.Objeto oO)
        {
            Objeto O = new Objeto();
            return O.u_Comun_Custodia(oO);
        }

        [WebMethod]
        public Objeto SetObjetoCustodiaCodigo(String sAutogenerado, int idOperario, int idExpedicion, int idMensajeria)
        {
            Objeto O = new Objeto();
            return O.uObjetoCustodiaCodigo(sAutogenerado, idOperario, idExpedicion, idMensajeria);
        }

        [WebMethod]
        public List<Objeto> GetObjetoExpedicion(Interna.Entity.Objeto oO)
        {
            Objeto O = new Objeto();
            return O.rObjetoExpedicion(oO);
        }

        [WebMethod]
        public List<Objeto> GetObjetoExpedicion2(Interna.Entity.Objeto oO, int RecordIndex, int Width)
        {
            Objeto O = new Objeto();
            return O.rObjetoExpedicion(oO, RecordIndex, Width);
        }

        [WebMethod]
        public int GetObjetoExpedicion2CONTAR(Interna.Entity.Objeto oO)
        {
            Objeto O = new Objeto();
            return O.rObjetoExpedicionCONTAR(oO);
        }

        [WebMethod]
        public List<Objeto> GetObjetoExpedicionImpreso2(Interna.Entity.Objeto oO, int RecordIndex, int Width)
        {
            Objeto O = new Objeto();
            return O.rObjetoExpedicionImpreso(oO, RecordIndex, Width);
        }

        [WebMethod]
        public int GetObjetoExpedicionImpreso2CONTAR(Interna.Entity.Objeto oO)
        {
            Objeto O = new Objeto();
            return O.rObjetoExpedicionImpresoCONTAR(oO);
        }

        [WebMethod]
        public List<Objeto> GetObjeto_Detalle(int opc, int idCasilla, int dias)
        {
            Objeto O = new Objeto();
            return O.rObjeto_Cuadro_Mando_Detalle(opc, idCasilla, dias);
        }
        [WebMethod]
        public List<Tipo> GetTipoDocumento()
        {
            Tipo O = new Tipo();
            return O.rTipoDocumentoExterno();
        }

        [WebMethod]
        public List<Tipo> GetTipoDocumento2()
        {
            Tipo O = new Tipo();
            return O.rTipoDocumento();
        }

        [WebMethod]
        public int setObjetoExterno(Objeto oObjeto)
        {
            return oObjeto.cObjeto_Externo();
        }
        [WebMethod]
        public List<ItemError> GetItem_Error(ItemError oItem)
        {
            return oItem.lItemError();
        }

        [WebMethod]
        public List<Objeto> SetObjetoFac(int idG, int opc, int idEntrega)
        {
            Fac oFac = new Fac();
            return oFac.rVerCorrespondenciaRecibidasFAC(opc, idG, idEntrega);
        }

        [WebMethod]
        public int SetObjetoImpreso(Interna.Entity.Objeto oO)
        {
            return oO.uObjetoImpreso();
        }

        [WebMethod]
        public Objeto SetObjetoImpresoXML(Interna.Entity.Objeto oO)
        {
            return oO.uObjetoImpresoXML();
        }
        //2022
        [WebMethod]
        public string SetObjetoImpresoXML1(string listaXML, int idExpedicion, int idUsuario, int idGeoCasilla, int idCasilla)
        {
            Objeto oO = new Objeto() {
                ListaXML = listaXML
            };

            Usuario us = new Usuario()
            {
                IdExpedicion = idExpedicion, 
                ID = idUsuario, 
                idGeoCasilla = idGeoCasilla, 
                idCasilla = idCasilla
            };

            return oO.uObjetoImpresoXML1(us);
        }

        [WebMethod]
        public List<Objeto> SetObjetoFac_SALIDA(int idG)
        {
            Fac oFac = new Fac();
            return oFac.rVerCorrespondenciaRecibidasFAC_SALIDA(idG);
        }


        [WebMethod]
        public List<Objeto> GetBandejaFac()
        {
            Fac oFac = new Fac();
            return oFac.rVerBandejaFac();
        }


        [WebMethod]
        public int SetObjectoRecibir_Fac(Interna.Entity.Objeto oObjeto)
        {
            Objeto O = new Objeto();
            return O.uObjecto_Recibir_Fac(oObjeto);
        }

        [WebMethod]
        public int SetObjectoRecibir_Fac_Creados(Interna.Entity.Objeto oObjeto)
        {
            Objeto O = new Objeto();
            return O.uObjecto_Recibir_Fac_Creados(oObjeto);
        }


        [WebMethod]
        public List<Objeto> GetObjetoExpedicionImpreso(Interna.Entity.Objeto oO)
        {
            Objeto O = new Objeto();
            return O.rObjetoExpedicionImpreso(oO);
        }


        [WebMethod]
        public int SetObjectoRecibir_Fac_Observados(Interna.Entity.Objeto oObjeto)
        {
            Objeto O = new Objeto();
            return O.uObjecto_Recibir_Fac_Observados(oObjeto);
        }



        [WebMethod]
        public int SetObjectoRecibir_Fac_PorError(Interna.Entity.Objeto oObjeto)
        {
            Objeto O = new Objeto();
            return O.uObjecto_Recibir_Fac_PorError(oObjeto);
        }

        [WebMethod]
        public List<Objeto> GetListaObjeto(
            int IdTipoEstado, int IdTipoObjeto, String TextoCasilla,
            String Autogenerado, DateTime FechaInicio, DateTime FechaFin, int tipoEnrutamiento, int IdExpedicion, int PageRecordIndex, int PageWidth)//CESAR 05-04-2014
        {
            Objeto O = new Objeto();
            return O.rListaObjeto(
                IdTipoEstado,
                IdTipoObjeto,
                TextoCasilla,
                Autogenerado,
                FechaInicio,
                FechaFin,
                tipoEnrutamiento,
                IdExpedicion,//CESAR 05-04-2014
                PageRecordIndex,
                PageWidth);
        }

        /*Metodo en Prueba Benji Villarreal*/
        [WebMethod]
        public string GetListaObjetoJson(
            int IdTipoEstado, int IdTipoObjeto, String TextoCasilla,
            String Autogenerado, DateTime FechaInicio, DateTime FechaFin, int tipoEnrutamiento, int IdExpedicion, int PageRecordIndex, int PageWidth)//CESAR 05-04-2014
        {
            Objeto oO = new Objeto();
            return oO.rListaObjetoJson(
                IdTipoEstado,
                IdTipoObjeto,
                TextoCasilla,
                Autogenerado,
                FechaInicio,
                FechaFin,
                tipoEnrutamiento,
                IdExpedicion,
                PageRecordIndex,
                PageWidth);           

        }
        public class HelloWorldData
        {
            public String Message;
        }
        /*Benji villarreal*/
        public String ConvertDataTableTojSonString(DataTable dataTable)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer =
                   new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = 1200000;

            List<Dictionary<String, Object>> tableRows = new List<Dictionary<String, Object>>();

            Dictionary<String, Object> row;

            foreach (DataRow dr in dataTable.Rows)
            {
                row = new Dictionary<String, Object>();
                foreach (DataColumn col in dataTable.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                tableRows.Add(row);
            }
            return serializer.Serialize(tableRows);
        }


        [WebMethod]
        public List<Objeto> GetListaString(
            int IdTipoEstado, int IdTipoObjeto, String TextoCasilla,
            String Autogenerado, DateTime FechaInicio, DateTime FechaFin, int tipoEnrutamiento, int IdExpedicion, int PageRecordIndex, int PageWidth)//CESAR 05-04-2014
        {
            Objeto O = new Objeto();
            return O.rListaObjeto(
                IdTipoEstado,
                IdTipoObjeto,
                TextoCasilla,
                Autogenerado,
                FechaInicio,
                FechaFin,
                tipoEnrutamiento,
                IdExpedicion,//CESAR 05-04-2014
                PageRecordIndex,
                PageWidth);

        }

        [WebMethod]
        public int GetListaObjetoCONTAR(
            int IdTipoEstado, int IdTipoObjeto, String TextoCasilla,
            String Autogenerado, String FechaInicio, String FechaFin, int tipoEnrutamiento, int IdExpedicion) //CESAR 05-04-2014
        {
            Objeto O = new Objeto();
            return O.GetListaObjetoCONTAR(
                IdTipoEstado, IdTipoObjeto, TextoCasilla,
                Autogenerado, FechaInicio, FechaFin, tipoEnrutamiento, IdExpedicion);//CESAR 05-04-2014
        }

        [WebMethod]
        public List<Tipo> GetTipoEstado()
        {
            Tipo O = new Tipo();
            return O.rListaEstado();
        }


        [WebMethod]
        public int SetObjectoEliminar(int id, int estado, int acceso, int idUsuario)
        {
            Objeto O = new Objeto();
            return O.uObjecto_Eliminar(id, estado, acceso, idUsuario);
        }

        //SIM1
        //Datos del Lote para Tarjetas
        [WebMethod]
        public List<Tipo> GetTipoLote()
        {
            Tipo O = new Tipo();
            return O.rListaLotes();
        }

        [WebMethod]
        public List<Tipo> GetMotivoCarga()
        {
            Tipo O = new Tipo();
            return O.rListaMotivosCarga();
        }

        [WebMethod]
        public List<Tipo> GetMotivoCarga2(int Tipo)
        {
            Tipo O = new Tipo();
            return O.rListaMotivosCarga(Tipo);
        }

        //POR DESCARTAR
        [WebMethod]
        public List<Objeto> GetListaLotes()
        {
            Objeto O = new Objeto();
            return O.rListaLotes();
        }
        //--
        [WebMethod]
        public List<Objeto> Lotes(int PageRecordIndex, int PageWidth)
        {
            Objeto O = new Objeto();
            return O.Lotes(PageRecordIndex, PageWidth);
        }

        [WebMethod]
        public int LotesCONTAR()
        {
            Objeto O = new Objeto();
            return O.LotesCONTAR();
        }

        //POR DESCARTAR
        [WebMethod]
        public List<Objeto> GetListaDetalleLote(Interna.Entity.Objeto objO)
        {
            Objeto O = new Objeto();
            return O.rListaDetalleLote(objO);
        }
        //--

        [WebMethod]
        public List<Objeto> DetalleLotes(Interna.Entity.Objeto objO, int PageRecordIndex, int PageWidth)
        {
            Objeto O = new Objeto();
            return O.DetalleLotes(objO, PageRecordIndex, PageWidth);
        }

        [WebMethod]
        public int DetalleLotesCONTAR(Interna.Entity.Objeto objO)
        {
            Objeto O = new Objeto();
            return O.DetalleLotesCONTAR(objO);
        }
        //


        [WebMethod]
        public Objeto GetObjetoValidar(int id)
        {
            Objeto O = new Objeto();
            return O.rObjecto_Validar(id);
        }

        //Publicacion
        [WebMethod]
        public List<Tipo> GetTipoPublicacion()
        {
            Tipo O = new Tipo();
            return O.rListaTipoPublicacion();
        }

        [WebMethod]
        public string GetEquipoCoordinador(int indice)
        {
            Tipo O = new Tipo();
            return O.rListaEquipoCoordinador(indice);
        }

        //POR DESCARTAR
        [WebMethod]
        public List<Objeto> GetListaPorPublicar(int id)
        {
            Objeto O = new Objeto();
            return O.rListadoPorPublicar(id);
        }
        //---
        [WebMethod]
        public List<Objeto> CorrespondenciaPorPublicar(int id, int PageRecordIndex, int PageWidth)
        {
            Objeto O = new Objeto();
            return O.CorrespondenciaPorPublicar(id, PageRecordIndex, PageWidth);
        }


        [WebMethod]
        public int CorrespondenciaPorPublicarCONTAR(int id)
        {
            Objeto O = new Objeto();
            return O.CorrespondenciaPorPublicarCONTAR(id);
        }

        [WebMethod]
        public int setCargarDatosCoordinacion(Interna.Entity.Objeto oObjeto)
        {
            return oObjeto.CargarDatosCoordinacion();
        }

        [WebMethod]
        public int setQuitarDatosCoordinacion(Interna.Entity.Objeto oObjeto)
        {
            return oObjeto.QuitarDatosCoordinacion();
        }

        //POR DESCARTAR
        [WebMethod]
        public List<Objeto> GetListaPublicados(int ID)
        {
            Objeto O = new Objeto();
            return O.rListadoPublicados(ID);
        }
        //--
        [WebMethod]
        public List<Objeto> CorrespondenciaPublicada(int ID, int PageRecordIndex, int PageWidth)
        {
            Objeto O = new Objeto();
            return O.CorrespondenciaPublicada(ID, PageRecordIndex, PageWidth);
        }

        [WebMethod]
        public int CorrespondenciaPublicadaCONTAR(int ID)
        {
            Objeto O = new Objeto();
            return O.CorrespondenciaPublicadaCONTAR(ID);
        }

        //Coordinacion
        [WebMethod]
        public List<Objeto> GetListaCoordinacionEnFrio(Interna.Entity.Objeto oObjeto)
        {
            Objeto O = new Objeto();
            return O.rListadoCoordinacionEnFrio(oObjeto);
        }

        //Datos generales      
        [WebMethod]
        public Persona GetDatosPersona(int idPersona, int ind)
        {
            Persona O = new Persona();
            return O.rDatosPersona(idPersona, ind);
        }

        [WebMethod]
        public List<Persona> GetDirecciones(int idPersona, int ind)
        {
            Persona O = new Persona();
            return O.rDirecciones(idPersona, ind);
        }

        [WebMethod]
        public List<Persona> GetTelefonos(int idPersona, int ind)
        {
            Persona O = new Persona();
            return O.rTelefonos(idPersona, ind);
        }

        //Descaga virtual       
        [WebMethod]
        public Objeto GetDatosCoordinacion(int id)
        {
            Objeto O = new Objeto();
            return O.rDatosCoordinacion(id);
        }

        [WebMethod]
        public List<Tipo> GetMotivosRezago()
        {
            Tipo O = new Tipo();
            return O.rListaMotivosRezago();
        }

        [WebMethod]
        public List<Tipo> GetResultadoVisita()
        {
            Tipo O = new Tipo();
            return O.rListaResultadoVisita();
        }

        [WebMethod]
        public List<Tipo> GetTipoIdc()
        {
            Tipo O = new Tipo();
            return O.rListaTipoIdc();
        }

        [WebMethod]
        public List<Tipo> GetTipoVinculo()
        {
            Tipo O = new Tipo();
            return O.rListaTipoVinculo();
        }

        [WebMethod]
        public int setDescargaVirtual(Objeto objO)
        {
            return objO.uCoordinacion();
        }

        //Detalle Autogenerado      
        [WebMethod]
        public Objeto GetDatosAutogenerado(int id)
        {
            Objeto O = new Objeto();
            return O.rDatosAutogenerado(id);
        }

        //Asignar Ruta       
        [WebMethod]
        public int GetDatosAsignarRuta(string autogenerado, int id)
        {
            Objeto O = new Objeto();
            return O.uDatosAsignarRuta(autogenerado, id);
        }

        [WebMethod]
        public List<Objeto> GetListaRutasAsignadas()
        {
            Objeto O = new Objeto();
            return O.rListadoRutasAsignadas();
        }

        [WebMethod]
        public List<Tipo> GetRutas()
        {
            Tipo O = new Tipo();
            return O.rListaRutas();
        }

        //Carga de datos
        [WebMethod]
        public List<Tipo> GetTipoServicio()
        {
            Tipo O = new Tipo();
            return O.rListaTipoServicio();
        }

        [WebMethod]
        public List<Tipo> GetTipoEstadoTarjeta()
        {
            Tipo O = new Tipo();
            return O.rListaTipoEstado();
        }


        //Entrega tarjetas visitas 
        [WebMethod]
        public List<Tipo> GetTipoDestino(int d)
        {
            Tipo O = new Tipo();
            return O.rListaTipoDestino(d);
        }

        [WebMethod]
        public List<Objeto> GetListaVisitasRegulares(int ruta)
        {
            Objeto O = new Objeto();
            return O.rListaVisitasRegulares(ruta);
        }

        [WebMethod]
        public List<Objeto> GetRutasAsignadas()
        {
            Objeto O = new Objeto();
            return O.rRutasAsignadas();
        }

        [WebMethod]
        public Objeto GetVisitaTop(string autogenerado)
        {
            Objeto O = new Objeto();
            return O.rVisitaTop(autogenerado);
        }

        //Descarga Física
        //20/11/2013
        [WebMethod]
        public int setDescargaFisica(Interna.Entity.Objeto oObjeto)
        {
            return oObjeto.uDescargoFisico();
        }
        //Edición de estados
        [WebMethod]
        public List<Objeto> getEstados(int iEstado)
        {
            Objeto O = new Objeto();
            O.IdTipoEstado = iEstado;
            return O.rEstados();
        }
        [WebMethod]
        public List<Objeto> getMotivos()
        {
            Objeto O = new Objeto();
            return O.rMotivos();
        }
        [WebMethod]
        public int setModificarEstado(Interna.Entity.Objeto oObjeto)
        {
            return oObjeto.uModificarEstado();
        }

        //Control courier
        //En custodia de externos
        [WebMethod]
        public List<Objeto> GetObjetoExternoCustodia()
        {
            Objeto O = new Objeto();
            return O.rListadoExternoCustodia();
        }


        [WebMethod]
        public int setCoordinacionExterna(Objeto objO)
        {
            return objO.iCoordinacionExterna();
        }

        /*Cesar21/04/2014*/
        [WebMethod]
        public List<Objeto> getEstadoCargaArchivo()
        {
            Objeto O = new Objeto();
            return O.rEstadoCargaArchivo();
        }

        // Jhoel
        // 04-02-14
        [WebMethod]
        public List<Tipo> getListaOpciones()
        {
            Tipo oEntrega = new Tipo();
            return oEntrega.rListarOpciones();
        }


        [WebMethod]
        public List<Objeto> getListaEntregaExterna(int idmodo, string codigo, int idservicio, int idmensajeria, int RecordIndex, int Width)
        {
            Objeto O = new Objeto();
            return O.rListaEntregaExterna(idmodo, codigo, idservicio, idmensajeria, RecordIndex, Width);
        }

        [WebMethod]
        public int getListaEntregaExternaCONTAR(int idmodo, string codigo, int idservicio, int idmensajeria)
        {
            Objeto O = new Objeto();
            return O.getListaEntregaExternaCONTAR(idmodo, codigo, idservicio, idmensajeria);
        }

        [WebMethod]
        public List<Objeto> GetObjetosDocumentosPorEntregaExterna(Interna.Entity.Entrega oO, int PageRecordIndex, int PageWidth)
        {
            Objeto O = new Objeto();
            return O.rObtenerDocumentosPorEntregaExterna(oO, PageRecordIndex, PageWidth);
        }

        [WebMethod]
        public int GetObjetosDocumentosPorEntregaExternaCONTAR(int IdEntrega)
        {
            Objeto O = new Objeto();
            return O.rObtenerDocumentosPorEntregaExternaCONTAR(IdEntrega);
        }

        [WebMethod]
        public List<Objeto> getListaExternaIniciado()
        {
            Objeto O = new Objeto();
            return O.rListaExternaIniciado();
        }

        [WebMethod]
        public List<Objeto> getListaMonitorResultados(int IdExpedicion, int PageRecordIndex, int PageWidth)
        {
            Objeto O = new Objeto();
            return O.rListaMonitorResultados(IdExpedicion, PageRecordIndex, PageWidth);
        }

        [WebMethod]
        public int ListaMonitorResultadosCONTAR(int IdExpedicion)
        {
            Objeto O = new Objeto();
            return O.ListaMonitorResultadosCONTAR(IdExpedicion);
        }

        //Fin

        [WebMethod]
        public List<Tipo> GetProductoExterna()
        {
            Tipo O = new Tipo();
            return O.rProductoExterna();
        }

        [WebMethod]
        public int setDescargaExternaFisica(Objeto objO)
        {
            return objO.uDescargaFisicaExterna();
        }

        [WebMethod]
        public int setDescargaExternaVirtual(Objeto objO)
        {
            return objO.uDescargaVirtualExterna();
        }
        //
        [WebMethod]
        public Objeto getDatosExterna(int id)
        {
            Objeto O = new Objeto();
            return O.rListaDatosExterna(id);
        }

        [WebMethod]
        public List<Objeto> GetListaConfirmados(int PageRecordIndex, int PageWidth)
        {
            Objeto O = new Objeto();
            return O.rListaConfirmados(PageRecordIndex, PageWidth);
        }

        [WebMethod]
        public int ListaConfirmadosCONTAR()
        {
            Objeto O = new Objeto();
            return O.ListaConfirmadosCONTAR();
        }

        [WebMethod]
        public int setEnviarCargos(Objeto objeto)
        {
            return objeto.EnviarCargos();
        }
        
        [WebMethod]
        public int setObjetoComun(Objeto objO)
        {
            Objeto Ou = new Objeto();
            return Ou.c_ObjetoComun(objO);
        }

        [WebMethod]
        public List<Objeto> GetListaComun(Objeto objO)
        {
            Objeto O = new Objeto();
            return O.r_ListaComun(objO);
        }

        [WebMethod]
        public int GetListaComunCONTAR()
        {
            Objeto oObjeto = new Objeto();

            return oObjeto.GetListaComunCONTAR();
        }

        //Custodiar documenteos desde la ventana de "Documentos por recibir"       
        [WebMethod]
        public int CorrespondenciaPorCustodiarGrupo(Interna.Entity.Objeto oO, int idUsuario, int idExpedicion, int idMensajeria)
        {
            Objeto O = new Objeto();
            return O.CorrespondenciaPorCustodiarGrupo(oO, idUsuario, idExpedicion, idMensajeria);
        }
        [WebMethod]
        public Objeto GetObjetoImpresion(Objeto oO)
        {
            return oO.objetoImpresion();
        }
        [WebMethod]
        public Objeto GetObjetoPorImprimir(Objeto oO)
        {
            return oO.objetoPorImprimir();
        }

        [WebMethod]
        public int getDocumentosPorEntregarCONTAR(Entrega oO)
        {
            Objeto O = new Objeto();
            return O.DocumentosPorEntregarCONTAR(oO);
        }

        [WebMethod]
        public List<Objeto> GetDocumentosPorEntregarPagina(Interna.Entity.Entrega oO)
        {
            Objeto O = new Objeto();
            return O.rDocumentosPorEntregarPagina(oO);
        }

        [WebMethod]
        public int setEntregaExpress(int id, string dni, string nombre, int idUsuario, int idExpedicionOrigen)
        {
            Objeto O = new Objeto();
            return O.entregaExpress(id, dni, nombre, idUsuario, idExpedicionOrigen);
        }


        [WebMethod]
        public List<Objeto> GetObjetosFACHistorica(int opcion, int iGeo, int nDias)
        {
            Fac O = new Fac();
            return O.rVerCorrespondenciaFACHistorica(opcion, iGeo, nDias);
        }

        [WebMethod]
        public int setNuevoTipoDocumento(string descripcion, int tipo, string alias, string abreviatura)
        {
            Tipo t = new Tipo();
            return t.cTipoDocumento(descripcion, tipo, alias, abreviatura);
        }

        [WebMethod]
        public int setModificarTipoDocumento(int id, string descripcion, int tipo, string alias, string abreviatura, int activo)
        {
            Tipo t = new Tipo();
            return t.uTipoDocumento(id, descripcion, tipo, alias, abreviatura, activo);
        }

        [WebMethod]
        public Objeto SetActualizarObjetoSeguimiento(String sAutogenerado,
                                                        int iEstado,
                                                        int iUsuario,
                                                        int iBandeja,
                                                        int iExpedicion,
                                                        int iProceso,
                                                        int iMotivo,
                                                        String sFechaEntrega,
                                                        String sEntregaDNI,
                                                        String sEntregaObservacion,
                                                        int iEntregaResultado)
        {
            Objeto O = new Objeto();
            return O.uObjetoSeguimiento(sAutogenerado, iEstado, iUsuario, iBandeja, iExpedicion, iProceso, iMotivo, sFechaEntrega, sEntregaDNI, sEntregaObservacion, iEntregaResultado);
        }

        [WebMethod]
        public int setObjeto_EntregaXML(Objeto oO, int iUsuario, int iBandeja, int iExpedicion, int iProceso, int iMotivo)
        {
            Objeto oObj = new Objeto();
            return oObj.uObjeto_EntregaXML(oO, iUsuario, iBandeja, iExpedicion, iProceso, iMotivo);
        }

        [WebMethod]
        public List<Objeto> getObjetoSeguimiento(int IdObjeto)
        {
            Objeto O = new Objeto();
            O.ID = IdObjeto;
            return O.rObjetoSeguimiento(O);
        }
        [WebMethod]
        public int SetModificarObjetoSeguimiento(int ID, string sAutogenerado,
                                                        int iEstado,
                                                        int iUsuario,
                                                        int iBandeja,
                                                        int iExpedicion,
                                                        int iProceso,
                                                        int iMotivo,
                                                        string sEntregaDNI,
                                                        string sEntregaObservacion)
        {
            Objeto O = new Objeto();
            return O.uModificarObjetoSeguimiento(ID, sAutogenerado, iEstado, iUsuario, iBandeja, iExpedicion, iProceso, iMotivo, sEntregaDNI, sEntregaObservacion);
        }


        //LISTAR TODOS LOS CUSTODIADOS DEL DIA Y DEL DIA ANTERIOR
        [WebMethod]
        public String GetObjetoExpedicion_prueba(Interna.Entity.Objeto oO, int num)
        {
            Objeto O = new Objeto();
            return O.rObjetoExpedicion_prueba(oO, num);
        }

        //2022
        [WebMethod]
        public String GetObjetoExpedicion_prueba1(int idExpedicionCustodia, DateTime fechaHasta, DateTime fechaDesde, int num)
        {
            Objeto O = new Objeto();
            return O.rObjetoExpedicion_prueba1(idExpedicionCustodia, fechaDesde, fechaHasta, num);
        }
        //2022
        [WebMethod]
        public String CorrespondenciaPorCustodiarJSON3(int IdExpedicion)
        {
            Objeto O = new Objeto();
            return O.rCorrespondenciaPorCustodiar2(IdExpedicion);
        }
                
        //2022
        [WebMethod]
        public string R_OBTENERCREADO(string bandejaRemitente, string bandejaDestinatario, int idExpedicion)
        {
            Objeto obj = new Objeto();
            return obj.rObtenerCreados(bandejaRemitente, bandejaDestinatario, idExpedicion);
        }
        [WebMethod]
        public string getObjetosAsociadosEntrega(int iExpedicion, string lPalomares)
        {
            Objeto o = new Objeto();
            return o.rObjetosAsociadosEntrega(iExpedicion, lPalomares);
        }
        //PRUEBA CAMBIO DE ESTADO 31/07/2015
        [WebMethod]
        public Objeto uCambioEstado(string xml, Usuario us, int tipo)
        {
            Objeto o = new Objeto();
            return o.uCambioEstado(xml, us, tipo);
        }
        [WebMethod]
        public List<string> getTrackingObjeto(Objeto ob)
        {
            Objeto oO = new Objeto();
            return oO.GetTrackingObjeto(ob);

        }

        [WebMethod]
        public string rObjetoPalomar(int idPalomar)
        {
            Objeto oO = new Objeto();
            return oO.rObjetoPalomar(idPalomar);

        }
        //2022
        [WebMethod]
        public string rOneObjetoCustodia(string Autogenerado, int idExpedicion, string remitente, string destinatario, string fechaDesde, string fechaHasta)
        {
            Objeto Oo = new Objeto();
            return Oo.rOneObjetoCustodia(Autogenerado, remitente, destinatario, idExpedicion, fechaDesde, fechaHasta);
        }


        //2022
        [WebMethod]
        public string ValidarEstadoObjeto(string Autogenerado)
        {
            Objeto Oo = new Objeto();
            return Oo.ValidarEstadoObjeto(Autogenerado);
        }
        [WebMethod]
        public int uGrabarTipoValidacion(string detalle, int idEntrega, int idUsuario, int idBandeja, int idExpedicion, int idGeoCasilla)
        {
            Objeto Oo = new Objeto();
            return Oo.uGrabarTipoResultado(detalle, idEntrega, idUsuario, idBandeja, idExpedicion, idGeoCasilla);
        }
        //2022
        [WebMethod]
        public string rObjetoOtraSucursal(string sAutogenerado, string sRemitente, string sDestinatario, int iExpedicion)
        {
            Objeto oO = new Objeto();
            return oO.rObjetosOtraSucursal(sAutogenerado, sRemitente, sDestinatario, iExpedicion);
        }
        //2022
        [WebMethod]
        public int uCustodiaAutogeneradoOtraSucursal(int iAutogenerado, int iUsuario, int iExpedicion, int iCasilla, int iGeoCasilla)
        {
            Objeto oO = new Objeto();
            return oO.uCustodiaAutogeneradoOtraSucursal(iAutogenerado, iUsuario, iExpedicion, iCasilla, iGeoCasilla);
        }

        [WebMethod]
        public string TipoDocumentoMesaPartes(string sAlias)
        {
            Tipo oO = new Tipo();
            return oO.rTipoDocumentoMesaParte(sAlias);
        }

        [WebMethod]
        public int uRegularizarObjeto(int IdObjeto, int idUsuario, int idBandeja, int idExpedicion, int idGeo)
        {
            Objeto obj = new Objeto();
            obj.ID = IdObjeto;
            Objeto Obj = new Objeto();
            return Obj.uRegularizarObjeto(obj, idUsuario, idBandeja, idExpedicion, idGeo);
        }
        //2022
        [WebMethod]
        public string rObtenerSobrantes(string autogenerado, int idexpedicion)
        {
            Objeto oO = new Objeto();
            return oO.rObtenerSobrantes(autogenerado, idexpedicion);
        }
        //2022
        [WebMethod]
        public int uRegularizarObjetoSobrante(int IdObjeto, int idExpedicion, int idUsuario, int idGeo, int idCasilla)
        {
            Objeto oO = new Objeto();
            oO.ID = IdObjeto;
            return oO.uRegularizarObjetoSobrante(oO, idUsuario, idCasilla, idExpedicion, idGeo);
        }
        //2022
        [WebMethod]
        public List<string> SeguimientoAutogeneradoDesktop(int ID)
        {
            Objeto oO = new Objeto();            
            Objeto ob = new Objeto();
            ob.ID = ID;
            return oO.SeguimientoAutogeneradoDesktop(ob);
        }

        //2022
        [WebMethod]
        public string rConsultaAutogeneradoReporte(String autogenerado)
        {
            Objeto oO = new Objeto();
            return oO.rConsultaAutogeneradoReporte(autogenerado);

        }
        //2022
        [WebMethod]
        public string rConsultaAutogeneradoReporteSegunda(String de, String para, DateTime desde, DateTime hasta)
        {
            Objeto oO = new Objeto();
            return oO.rConsultaAutogeneradoReporte(de, para, desde, hasta);
        }
        //2022
        [WebMethod]
        public string rListarEstados()
        {
            Estado oO = new Estado();
            return oO.ListarEstados();
        }
        //2022
        [WebMethod]
        public string rConsultaElementosReporteGeneral(int idEstado, int idTipoEntrega, int idExpedicionOrigen, int idExpedicionDestino,
            int FechaDe, DateTime desde, DateTime hasta)
        {
            Objeto Oo = new Objeto();
            return Oo.rConsultaElementosReporteGeneral(idEstado, idTipoEntrega, idExpedicionOrigen, idExpedicionDestino, FechaDe, desde, hasta);
        }
        //2022
        [WebMethod]
        public string rReportesListarElementosCreadosPediente(int idExpedicion)
        {
            Objeto oo = new Objeto();
            return oo.rReportesListarElementosCreadosPediente(idExpedicion);
        }
        //2022
        [WebMethod]
        public string ListarObjetosPDA(string xmlLote)
        {
            Objeto oObjeto = new Objeto();
            return oObjeto.ListarObjetosPDA(xmlLote);
        }
        //2022
        [WebMethod]
        public int ImportarObjetosValidadosPDA(string xmlLote)
        {
            Objeto oObjeto = new Objeto();
            return oObjeto.ImportarObjetosValidadosPDA(xmlLote);
        }

        [WebMethod]
        public string ListarEstadoEntrega()
        {
            Estado oO = new Estado();
            return oO.ListarEstadoEntrega();
        }

        [WebMethod]
        public string ListarTipoEmpaque() 
        {
            Tipo tipo = new Tipo();
            return tipo.ListarTipoEmpaque();
        }

        [WebMethod]
        public string ListarTipoDocumentoPorTipoEmpaque(int iIdTipoEmpaque)
        {
            Tipo tipo = new Tipo();
            return tipo.ListarTipoDocumentoPorTipoEmpaque(iIdTipoEmpaque);
        }

        // Funcional - frmEntregaPisosPrin
        //2022
        [WebMethod]
        public int ImportarResultadoPDA(int IdEntrega, string sDetalle, int IdUsuario, int IdCasilla, int IdExpedicion)
        {
            Objeto oObjeto = new Objeto();

            oObjeto.IdEntrega = IdEntrega;
            oObjeto.Detalle = sDetalle;

            Usuario oUsuario = new Usuario();
            oUsuario.ID = IdUsuario;
            oUsuario.idCasilla = IdCasilla;
            oUsuario.IdExpedicion = IdExpedicion;

            return oObjeto.ImportarResultadoPDA(oUsuario);

            
        }
        //2022
        [WebMethod]
        public string ListarAutogeneradoCambioEstado(string autogenerado)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto o = new Objeto();
            return o.ListarAutogeneradoCambioEstado(autogenerado);
        }
        //2022
        [WebMethod]
        public int CambiarEstadoAutogenerado(int idElemento, int idEstadoActual, int idNuevoEstado, int idUsuario, int idBandeja, int idGeo, int idExpedicion, string observacion, byte iIdMotivoCambioEstado)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }
            Objeto o = new Objeto();
            return o.CambiarEstadoAutogenerado(idElemento, idEstadoActual, idNuevoEstado, idUsuario, idBandeja, idGeo, idExpedicion, observacion, iIdMotivoCambioEstado);
        }
        // Funcional - frmDocumentosProcesados
        [WebMethod]
        public int AsociarAutogeneradoDocumentos(int IdTipoDocumento, int IdCasillaDe, int IdCasillaPara, string Asunto, string Mensaje, int IdUsuario, string ListaXML)
        {
            Objeto oObjeto = new Objeto();
            return oObjeto.AsociarAutogeneradoDocumentos(IdTipoDocumento, IdCasillaDe, IdCasillaPara, Asunto, Mensaje, IdUsuario,ListaXML);
        }
        //2022
        [WebMethod]
        public string ListarGeoAnteriorDeObjeto(string Autogenerado)
        {
            Objeto objeto = new Objeto();
            objeto.Autogenerado = Autogenerado;
            return objeto.ListarGeoAnteriorDeObjeto(objeto);
        }
        //2022
        [WebMethod]
        public string ListarObjetosGeoCambiadoDeAgencia(string objetos)
        {
            Objeto objeto = new Objeto();
            return objeto.ListarObjetosGeoCambiadoDeAgencia(objetos);
        }

        [WebMethod]
        public int RetirarObjetoDeEntregaPisos(int IdObjeto, int IdExpedicionCustodia, int IdUsuario, int IdCasillaDe, int IdGeoBandejaFisica)
        {
            Objeto objeto = new Objeto();
            objeto.ID = IdObjeto;
            objeto.IdExpedicionCustodia = IdExpedicionCustodia;
            objeto.IdUsuario = IdUsuario;
            objeto.IdCasillaDe = IdCasillaDe; // Casilla de la expedicion
            objeto.IdGeoBandejaFisica = IdGeoBandejaFisica;
            return objeto.RetirarObjetoDeEntregaPisos();
        }

        //2022
        [WebMethod]
        public string RecibirObjetosMasivoContingencia(string Detalle, int IdUsuario, int IdExpedicionCustodia)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }
            Objeto oObjeto = new Objeto() {
                Detalle = Detalle, 
                IdUsuario = IdUsuario, 
                IdExpedicionCustodia = IdExpedicionCustodia
            };

            return oObjeto.RecibirObjetosMasivoContingencia();
        }
        //2022
        [WebMethod]
        public string rConsultaElementosReporteGeneralDetalle(int idEstado, int idTipoEntrega, int idExpedicionOrigen, int idExpedicionDestino,
            int FechaDe, DateTime desde, DateTime hasta)
        {
            Objeto Oo = new Objeto();
            return Oo.rConsultaElementosReporteGeneralDetalle(idEstado, idTipoEntrega, idExpedicionOrigen, idExpedicionDestino, FechaDe, desde, hasta);
        }
        //2022
        [WebMethod]
        public String ValidarEstadoSobrante(string Autogenerado)
        {
            Objeto Oo = new Objeto();
            return Oo.ValidarEstadoSobrante(Autogenerado);
        }
        //2023
        [WebMethod]
        public int ImportarResultadoPisosPDA(int IdEntrega, string sDetalle, int IdUsuario, int IdCasilla, int IdExpedicion)
        {
            Objeto oObjeto = new Objeto();

            oObjeto.IdEntrega = IdEntrega;
            oObjeto.Detalle = sDetalle;

            Usuario oUsuario = new Usuario();
            oUsuario.ID = IdUsuario;
            oUsuario.idCasilla = IdCasilla;
            oUsuario.IdExpedicion = IdExpedicion;

            int resultadoEntrega = oObjeto.ImportarResultadoPisosPDA(oUsuario);

            //agregar if para activar o desactivar funcionalidad (traer valor de bd)
            if (resultadoEntrega == 1)
            {
                //ejecturar procedimiento de notificación por correo
                if (notificacionPisos == "1")
                {
                    NotificarEntregaEnBandejaFisica(oObjeto.IdEntrega);
                }
                
            }

            return resultadoEntrega;


        }
        //2023
        private void NotificarEntregaEnBandejaFisica(int entregaId)
        {
            string queuePath = queuePathEntregaPisos;
            string mensaje = entregaId.ToString();
            using (MessageQueue queue = new MessageQueue(queuePath))
            {
                Message message = new Message();
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
                message.Body = mensaje;
                queue.Send(message);
            }
        }

        //2023
        [WebMethod]
        public string ConsultaElementosReporteGeneral(int idEstado, int idTipoEntrega, int idExpedicionOrigen, int idExpedicionDestino,
            int FechaDe, DateTime desde, DateTime hasta)
        {
            Objeto Oo = new Objeto();
            return Oo.ConsultaElementosReporteGeneral(idEstado, idTipoEntrega, idExpedicionOrigen, idExpedicionDestino, FechaDe, desde, hasta);
        }

        //2023
        [WebMethod]
        public string ConsultaElementosReporteGeneralDetalle(int idEstado, int idTipoEntrega, int idExpedicionOrigen, int idExpedicionDestino,
            int FechaDe, DateTime desde, DateTime hasta)
        {
            Objeto Oo = new Objeto();
            return Oo.ConsultaElementosReporteGeneralDetalle(idEstado, idTipoEntrega, idExpedicionOrigen, idExpedicionDestino, FechaDe, desde, hasta);
        }

        //2023
        [WebMethod]
        public string ReporteEntregaIntersucursales(DateTime desde, DateTime hasta)
        {
            Objeto Oo = new Objeto();
            return Oo.ReporteEntregaIntersucursales(desde, hasta);
        }
        
    }

}