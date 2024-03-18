using Interna.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Objeto : Interna.Core.Entity
    {
        // CAMPOS PARA LA PAGINACION
        public int PageRecordIndex { get; set; }
        public int PageWidth { get; set; }
        public int countRows { get; set; }

        // CAMPOS BASE
        [DataMember]
        public String Ticket { get; set; }
        [DataMember]
        public String Autogenerado { get; set; }
        [DataMember]
        public int ID { get; set; }
        public int IdUsuario { get; set; }
        [DataMember]
        public String De { get; set; }
        [DataMember]
        public String Para { get; set; }
        [DataMember]
        public String CasillaDe { get; set; }
        [DataMember]
        public String CasillaPara { get; set; }
        public String cantidadBd { get; set; }
        [DataMember]
        public int IdCasillaDe { get; set; }
        [DataMember]
        public int IdCasillaPara { get; set; }
        public String Asunto { get; set; }
        public String Mensaje { get; set; }

        [DataMember]
        public int iIdGeoDestinoAnterior { get; set; }

        [DataMember]
        public string sGeoDestinoAnterior { get; set; }

        [DataMember]
        public int iIdGeoDestino { get; set; }

        [DataMember]
        public string sGeoDestino { get; set; }

        [DataMember]
        public String Observacion { get; set; }

        [DataMember]
        public int IdPadre { get; set; }
        [DataMember]
        public int Empaque { get; set; }

        public List<Objeto> Lista = null;

        [DataMember]
        public String ListaXML { get; set; }

        [Column(Name = "iIdTipoObjeto")]
        [DataMember]
        public int IdTipoDocumento { get; set; }

        [DataMember(Name = "TipoObjeto")]
        [Column(Name = "TipoObjeto")]
        public String TipoDocumento { get; set; }

        [DataMember]
        public string sTipoElemento { get; set; }

        public int Moneda { get; set; }
        [DataMember]
        public Double Cantidad { get; set; }

        [Column(Name = "iIdTipoEstado")]
        [Column(Name = "IDESTADO")]
        [DataMember]
        public int IdTipoEstado { get; set; }

        [Column(Name = "TipoEstado")]
        [Column(Name = "DescripcionEstado")]
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public int IdExpedicionCustodia { get; set; }

        /* SEGUIMIENTO */
        //-------------------------------------------------------
        public DateTime FechaCustodia { get; set; }
        private string _fechaCustodiaJson = "0001-01-01";
        [DataMember]
        public string FechaCustodiaJSON
        {
            get
            {
                return _fechaCustodiaJson;
            }
            set
            {
                FechaCustodia = DateTime.Parse(value);
                _fechaCustodiaJson = value;
            }
        }
        //--------------------------------------------------------
        public DateTime FechaRecepcion { get; set; }
        private string _fechaRecepcionJson = "0001-01-01";
        [DataMember]
        public string FechaRecepcionJSON
        {
            get
            {
                return _fechaRecepcionJson;
            }
            set
            {
                FechaRecepcion = DateTime.Parse(value);
                _fechaRecepcionJson = value;
            }
        }
        //--------------------------------------------------------
        public DateTime FechaRuta { get; set; }
        private string _fechaRutaJson = "0001-01-01";
        [DataMember]
        public string FechaRutaJSON
        {
            get
            {
                return _fechaRutaJson;
            }
            set
            {
                FechaRuta = DateTime.Parse(value);
                _fechaRutaJson = value;
            }
        }
        //--------------------------------------------------------
        public DateTime FechaConfirmado { get; set; }
        private string _fechaConfirmadoJson = "0001-01-01";
        [DataMember]
        public string FechaConfirmadoJSON
        {
            get
            {
                return _fechaConfirmadoJson;
            }
            set
            {
                FechaConfirmado = DateTime.Parse(value);
                _fechaConfirmadoJson = value;
            }
        }
        //-------------------------------------------------------
        public DateTime FechaRetirado { get; set; }
        private string _fechaRetiradoJson = "0001-01-01";
        [DataMember]
        public string FechaRetiradoJSON
        {
            get
            {
                return _fechaRetiradoJson;
            }
            set
            {
                FechaRetirado = DateTime.Parse(value);
                _fechaRetiradoJson = value;
            }
        }
        //-------------------------------------------------------
        [DataMember]
        public String FechaEntrega { get; set; }

        [DataMember]
        public string strFechaCustodia
        {
            get
            { return FechaCustodia.Year < 2000 ? string.Empty : FechaCustodia.ToString(); }
            set { }
        }
        [DataMember]
        public int IdMensajeria { get; set; }

        [DataMember]
        public String EmpaqueS { get; set; }
        [DataMember]
        public String TipoDocS { get; set; }
        [DataMember]
        public String MonedaS { get; set; }
        [Column(Name = "Empaque")]
        public String EmpaqueBD { get; set; }

        [DataMember]
        public string Documento { get; set; }
        [DataMember]
        public string Procedencia { get; set; }
        [DataMember]
        public string Descripcion { get; set; }


        [Column(Name = "PalomarDe")]
        [DataMember]
        public string Palomar { get; set; }

        [DataMember]
        public int IdEntrega { get; set; }

        public string fechaIni { get; set; }
        public string fechaFin { get; set; }
        [DataMember]
        public string fechaTrack { get; set; }
        [DataMember]
        public string Origen { get; set; }

        [DataMember]
        public string Destino { get; set; }
        // public string CodigoExterno { get; set; }
        public DateTime RecibidoEl { get; set; }

        [Column(Name = "IMPRESO")]
        [DataMember]
        public int Impreso { get; set; }
        // public int GeoOrigenPadre { get; set; }
        [DataMember]
        public int IdPalomarPara { get; set; }

        [DataMember]
        public string sCodigoAgenciaDestino { get; set; }

        [DataMember]
        public string sAgenciaDestino { get; set; }

        [DataMember]
        public string sCodigoAgenciaOrigen { get; set; }
        [DataMember]
        public string sAgenciaOrigen { get; set; }
        [DataMember]
        public string PalomarPara { get; set; }

        public string EntregaFecha { get; set; }
        public string EntregaHora { get; set; }

        [DataMember]
        public string EntregaIdentificacion { get; set; }

        [DataMember]
        public string EntregaIdentificacionCifrada { get; set; }

        public string EntregaObservacion { get; set; }

        [DataMember(Name = "IdOficinaEntrega")]
        public int IdOficinaEntrega { get; set; }

        [DataMember]
        public string OficinaEntrega { get; set; }

        [Column(Name = "GrupoPalomarDestino")]
        public string seleccion { get; set; }

        [DataMember]
        public int indicadorFlag { get; set; }


        //Listado de Lotes
        [DataMember]
        public int Lote { get; set; }
        [Info(Length = 6, NoLeadingSpaces = true)]
        [DataMember]
        public string Guia { get; set; }
        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        [Column(Name = "FECHALOTE")]
        public string fechaLote { get; set; }

        [DataMember]
        [Column(Name = "CREADO")]
        public int Creados { get; set; }
        [DataMember]
        [Column(Name = "CUSTODIA")]
        public int EnCustodia { get; set; }
        [DataMember]
        [Column(Name = "RUTA")]
        public int EnRuta { get; set; }
        [DataMember]
        [Column(Name = "RECEPCIONADO")]
        public int Recepcionados { get; set; }
        [DataMember]
        [Column(Name = "CONFIRMADO")]
        public int Confirmados { get; set; }
        [DataMember]
        [Column(Name = "ELIMINADO")]
        public int Eliminados { get; set; }
        [DataMember]
        [Column(Name = "TOTAL")]
        public int Total { get; set; }
        [DataMember]
        public string Detalle { get; set; }
        [DataMember]
        public string RecepcionadoEn { get; set; }
        [DataMember]
        public int IdTipoEntrega { get; set; }
        public string EstadoEntrega { get; set; }

        [DataMember]
        public string TipoEntrega { get; set; }
        //entrega
        [DataMember]
        public int idTipoValidacion { get; set; }


        public DateTime fechaValidacion { get; set; }
        public string _fechaValidacionJson { get; set; }
        [DataMember(Name = "FechaValidacion")]
        public string FechaValidacionJSON
        {
            get
            {
                return _fechaValidacionJson;
            }
            set
            {
                fechaValidacion = DateTime.Parse(value);
                _fechaValidacionJson = value;
            }
        }

        public DateTime fechaResultado { get; set; }
        public string _fechaResultadoJson { get; set; }
        [DataMember(Name = "FechaResultado")]
        public string FechaResultadoJSON
        {
            get
            {
                return _fechaResultadoJson;
            }
            set
            {
                fechaResultado = DateTime.Parse(value);
                _fechaResultadoJson = value;
            }
        }

        public string PuntoEntrega { get; set; }
        [DataMember]
        public string Oficina { get; set; }
        [DataMember]
        public string Area { get; set; }

        [DataMember]
        public int IdTipoResultado { get; set; }

        [DataMember]
        public string sTipoDestinoEntregaPisos { get; set; }

        [DataMember]
        public string ObservacionEntrega { get; set; }

        [DataMember]
        public int IdTipoResultadoPisos { get; set; }

        public string TipoResultado
        {
            get
            {
                string res = "";
                if (IdTipoResultado == 72) { res = "MANUAL"; }
                if (IdTipoResultado == 73) { res = "PDA"; }
                return res;
            }
            set
            { }
        }
        [DataMember]
        public int idMotivoCambioEstado { get; set; }
        [DataMember]
        public string MotivoCambioEstado { get; set; }
        [DataMember]
        public string Comentario { get; set; }

        [Column(Name = "FechaTicket")]
        public DateTime CreadoEl { get; set; }

        [Column(Name = "sFac")]
        public string Resultado { get; set; }
        [DataMember]
        [Column(Name = "TieneFac")]
        public int IMasivo { get; set; }

        [DataMember]
        public int IdExpedicionResponsable { get; set; }

        [DataMember(Name = "ExpedicionCustodia")]
        public string DescripcionExpedicionCustodia { get; set; }

        [DataMember(Name = "ExpedicionRuta")]
        public string DescripcionExpedicionRuta { get; set; }


        [DataMember(Name = "ExpedicionResponsable")]
        public string DescripcionExpedicionResponsable { get; set; }

        [Column(Name = "Acuse")]
        [DataMember]
        public String GrupoPalomar { get; set; }

        //FechasJSON
        private string _fechaCreacion = "0001-01-01";

        [DataMember]
        public string FechaCreacion
        {
            get
            {
                return _fechaCreacion;
            }
            set
            {
                CreadoEl = DateTime.Parse(value);
                _fechaCreacion = value;
            }
        }

        [DataMember]
        public int IdGeoBandejaFisica { get; set; }


        [DataMember]
        public string GrupoOrigen { get; set; }

        [DataMember]
        public string GrupoDestino { get; set; }

        [Column(Name = "ExpedicionOrigen")]
        [DataMember(Name = "ExpedicionOrigen")]         //
        public string ExpedicionDe { get; set; }

        [Column(Name = "ExpedicionDestino")]
        [DataMember(Name = "ExpedicionDestino")] // 
        public string ExpedicionPara { get; set; }

        /*Agregando para los reportes 01/03/2016*/

        public String FechaCustodiaOrigenJson = "0001-01-01";
        [DataMember]
        public String FechaCustodiaOrigen
        {
            get
            {
                return FechaCustodiaOrigenJson;
            }
            set
            {
                FechaCustodiaOrigenDate = DateTime.Parse(value);
                this.FechaCustodiaOrigenJson = value;
            }
        }

        public DateTime FechaCustodiaOrigenDate { get; set; }

        public String FechaCustodiaDestinoJson = "0001-01-01";
        [DataMember]
        public String FechaCustodiaDestino
        {
            get
            {
                return FechaCustodiaDestinoJson;
            }
            set
            {
                FechaCustodiaDestinoDate = DateTime.Parse(value);
                this.FechaCustodiaDestinoJson = value;
            }
        }
        public DateTime FechaCustodiaDestinoDate { set; get; }

        public String FechaRutaExpedicionJson = "0001-01-01";
        [DataMember]
        public String FechaRutaExpedicion
        {
            get
            {
                return FechaRutaExpedicionJson;
            }
            set
            {
                FechaRutaExpedicionDate = DateTime.Parse(value);
                this.FechaRutaExpedicionJson = value;
            }
        }
        public DateTime FechaRutaExpedicionDate { set; get; }

        public String FechaRutaPisosJson = "0001-01-01";
        [DataMember]
        public String FechaRutaPisos
        {
            get
            {
                return "0001-01-01";
            }
            set
            {
                FechaRutaPisosDate = DateTime.Parse(value);
                this.FechaRutaPisosJson = value;
            }
        }
        public DateTime FechaRutaPisosDate { set; get; }

        public String FechaRutaAgenciaJson = "0001-01-01";
        [DataMember]
        public String FechaRutaAgencia
        {
            get
            {
                return FechaRutaAgenciaJson;
            }
            set
            {
                FechaRutaAgenciaDate = DateTime.Parse(value);
                this.FechaRutaAgenciaJson = value;
            }
        }

        public DateTime FechaRutaAgenciaDate { set; get; }

        public string RecibidoElJsonJson = "0001-01-01";
        [DataMember]
        public string RecibidoElJson
        {

            get
            {
                return RecibidoElJsonJson;
            }
            set
            {
                RecibidoEl = DateTime.Parse(value);
                this.RecibidoElJsonJson = value;
            }
        }

        [DataMember]
        public string Prefijo { get; set; }
        [DataMember]
        public string AreaOrigen { get; set; }
        [DataMember]
        public string AreaDestino { get; set; }
        [DataMember]
        public string sDestino { get; set; }


        [DataMember]
        public DateTime dFechaCustodiaOrigen { get; set; }
        [DataMember]
        public DateTime dFechaCustodiaDestino { get; set; }
        [DataMember]
        public DateTime dFechaRutaExpedicion { get; set; }
        [DataMember]
        public DateTime dFechaRutaPisos { get; set; }
        [DataMember]
        public DateTime dFechaRutaAgencia { get; set; }
        [DataMember]
        public DateTime dFechaRecibido { get; set; }
        [DataMember]
        public DateTime dFechaConfirmado { get; set; }
        [DataMember]
        public DateTime dFechaRetiro { get; set; }


        public Objeto()
        {
            seleccion = "NO";
        }
        public List<Objeto> rBuscaTexto(String texto)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@TEXTO", texto));
            return oSql.TablaParametro<Objeto>("EXI_R_CASILLA", oP);
        }
        //2022
        public int RegistrarCorrespondenciaMesaDePartes(string upn)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_TIPOOBJETO", IdTipoDocumento));
            oP.Add(new SqlParameter("@DE", IdCasillaDe));
            oP.Add(new SqlParameter("@PARA", IdCasillaPara));
            oP.Add(new SqlParameter("@ASUNTO", Asunto));
            oP.Add(new SqlParameter("@MENSAJE", Mensaje));
            oP.Add(new SqlParameter("@UPN", upn));
            oP.Add(new SqlParameter("@DETALLE", ListaXML));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MESAPARTES_C_CREARDOCUMENTO", oP));
        }
        //2022
        public Objeto RegistrarCorrespondencia(string upn)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("UPN", upn));
            oP.Add(new SqlParameter("@DE", IdCasillaDe));
            oP.Add(new SqlParameter("@PARA", IdCasillaPara));
            oP.Add(new SqlParameter("@INDICADOR", idTipoValidacion));
            oP.Add(new SqlParameter("@DETALLE", ListaXML));
            return oSql.TablaTop<Objeto>("SIMIH_WEB_C_REGISTRARCORRESPONDENCIA", oP);
        }

        public int iObjectoEXTERNA()
        {

            return 0;
        }

        public Objeto rObtenerUltimoKey()
        {
            sql oSql = new sql();
            return oSql.TablaTop<Objeto>("EXI_R_OBJETO_KEY");
        }
        //2022
        public string ObtenerCabecera(int IdObjeto)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", IdObjeto));
            return oSql.TablaParametroJSON("SIMIH_R_OBJETO_CABECERA", oP);
        }

        public List<Objeto> rObtenerDetalle(Interna.Entity.Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJECTO", oO.ID));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJECTO_DETALLE", oP);
        }

        public List<ObjetoDetalle> rObtenerDetalle(Interna.Entity.ObjetoDetalle oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", oO.ID));
            return oSql.TablaParametro<ObjetoDetalle>("EXI_R_OBJETO_DETALLE", oP);
        }

        public List<Objeto> rObtenerRecibidos(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@USUARIO_CASILLA", id));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_RECIBIDOS", oP);
        }
        /**************************/
        public string rObtenerRecibidosJSON(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@USUARIO_CASILLA", id));
            return oSql.TablaParametroJSON("EXI_R_OBJETO_RECIBIDOS", oP);
        }



        public List<Objeto> rObtenerTracking(Interna.Entity.Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", oO.ID));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_TRACKING", oP);
        }

        public List<Objeto> rObtenerDocumentosPorEnviar(Interna.Entity.Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdExpedicion", oO.IdExpedicionCustodia));
            oP.Add(new SqlParameter("@iIdTipoEntrega", oO.IdTipoDocumento));
            oP.Add(new SqlParameter("@iIdGrupoPalomar", oO.IdPadre));
            oP.Add(new SqlParameter("@iIdPalomar", oO.ID));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_DOCUMENTOSPORENVIAR", oP);
        }

        /* POR MORIR */
        public List<Objeto> rObtenerDocumentosTodos(Interna.Entity.Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idGeoExpedicion", oO.IdPadre));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_DOCUMENTOSTODOS", oP);
        }

        public List<Objeto> CorrespondenciaPorCustodiar(Interna.Entity.Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idGeoExpedicion", oO.IdPadre));
            oP.Add(new SqlParameter("@RECORDINDEX", oO.PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", oO.PageWidth));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_POR_CUSTODIAR", oP);
        }

        public int CorrespondenciaPorCustodiarCONTAR(Interna.Entity.Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idGeoExpedicion", oO.IdPadre));
            return (int)oSql.Escalar("EXI_R_OBJETO_POR_CUSTODIAR_CONTAR", oP);
        }

        public List<Objeto> rObtenerDocumentosPorEntrega(Interna.Entity.Entrega oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdEntrega", oO.ID));
            return oSql.TablaParametro<Objeto>("EXI_R_ENTREGA_OBJETO", oP);
        }

        public List<Objeto> rDocumentosPorEntregarPagina(Interna.Entity.Entrega oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdEntrega", oO.ID));
            oP.Add(new SqlParameter("@RECORDINDEX", oO.PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", oO.PageWidth));
            return oSql.TablaParametro<Objeto>("EXI_R_ENTREGA_OBJETO_PAGINA", oP);
        }
        public int DocumentosPorEntregarCONTAR(Interna.Entity.Entrega oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdEntrega", oO.ID));
            return (int)oSql.Escalar("EXI_R_ENTREGA_OBJETO_CONTAR", oP);
        }

        public List<Objeto> rObjetoPalomar(int idExpedicion, int idGrupoPalomar)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@GRUPO", idGrupoPalomar));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_PALOMAR_GRUPO", oP);
        }

        public List<Objeto> rObjetoCustodia(int idExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", idExpedicion));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_CUSTODIA", oP);
        }

        public int uObjecto_Recibir()
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", ListaXML));
            oP.Add(new SqlParameter("@DE", IdCasillaDe));
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuario));
            return (new sql()).Exec("EXI_U_OBJETO_RECIBIDO", oP);
        }

        public int uObjeto_Entrega()
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            oP.Add(new SqlParameter("@ID_USUARIO", IdUsuario));
            oP.Add(new SqlParameter("@FECHAENTREGA", fechaTrack));
            oP.Add(new SqlParameter("@ENTREGADNI", Documento));
            oP.Add(new SqlParameter("@ENTREGAOBSERVACION", Observacion));
            oP.Add(new SqlParameter("@IDTIPORESULTADO", IdTipoResultado));
            return (new sql()).Exec("EXI_U_OBJETO_ENTREGA", oP);
        }

        public int uObjeto_NoEntrega()
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            oP.Add(new SqlParameter("@ID_USUARIO", IdUsuario));

            return (new sql()).Exec("EXI_U_OBJETO_NOENTREGA", oP);
        }

        public List<Objeto> rObjetosActivos_WEB_1(Objeto objObjeto)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", objObjeto.ID));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_ACTIVOS", oP);
        }


        //2022 por eliminar
        public string ActivosSalida(int idCasilla)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            return oSql.TablaParametroJSON("SIMIH_WEB_R_OBJETO_ACTIVOS_SALIDA", oP);
        }
        //2023
        public string CorrespondenciaActivaBandejaSalida(string upn)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@UPN", upn));
            return oSql.TablaParametroJSON("SIMIH_WEB_CORRESPONDENCIA_ACTIVA_BANDEJA_SALIDA", oP);
        }

        public List<Objeto> rObjetosActivos_WEB_2(Objeto objObjeto)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", objObjeto.ID));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_ACTIVOS2", oP);
        }

        //2022
        public string ActivosIngresos(int idCasilla)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            return oSql.TablaParametroJSON("SIMIH_WEB_R_OBJETOS_ACTIVOS_INGRESO", oP);
        }

        //2023
        public string CorrespondenciaActivaBandejaEntrada(string upn)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@UPN", upn));
            return oSql.TablaParametroJSON("SIMIH_WEB_CORRESPONDENCIA_ACTIVA_BANDEJA_ENTRADA", oP);
        }

        public List<ObjetoDetalle> rObjetosActivos(int objeto)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", objeto));
            return oSql.TablaParametro<ObjetoDetalle>("EXI_R_OBJETO_DETALLE3", oP);
        }

        public List<Objeto> rObjetosActivos2(Interna.Entity.Objeto oB)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", oB.ID));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_ACTIVOS2", oP);
        }

        public List<Objeto> rObjetosHistorico(Interna.Entity.Objeto oB)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", oB.ID));
            oP.Add(new SqlParameter("@FECHAINI", oB.fechaIni));
            oP.Add(new SqlParameter("@FECHAFIN", oB.fechaFin));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_HISTORICOS", oP);
        }

        /****************************************************************/
        //2022 por eliminar
        public string ObjetosHistoricoJSON(int idCasilla, string fechaIni, string fechaFin)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            oP.Add(new SqlParameter("@FECHAINI", fechaIni));
            oP.Add(new SqlParameter("@FECHAFIN", fechaFin));
            return oSql.TablaParametroJSON("SIMIH_WEB_R_OBJETO_HISTORICOS", oP);
        }

        //2023
        public string CorrespondenciaHistoricaBandejaEntrada(string upn, string fechaDesde, string fechaHasta)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@UPN", upn));
            oP.Add(new SqlParameter("@FECHA_DESDE", fechaDesde));
            oP.Add(new SqlParameter("@FECHA_HASTA", fechaHasta));
            return oSql.TablaParametroJSON("SIMIH_WEB_CORRESPONDENCIA_HISTORICA_BANDEJA_ENTRADA", oP);
        }

        public List<Objeto> rObjetosHistoricoSalidas(Interna.Entity.Objeto oB)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", oB.ID));
            oP.Add(new SqlParameter("@FECHAINI", oB.fechaIni));
            oP.Add(new SqlParameter("@FECHAFIN", oB.fechaFin));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_HISTORICOS_SALIDAS", oP);
        }

        /**************************************************************************/
        //2022 por eliminar
        public string ObjetosHistoricoSalidasJSON(int idCasilla, string fechaIni, string fechaFin)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            oP.Add(new SqlParameter("@FECHAINI", fechaIni));
            oP.Add(new SqlParameter("@FECHAFIN", fechaFin));
            return oSql.TablaParametroJSON("SIMIH_R_OBJETO_HISTORICOS_SALIDAS", oP);
        }

        //2023
        public string CorrespondenciaHistoricaBandejaSalida(string upn, string fechaDesde, string fechaHasta)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@UPN", upn));
            oP.Add(new SqlParameter("@FECHA_DESDE", fechaDesde));
            oP.Add(new SqlParameter("@FECHA_HASTA", fechaHasta));
            return oSql.TablaParametroJSON("SIMIH_WEB_CORRESPONDENCIA_HISTORICA_BANDEJA_SALIDA", oP);
        }

        public List<Objeto> rObjetosHistoricoRetirado(Interna.Entity.Objeto oB)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", oB.ID));
            oP.Add(new SqlParameter("@FECHAINI", oB.fechaIni));
            oP.Add(new SqlParameter("@FECHAFIN", oB.fechaFin));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_HISTORICOS_RETIRADOS", oP);
        }

        /****************************************************************************/

        public string rObjetosINDICADORESJSON(int idCasilla, int tipo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCasilla", idCasilla));
            oP.Add(new SqlParameter("@TIPO", tipo));
            return oSql.TablaParametroJSON("WEXI_R_ObtenerINDICADORES", oP);
        }
        //2022 por eliminar
        public string ObjetosHistoricoRetiradoJSON(int idCasilla, string fechaIni, string fechaFin)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            oP.Add(new SqlParameter("@FECHAINI", fechaIni));
            oP.Add(new SqlParameter("@FECHAFIN", fechaFin));
            return oSql.TablaParametroJSON("SIMIH_WEB_R_OBJETO_HISTORICOS_RETIRADOS", oP);
        }

        //2023
        public string CorrespondenciaHistoricaRetiradosBandejaEntrada(string upn, string fechaDesde, string fechaHasta)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@UPN", upn));
            oP.Add(new SqlParameter("@FECHA_DESDE", fechaDesde));
            oP.Add(new SqlParameter("@FECHA_HASTA", fechaHasta));
            return oSql.TablaParametroJSON("SIMIH_WEB_CORRESPONDENCIA_HISTORICA_RETIRADOS_BANDEJA_ENTRADA", oP);
        }

        //2022
        public string rObjetosDOCUMENTOSJSON(int idCasilla)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@USUARIO_CASILLA", idCasilla));
            return oSql.TablaParametroJSON("SIMIH_WEB_R_OBJETO_RECIBIDOS", oP);
        }

        //2023
        public string CorrespondenciaPorConfirmar(string upn)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@UPN", upn));
            return oSql.TablaParametroJSON("SIMIH_WEB_CORRESPONDENCIA_POR_CONFIRMAR", oP);
        }

        /*Obtener Objeto*/
        public Objeto rObjetoCustodia(string autogenerado)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@AUTOGENERADO", autogenerado));
            return oSql.TablaTop<Objeto>("EXI_R_OBJETO_RECEPCION", oP);
        }

        public int uObjetoCustodia(int idObjeto, int idOperario, int idExpedicion, int idMensajeria)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", idObjeto));
            oP.Add(new SqlParameter("@ID_EXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@ID_USUARIO", idOperario));
            oP.Add(new SqlParameter("@ID_MENSAJERIA", idMensajeria));
            return (new sql()).Exec("EXI_U_OBJETO_RECEPCION", oP);
        }

        public List<Objeto> rObjetoExpedicion(Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", oO.IdExpedicionCustodia));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_EXPEDICION", oP);
        }
        public String rObjetoExpedicion_prueba(Objeto oO, int num)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", oO.IdExpedicionCustodia));
            oP.Add(new SqlParameter("@Fecha", oO.FechaCustodia.ToShortDateString()));
            oP.Add(new SqlParameter("@Tipo", num));
            return oSql.TablaParametroJSON("PEXI_R_OBJETO_CUSTODIA", oP);
        }
        //2022
        public String rObjetoExpedicion_prueba1(int idExpedicionCustodia, DateTime fechaDesde, DateTime fechaHasta, int num)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", idExpedicionCustodia));
            oP.Add(new SqlParameter("@FechaDesde", fechaDesde));
            oP.Add(new SqlParameter("@FechaHasta", fechaHasta));
            oP.Add(new SqlParameter("@Tipo", num));
            return oSql.TablaParametroJSON("SIMIH_DOCUMENTOSCUSTODIADOS_R_CONSULTAFECHAS", oP);

        }

        public List<Objeto> rObjeto_Cuadro_Mando_Detalle(int opc, int idCasilla, int dias)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@OPC", opc));
            oP.Add(new SqlParameter("@IDUSUARIO_CASILLA", idCasilla));
            oP.Add(new SqlParameter("@DIAS", dias));
            return oSql.TablaParametro<Objeto>("EXI_R_CUADRO_DE_MANDO_DETALLE", oP);
        }

        public int cObjeto_Externo()
        {
            //int iKey = 0;
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();


            oP.Add(new SqlParameter("@TIPOOBJETO", IdTipoDocumento));
            oP.Add(new SqlParameter("@USUARIOCREADOR", IdUsuario));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicionCustodia));
            oP.Add(new SqlParameter("@LISTAOBJETO", Documento));

            //iKey = Convert.ToInt32(oSql.Escalar("EXI_C_OBJETO_EXTERNO", oP));
            return Convert.ToInt32((new sql()).Escalar("EXI_C_OBJETOEXTERNO", oP));
            //return iKey;
        }

        public int uObjetoImpreso()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();


            oP.Add(new SqlParameter("@ID", ID));
            oP.Add(new SqlParameter("@IMPRESO", Impreso));

            //iKey = Convert.ToInt32(oSql.Escalar("EXI_C_OBJETO_EXTERNO", oP));
            return Convert.ToInt32((new sql()).Escalar("EXI_U_OBJETO_IMPRESO", oP));
        }

        public Objeto uObjetoImpresoXML()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@OBJETO", ListaXML));
            return oSql.TablaTop<Objeto>("EXI_U_OBJETO_IMPRESO_XML", oP);
        }
        //2022
        public string uObjetoImpresoXML1(Usuario us)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@OBJETO", ListaXML));
            oP.Add(new SqlParameter("@IDEXPEDICION", us.IdExpedicion));
            oP.Add(new SqlParameter("@IDUSUARIO", us.ID));
            oP.Add(new SqlParameter("@IDGEOCASILLA", us.idGeoCasilla));
            oP.Add(new SqlParameter("@IDCASILLA", us.idCasilla));
            return oSql.TablaParametroJSON("SIMIH_IMPRESIONCORRESPONDENCIA_U_IMPREMIRCORRESPODENCIAS", oP);
        }

        public int uObjecto_Recibir_Fac(Interna.Entity.Objeto oO)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            if (ListaXML == null) ListaXML = "";
            oP.Add(new SqlParameter("@IDOBJETO", oO.ListaXML));
            oP.Add(new SqlParameter("@DE", oO.IdCasillaDe));
            oP.Add(new SqlParameter("@IDUSUARIO", oO.IdUsuario));
            return (new sql()).Exec("EXI_U_OBJETO_RECIBIDO_FAC", oP);
        }

        /*********************recibe un JSON*************************/
        //2023
        public int uObjecto_Recibir_Fac_JSON(String cadena, int de, int idUsuario, int idEntrega)
        {
            sql oSql = new sql();

            //List<SqlParameter> uParameter = new List<SqlParameter>();
            //uParameter.Add(new SqlParameter("@IDUSUARIO", idUsuario));

            //Usuario usuario = oSql.TablaTop<Usuario>("PC_USUARIO_R_NOMBRE_POR_ID", uParameter);

            //Encryption.Encrypt encrypt = new Encryption.Encrypt();
            //string nombreUsuario = encrypt.Desencriptar(usuario.sCodigo);

            List<SqlParameter> oP = new List<SqlParameter>();
            if (cadena == null) cadena = "";
            oP.Add(new SqlParameter("@LISTA_OBJETOS", cadena));
            oP.Add(new SqlParameter("@iIdCasilla", de));
            oP.Add(new SqlParameter("@iIdUsuario", idUsuario));
            oP.Add(new SqlParameter("@iIdEntrega", idEntrega));
            //oP.Add(new SqlParameter("@Usuario", nombreUsuario));
            return Convert.ToInt32(oSql.Escalar("SIMIH_WEB_JOS_U_RECIBIR_DOCUMENTOS", oP));
        }

        public int uObjecto_Recibir_Fac_Creados(Interna.Entity.Objeto oO)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            if (ListaXML == null) ListaXML = "";
            oP.Add(new SqlParameter("@IDOBJETO", oO.ListaXML));
            oP.Add(new SqlParameter("@DE", oO.IdCasillaDe));
            oP.Add(new SqlParameter("@IDUSUARIO", oO.IdUsuario));
            return (new sql()).Exec("EXI_U_OBJETO_RECIBIDO_FAC_CREADOS", oP);
        }

        public int uObjecto_Recibir_Fac_Creados_JSON(String cadena, int de, int idUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            if (cadena == null) cadena = "";
            oP.Add(new SqlParameter("@IDOBJETO", cadena));
            oP.Add(new SqlParameter("@DE", de));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            return (new sql()).Exec("WEXI_U_OBJETO_RECIBIDO_FAC_CREADOS", oP);
        }

        public List<Objeto> rObjetoExpedicionImpreso(Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", oO.IdExpedicionCustodia));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_EXPEDICION_IMPRESO", oP);
        }

        public int uObjecto_Recibir_Fac_Observados(Interna.Entity.Objeto oO)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            if (ListaXML == null) ListaXML = "";
            oP.Add(new SqlParameter("@IDOBJETO", oO.ListaXML));
            oP.Add(new SqlParameter("@DE", oO.IdCasillaDe));
            oP.Add(new SqlParameter("@IDUSUARIO", oO.IdUsuario));
            return (new sql()).Exec("EXI_U_OBJETO_RECIBIDO_FAC_OBSERVADOS", oP);
        }

        public int uObjecto_Recibir_Fac_PorError(Interna.Entity.Objeto oO)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            if (ListaXML == null) ListaXML = "";
            oP.Add(new SqlParameter("@IDOBJETO", oO.ListaXML));
            oP.Add(new SqlParameter("@DE", oO.IdCasillaDe));
            oP.Add(new SqlParameter("@IDUSUARIO", oO.IdUsuario));
            return (new sql()).Exec("EXI_U_OBJETO_RECIBIDO_FAC_POR_ERROR", oP);
        }

        public List<Objeto> rListaObjeto(int IdTipoEstado, int IdTipoObjeto, string TextoCasilla, string Autogenerado, DateTime FechaInicio, DateTime FechaFin, int TipoEnrutamiento, int IdExpedicion, int PageRecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdTipoEstado", IdTipoEstado));
            oP.Add(new SqlParameter("@IdTipoObjeto", IdTipoObjeto));
            oP.Add(new SqlParameter("@TextoCasilla", TextoCasilla));
            oP.Add(new SqlParameter("@Autogenerado", Autogenerado));
            oP.Add(new SqlParameter("@FechaInicio", FechaInicio.Year + "-" + FechaInicio.Month + "-" + FechaInicio.Day));
            oP.Add(new SqlParameter("@FechaFin", FechaFin.Year + "-" + FechaFin.Month + "-" + FechaFin.Day));
            oP.Add(new SqlParameter("@TIPOENRUTAMIENTO", TipoEnrutamiento));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));

            //return oSql.TablaParametro<Objeto>("EXI_R_OBJETO", oP);

            DataTable dt = oSql.TablaParametro("EXI_R_OBJETO", oP);

            List<Objeto> lObj = new List<Objeto>();

            foreach (DataRow r in dt.Rows)
            {
                Objeto o = new Objeto();
                o.ID = (int)r["ID"];

                o.Autogenerado = r["Autogenerado"].ToString();
                if (r["IdTipoObjeto"] != DBNull.Value) o.IdTipoDocumento = int.Parse(r["IdTipoObjeto"].ToString());
                if (r["IdCasillaDe"] != DBNull.Value) o.IdCasillaDe = int.Parse(r["IdCasillaDe"].ToString());
                if (r["IdTipoEstado"] != DBNull.Value) o.IdTipoEstado = int.Parse(r["IdTipoEstado"].ToString());
                o.TipoDocumento = r["TipoObjeto"].ToString();
                o.CasillaDe = r["CasillaDe"].ToString();
                o.CasillaPara = r["CasillaPara"].ToString();
                o.Estado = r["TipoEstado"].ToString();
                o.IdEntrega = int.Parse(r["IdEntrega"].ToString());
                if (r["IdExpedicionCustodia"] != DBNull.Value) o.IdExpedicionCustodia = int.Parse(r["IdExpedicionCustodia"].ToString());
                o.Origen = r["Origen"].ToString();
                o.Destino = r["Destino"].ToString();
                if (r["Lote"] != DBNull.Value) o.Lote = int.Parse(r["Lote"].ToString());
                if (r["indicadorFlag"] != DBNull.Value) o.indicadorFlag = int.Parse(r["indicadorFlag"].ToString());
                if (r["Impreso"] != DBNull.Value) o.Impreso = int.Parse(r["Impreso"].ToString());
                o.CreadoEl = DateTime.Parse(r["FechaTicket"].ToString());
                if (r["FechaCustodia"] != DBNull.Value) o.FechaCustodia = DateTime.Parse(r["FechaCustodia"].ToString());
                if (r["FechaRuta"] != DBNull.Value) o.FechaRuta = DateTime.Parse(r["FechaRuta"].ToString());
                if (r["FechaRecepcion"] != DBNull.Value) o.FechaRecepcion = DateTime.Parse(r["FechaRecepcion"].ToString());
                if (r["FechaConfirmado"] != DBNull.Value) o.FechaConfirmado = DateTime.Parse(r["FechaConfirmado"].ToString());
                if (r["FechaRetirado"] != DBNull.Value) o.FechaRetirado = DateTime.Parse(r["FechaRetirado"].ToString());
                o.Resultado = r["sFac"].ToString();
                o.Area = r["Area"].ToString();
                o.GrupoPalomar = r["GrupoPalomar"].ToString();
                o.seleccion = r["GrupoPalomarDestino"].ToString();
                o.EmpaqueS = r["EmpaqueS"].ToString();
                o.TipoDocS = r["TipoDocS"].ToString();
                o.MonedaS = r["MonedaS"].ToString();
                if (r["Cantidad"] != DBNull.Value) o.Cantidad = Double.Parse(r["Cantidad"].ToString());
                o.Observacion = r["Observacion"].ToString();
                o.Procedencia = r["Procedencia"].ToString();
                if (r["IdOficinaEntrega"] != DBNull.Value) o.IdOficinaEntrega = int.Parse(r["IdOficinaEntrega"].ToString());
                o.OficinaEntrega = r["OficinaEntrega"].ToString();
                o.EntregaIdentificacion = r["EntregaIdentificacion"].ToString();
                o.EntregaObservacion = r["EntregaObservacion"].ToString();
                if (r["IMasivo"] != DBNull.Value) o.IMasivo = int.Parse(r["IMasivo"].ToString());
                o.Palomar = r["Palomar"].ToString();
                o.countRows = int.Parse(r["countRows"].ToString());

                lObj.Add(o);
            }

            return lObj;

        }


        /*Metodo Prueba Benji Villarreal*/
        public string rListaObjetoJson(int IdTipoEstado, int IdTipoObjeto, string TextoCasilla, string Autogenerado, DateTime FechaInicio, DateTime FechaFin, int TipoEnrutamiento, int IdExpedicion, int PageRecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdTipoEstado", IdTipoEstado));
            oP.Add(new SqlParameter("@IdTipoObjeto", IdTipoObjeto));
            oP.Add(new SqlParameter("@TextoCasilla", TextoCasilla));
            oP.Add(new SqlParameter("@Autogenerado", Autogenerado));
            oP.Add(new SqlParameter("@FechaInicio", FechaInicio.Year + "-" + FechaInicio.Month + "-" + FechaInicio.Day));
            oP.Add(new SqlParameter("@FechaFin", FechaFin.Year + "-" + FechaFin.Month + "-" + FechaFin.Day));
            oP.Add(new SqlParameter("@TIPOENRUTAMIENTO", TipoEnrutamiento));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));

            //return oSql.TablaParametro<Objeto>("EXI_R_OBJETO", oP);
            return oSql.TablaParametroJSON("EXI_R_OBJETO_PRUEBA_BENJI", oP);

        }

        public int GetListaObjetoCONTAR(int IdTipoEstado, int IdTipoObjeto, String TextoCasilla,
            String Autogenerado, String FechaInicio, String FechaFin, int tipoEnrutamiento, int IdExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdTipoEstado", IdTipoEstado));
            oP.Add(new SqlParameter("@IdTipoObjeto", IdTipoObjeto));
            oP.Add(new SqlParameter("@TextoCasilla", TextoCasilla));
            oP.Add(new SqlParameter("@Autogenerado", Autogenerado));
            oP.Add(new SqlParameter("@FechaInicio", FechaInicio));
            oP.Add(new SqlParameter("@FechaFin", FechaFin));
            oP.Add(new SqlParameter("@TIPOENRUTAMIENTO", tipoEnrutamiento));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            return (int)oSql.Escalar("EXI_R_OBJETO_CONTAR_2", oP);
        }

        public int uObjecto_Eliminar(int id, int estado, int acceso, int idUsuario)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", id));
            oP.Add(new SqlParameter("@TIPOACCESO", acceso));
            oP.Add(new SqlParameter("@ESTADO", estado));
            return Convert.ToInt32((new sql()).Escalar("EXI_D_CORRESPONDENCIA", oP));

        }

        public List<Objeto> rListaLotes()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            return oSql.Tabla<Objeto>("EXI_R_LOTE");
        }

        public List<Objeto> Lotes(int PageRecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));
            return oSql.TablaParametro<Objeto>("EXI_R_LOTES", oP);
        }

        public int LotesCONTAR()
        {
            sql oSql = new sql();
            return (int)oSql.Escalar("EXI_R_LOTES_CONTAR");
        }

        //POR DESCARTAR
        public List<Objeto> rListaDetalleLote(Interna.Entity.Objeto objO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDLOTE", objO.Lote));
            return oSql.TablaParametro<Objeto>("EXI_R_DETALLE_LOTE", oP);
        }
        //--

        public List<Objeto> DetalleLotes(Interna.Entity.Objeto objO, int PageRecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDLOTE", objO.Lote));
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));
            return oSql.TablaParametro<Objeto>("EXI_R_DETALLE_LOTES", oP);
        }


        public int DetalleLotesCONTAR(Interna.Entity.Objeto objO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDLOTE", objO.Lote));
            return (int)oSql.Escalar("EXI_R_DETALLE_LOTES_CONTAR", oP);
        }

        //Publicacion
        //POR DESCARTAR
        public List<Objeto> rListadoPorPublicar(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDTIPOPUBLICACION", id));
            return oSql.TablaParametro<Objeto>("EXI_R_LISTAXPUBLICAR", oP);
        }
        //---
        public List<Objeto> CorrespondenciaPorPublicar(int id, int PageRecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDTIPOPUBLICACION", id));
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));
            return oSql.TablaParametro<Objeto>("EXI_R_CORRESPONDENCIA_POR_PUBLICAR", oP);
        }

        public int CorrespondenciaPorPublicarCONTAR(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDTIPOPUBLICACION", id));
            return (int)oSql.Escalar("EXI_R_CORRESPONDENCIA_POR_PUBLICAR_CONTAR", oP);
        }

        public int CargarDatosCoordinacion()
        {
            return 0;

            /*
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuario));
            oP.Add(new SqlParameter("@TIPO_PUBLICACION", tipoPublicacion));
            oP.Add(new SqlParameter("@FECHA_SALIDA", fechaPublicacion));
            oP.Add(new SqlParameter("@EQUIPO_COORDINADOR", IdEquipoCoordinador));

            Detalle = Detalle.Trim().ToUpper();

            oP.Add(new SqlParameter("@DETALLE", Detalle));

            return Convert.ToInt32((new sql()).Escalar("EXI_C_OBJETO_COORDINACION", oP));
             * */
        }

        public int QuitarDatosCoordinacion()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            Detalle = Detalle.Trim().ToUpper();

            oP.Add(new SqlParameter("@DETALLE", Detalle));

            return Convert.ToInt32((new sql()).Escalar("EXI_D_OBJETO_COORDINACION", oP));
        }

        //POR DESCARTAR
        public List<Objeto> rListadoPublicados(int ID)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@TIPOPUBLICACION", ID));
            return oSql.TablaParametro<Objeto>("EXI_R_LISTADEPUBLICADOS", oP);
        }
        //--

        public List<Objeto> CorrespondenciaPublicada(int ID, int PageRecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@TIPOPUBLICACION", ID));
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));
            return oSql.TablaParametro<Objeto>("EXI_R_CORRESPONDENCIA_PUBLICADOS", oP);
        }

        public int CorrespondenciaPublicadaCONTAR(int ID)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@TIPOPUBLICACION", ID));
            return (int)oSql.Escalar("EXI_R_CORRESPONDENCIA_PUBLICADOS_CONTAR", oP);
        }

        //Coordinacion
        public List<Objeto> rListadoCoordinacionEnFrio(Interna.Entity.Objeto objO)
        {
            return null;
            /*
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDTIPOPUBLICACION", objO.tipoPublicacion));
            return oSql.TablaParametro<Objeto>("EXI_R_COORDINACION", oP);
             * */
        }
        //

        //Descarga virtual
        public Objeto rDatosCoordinacion(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", id));
            return oSql.TablaTop<Objeto>("EXI_R_DESCARGA_VIRTUAL", oP);
        }

        public int uCoordinacion()
        {
            return 0;
            /*
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IDOBJETO", ID));
            oP.Add(new SqlParameter("@IDESTADO", EstadoCoordinacion));
            oP.Add(new SqlParameter("@OBSERVACION", Observacion));
            oP.Add(new SqlParameter("@MOTIVO", MotivoRezago));
            oP.Add(new SqlParameter("@RECEPTOR", Receptor));
            oP.Add(new SqlParameter("@VINCULO", Vinculo));
            oP.Add(new SqlParameter("@TIPOIDC", TipoIdc));
            oP.Add(new SqlParameter("@IDC", Idc));
            oP.Add(new SqlParameter("@FECHARESULTADO", FechaResultado.ToString("yyyy/MM/dd")));
            oP.Add(new SqlParameter("@HORARESULTADO", HoraResultado.ToString("HH:mm:ss")));
            //iKey = Convert.ToInt32(oSql.Escalar("EXI_C_OBJETO_EXTERNO", oP));
            return Convert.ToInt32((new sql()).Escalar("EXI_U_COORDINACION", oP));
            //return iKey;
             * */
        }
        //

        //Detalle Autogenerado
        public Objeto rDatosAutogenerado(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", id));
            return oSql.TablaTop<Objeto>("EXI_R_AUTOGENERADO", oP);
        }

        public Objeto rObjecto_Validar(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", id));
            return oSql.TablaTop<Objeto>("EXI_R_OBJETO_DOCUMENTOS_EVALUAR", oP);
        }

        //Asignar ruta
        public int uDatosAsignarRuta(string autogenerado, int id)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@AUTOGENERADO", autogenerado));
            oP.Add(new SqlParameter("@RUTA", id));
            return Convert.ToInt32((new sql()).Escalar("EXI_U_RUTA_TARJETA", oP));
        }

        public List<Objeto> rListadoRutasAsignadas()
        {
            sql oSql = new sql();
            return oSql.Tabla<Objeto>("EXI_R_RUTA_TARJETA");
        }

        public List<Objeto> rListaVisitasRegulares(int ruta)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@RUTA", ruta));
            return oSql.TablaParametro<Objeto>("EXI_R_ENTREGA_VISITAS_REGULAR", oP);
        }

        //Entrega tarjetas visitas
        public List<Objeto> rRutasAsignadas()
        {
            sql oSql = new sql();
            return oSql.Tabla<Objeto>("EXI_R_LISTA_RUTAS_ASIGNADAS");
        }

        public Objeto rVisitaTop(string autogenerado)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@AUTOGENERADO", autogenerado));
            return oSql.TablaTop<Objeto>("EXI_R_ENTREGA_VISITAS_TOP", oP);
        }

        //RESULTADO FISICO  OBJETO
        public int uDescargoFisico()
        {
            return 0;
            /*
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            string miFecha = FechaResultado.ToString("yyyy/MM/dd");
            string miHora = HoraResultado.ToString("HH:mm:ss");

            string obs = "";
            if (Observacion == null) obs = "";
            else obs = Observacion;

            oP.Add(new SqlParameter("@IDOBJETO", ID));
            oP.Add(new SqlParameter("@IDESTADO", EstadoCoordinacion));
            oP.Add(new SqlParameter("@OBSERVACION", obs));
            oP.Add(new SqlParameter("@MOTIVO", MotivoRezago));
            oP.Add(new SqlParameter("@RECEPTOR", Receptor));
            oP.Add(new SqlParameter("@VINCULO", Vinculo));
            oP.Add(new SqlParameter("@TIPOIDC", TipoIdc));
            oP.Add(new SqlParameter("@IDC", Idc));
            oP.Add(new SqlParameter("@FECHARESULTADO", miFecha));
            oP.Add(new SqlParameter("@HORARESULTADO", miHora));
            oP.Add(new SqlParameter("@IDUSUARIO", idOperario));
            oP.Add(new SqlParameter("@ID_EXPEDICION", IdExpedicionCustodia));
            //iKey = Convert.ToInt32(oSql.Escalar("EXI_C_OBJETO_EXTERNO", oP));
            return Convert.ToInt32((new sql()).Escalar("EXI_U_RESULTADO_FISICO", oP));
            //return iKey;
            //cambio
             * */
        }
        public List<Objeto> rEstados()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDESTADO", IdTipoEstado));
            return oSql.TablaParametro<Objeto>("EXI_R_ESTADOS", oP);
        }
        public List<Objeto> rMotivos()
        {
            sql oSql = new sql();
            return oSql.Tabla<Objeto>("EXI_R_MOTIVO_CAMBIO");
        }

        public int uModificarEstado()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IDOBJETO", ID));
            oP.Add(new SqlParameter("@ESTADOXENVIADO", IdTipoEstado));
            oP.Add(new SqlParameter("@MOTIVOCAMBIO", idMotivoCambioEstado));
            oP.Add(new SqlParameter("@ID_USUARIO", IdUsuario));
            oP.Add(new SqlParameter("@COMENTARIO", Comentario));
            return Convert.ToInt32((new sql()).Escalar("EXI_U_ESTADOS", oP));
        }

        public List<Objeto> rListadoExternoCustodia()
        {
            sql oSql = new sql();
            return oSql.Tabla<Objeto>("EXI_R_LISTA_EXTERNA_CUSTODIA");
        }

        public int iCoordinacionExterna()
        {
            return 0;

        }

        public List<Objeto> rEstadoCargaArchivo()
        {
            sql oSql = new sql();
            return oSql.Tabla<Objeto>("EXI_R_ESTADOS_CARGA_ARCHIVO");
        }

        public List<Objeto> rListaEntregaExterna(int idmodo, string codigo, int idservicio, int idmensajeria, int RecordIndex, int Width)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IMODOAGREGAR", idmodo));
            oP.Add(new SqlParameter("@SCODIGO", codigo));
            oP.Add(new SqlParameter("@IDSERVICIO", idservicio));
            oP.Add(new SqlParameter("@IDMENSAJERIA", idmensajeria));
            oP.Add(new SqlParameter("@RECORDINDEX", RecordIndex));
            oP.Add(new SqlParameter("@WIDTH", Width));

            return oSql.TablaParametro<Objeto>("EXI_R_ENTREGA_EXTERNA_AGREGAR_2", oP);
        }

        public int getListaEntregaExternaCONTAR(int idmodo, string codigo, int idservicio, int idmensajeria)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IMODOAGREGAR", idmodo));
            oP.Add(new SqlParameter("@SCODIGO", codigo));
            oP.Add(new SqlParameter("@IDSERVICIO", idservicio));
            oP.Add(new SqlParameter("@IDMENSAJERIA", idmensajeria));
            return (int)oSql.Escalar("EXI_R_ENTREGA_EXTERNA_AGREGAR_CONTAR", oP);
        }


        public List<Objeto> rObtenerDocumentosPorEntregaExterna(Interna.Entity.Entrega oO, int PageRecordIndex, int PageWidth)
        {//PAGINADO
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdEntrega", oO.ID));
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));
            return oSql.TablaParametro<Objeto>("EXI_R_ENTREGA_OBJETO_EXTERNA2", oP);

        }

        public int rObtenerDocumentosPorEntregaExternaCONTAR(int IdEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdEntrega", IdEntrega));
            return (int)oSql.Escalar("EXI_R_ENTREGA_OBJETO_EXTERNA_CONTAR", oP);
        }

        public List<Objeto> rListaExternaIniciado()
        {
            sql oSql = new sql();
            return oSql.Tabla<Objeto>("EXI_R_ENTREGA_EXTERNA_INICIADA");
        }

        public List<Objeto> rListaMonitorResultados(int IdExpedicion, int PageRecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));
            return oSql.TablaParametro<Objeto>("EXI_R_MONITOR_RESULTADOS", oP);
        }

        public int ListaMonitorResultadosCONTAR(int IdExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            return (int)oSql.Escalar("EXI_R_MONITOR_RESULTADOS_CONTAR", oP);
        }

        //fin

        public int uDescargaVirtualExterna()
        {
            return 0;
            /*
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@ID", ID));
            oP.Add(new SqlParameter("@FECHA_ENTREGA", FechaResultado));
            oP.Add(new SqlParameter("@RESULTADO", IdTipoResultado));
            //oP.Add(new SqlParameter("@VALIDACION_CARGO", TipoIdc));
            oP.Add(new SqlParameter("@MOTIVO_REZAGO", MotivoRezago));
            //oP.Add(new SqlParameter("@PRODUCTO", TipoDocumento));
            //iKey = Convert.ToInt32(oSql.Escalar("EXI_C_OBJETO_EXTERNO", oP));
            return Convert.ToInt32((new sql()).Escalar("EXI_U_DESCARGA_VIRTUAL_EXTERNA", oP));
            //return iKey;
             * */


        }

        public int uDescargaFisicaExterna()
        {
            return 0;
            /*
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@ID", ID));
            oP.Add(new SqlParameter("@FECHA_ENTREGA", FechaResultado));
            oP.Add(new SqlParameter("@RESULTADO", IdTipoResultado));
            oP.Add(new SqlParameter("@MOTIVO_REZAGO", MotivoRezago));
            oP.Add(new SqlParameter("@VALIDACION_CARGO", TipoIdc));
            oP.Add(new SqlParameter("@ID_USUARIO", IdUsuario));
            oP.Add(new SqlParameter("@ID_EXPEDICION", IdExpedicionCustodia));
            oP.Add(new SqlParameter("@PRODUCTO", IdTipoDocumento));
            //iKey = Convert.ToInt32(oSql.Escalar("EXI_C_OBJETO_EXTERNO", oP));
            return Convert.ToInt32((new sql()).Escalar("EXI_U_DESCARGA_FISICA_EXTERNA", oP));
            //return iKey;
             * */
        }

        public Objeto rListaDatosExterna(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", id));
            return oSql.TablaTop<Objeto>("EXI_R_DATOS_EXTERNA", oP);
        }

        public List<Objeto> rListaConfirmados(int PageRecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));
            return oSql.TablaParametro<Objeto>("EXI_R_LISTA_CONFIRMADOS", oP);
        }

        public int ListaConfirmadosCONTAR()
        {
            sql oSql = new sql();
            return (int)oSql.Escalar("EXI_R_LISTA_CONFIRMADOS_CONTAR");
        }

        public int EnviarCargos()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_USUARIO", IdUsuario));
            oP.Add(new SqlParameter("@DETALLE", Detalle));

            return Convert.ToInt32((new sql()).Escalar("EXI_C_ENTREGA_CARGO", oP));
        }

        /*Richard12/03/2014 09:59 a.m.*/
        public int c_ObjetoComun(Objeto O)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_TIPOOBJETO", O.IdTipoDocumento));
            oP.Add(new SqlParameter("@DE", O.IdCasillaDe));
            oP.Add(new SqlParameter("@PARA", O.IdCasillaPara));
            oP.Add(new SqlParameter("@MENSAJE", O.Mensaje));
            oP.Add(new SqlParameter("@IDUSUARIO_CREADOR", O.IdUsuario));
            return Convert.ToInt32((new sql()).Escalar("EXI_C_OBJETO_COMUN", oP));
        }

        public int u_Comun_Custodia(Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", oO.ID));
            oP.Add(new SqlParameter("@IDUSUARIO", oO.IdUsuario));
            oP.Add(new SqlParameter("@IDEXPEDICION", oO.IdExpedicionCustodia));
            return Convert.ToInt32((new sql()).Escalar("EXI_U_OBJETO_CUSTODIA_COMUN", oP));
        }

        /*Richard12/03/2014 10:01 a.m.*/
        public List<Objeto> r_ListaComun(Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@RECORDINDEX", oO.PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", oO.PageWidth));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_COMUN", oP);
        }

        public int GetListaComunCONTAR()
        {
            sql oSql = new sql();
            return (int)oSql.Escalar("EXI_R_OBJETO_COMUN_CONTAR");
        }

        public Objeto uObjetoCustodiaCodigo(string sAutogenerado, int idOperario, int idExpedicion, int idMensajeria)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@AUTOGENERADO", sAutogenerado));
            oP.Add(new SqlParameter("@ID_EXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@ID_USUARIO", idOperario));
            oP.Add(new SqlParameter("@ID_MENSAJERIA", idMensajeria));
            return oSql.TablaTop<Objeto>("EXI_U_OBJETO_CUSTODIA", oP);
        }

        public List<Objeto> rObjetoExpedicion(Objeto oO, int RecordIndex, int Width)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", oO.IdExpedicionCustodia));
            oP.Add(new SqlParameter("@RECORDINDEX", RecordIndex));
            oP.Add(new SqlParameter("@WIDTH", Width));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_EXPEDICION_2", oP);
        }

        public int rObjetoExpedicionCONTAR(Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", oO.IdExpedicionCustodia));
            return (int)oSql.Escalar("EXI_R_OBJETO_EXPEDICION_2_CONTAR", oP);
        }

        public int rObjetoExpedicionImpresoCONTAR(Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", oO.IdExpedicionCustodia));
            return (int)oSql.Escalar("EXI_R_OBJETO_EXPEDICION_IMPRESO_2_CONTAR", oP);
        }

        public List<Objeto> rObjetoExpedicionImpreso(Objeto oO, int RecordIndex, int Width)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", oO.IdExpedicionCustodia));
            oP.Add(new SqlParameter("@RECORDINDEX", RecordIndex));
            oP.Add(new SqlParameter("@WIDTH", Width));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_EXPEDICION_IMPRESO_2", oP);
        }

        public List<Objeto> rCorrespondenciaPorCustodiar(int IdExpedicion, int idBandeja, int PageRecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@IDBANDEJA", idBandeja));
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));
            return oSql.TablaParametro<Objeto>("EXI_R_OBJETO_POR_CUSTODIAR", oP);
        }
        public String MetodoPrueba(int IdExpedicion, int idBandeja, int PageRecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@IDBANDEJA", idBandeja));
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));
            return oSql.TablaParametroJSON("EXI_R_OBJETO_POR_CUSTODIAR_PRUEBA", oP);
        }
        //RECIEN DOCUMENTOS POR IMPRIMIR
        public String MetodoPrueba2(int IdExpedicion, int idBandeja)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@IDBANDEJA", idBandeja));
            return oSql.TablaParametroJSON("EXI_R_OBJETO_POR_CUSTODIAR_PRUEBA3", oP);
        }
        //2022
        public String rCorrespondenciaPorCustodiar2(int IdExpedicion)
        {
            sql Osql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", IdExpedicion));
            return Osql.TablaParametroJSON("SIMIH_R_OBJETO_POR_IMPRIMIR", oP);
        }

        public int rCorrespondenciaPorCustodiarCONTAR(int IdExpedicion, int idBandeja)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@IDBANDEJA", idBandeja));
            return (int)oSql.Escalar("EXI_R_OBJETO_POR_CUSTODIAR_CONTAR", oP);
        }

        //Custodiar documenteos desde la ventana de "Documentos por recibir"   
        public int CorrespondenciaPorCustodiarGrupo(Objeto oO, int idUsuario, int idExpedicion, int idMensajeria)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            oP.Add(new SqlParameter("@IDMENSAJERIA", idMensajeria));
            oP.Add(new SqlParameter("@DETALLE", oO.Detalle));
            return Convert.ToInt32((new sql()).Escalar("EXI_R_OBJETO_POR_CUSTODIAR_GRUPO", oP));
        }

        public Objeto objetoImpresion()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", ID));
            return oSql.TablaTop<Objeto>("EXI_R_OBJETO_IMPRESION", oP);
        }

        public Objeto objetoPorImprimir()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicionCustodia));
            oP.Add(new SqlParameter("@AUTOGENERADO", Autogenerado));
            oP.Add(new SqlParameter("@MODO", indicadorFlag));

            return oSql.TablaTop<Objeto>("EXI_R_OBJETO_POR_IMPRIMIR", oP);
        }

        public int entregaExpress(int idObjeto, string dni, string nombre, int idUsuario, int idExpedicionOrigen)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", idObjeto));
            oP.Add(new SqlParameter("@DNI", dni));
            oP.Add(new SqlParameter("@NOMBRE", nombre));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", idExpedicionOrigen));
            return Convert.ToInt32((new sql()).Escalar("EXI_U_ENTREGA_EXPRESS", oP));
        }

        public Objeto uObjetoSeguimiento(string sAutogenerado,
                                            int iEstado,
                                            int iUsuario,
                                            int iBandeja,
                                            int iExpedicion,
                                            int iProceso,
                                            int iMotivo,
                                            string sFechaEntrega,
                                            string sEntregaDNI,
                                            string sEntregaObservacion,
                                            int iEntregaResultado)
        {
            sql oSql = new sql();

            List<SqlParameter> uParameter = new List<SqlParameter>();
            uParameter.Add(new SqlParameter("@IDUSUARIO", iUsuario));

            Usuario usuario = oSql.TablaTop<Usuario>("PC_USUARIO_R_NOMBRE_POR_ID", uParameter);

            Encryption.Encrypt encrypt = new Encryption.Encrypt();
            string nombreUsuario = encrypt.Desencriptar(usuario.sCodigo);

            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", 0));
            oP.Add(new SqlParameter("@AUTOGENERADO", sAutogenerado));
            oP.Add(new SqlParameter("@ESTADO", iEstado));
            oP.Add(new SqlParameter("@USUARIO", iUsuario));
            oP.Add(new SqlParameter("@BANDEJA", iBandeja));
            oP.Add(new SqlParameter("@EXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@PROCESO", iProceso));
            oP.Add(new SqlParameter("@MOTIVO", iMotivo));
            oP.Add(new SqlParameter("@FECHAENTREGA", sFechaEntrega));
            oP.Add(new SqlParameter("@ENTREGADNI", sEntregaDNI));
            oP.Add(new SqlParameter("@ENTREGAOBSERVACION", sEntregaObservacion));
            oP.Add(new SqlParameter("@ENTREGARESULTADO", iEntregaResultado));
            oP.Add(new SqlParameter("@NOMBRE_USUARIO", nombreUsuario));
            return oSql.TablaTop<Objeto>("EXI_U_OBJETO_ESTADO", oP);
        }

        public int uObjeto_EntregaXML(Objeto oO, int iUsuario, int iBandeja, int iExpedicion, int iProceso, int iMotivo)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_USUARIO", iUsuario));
            oP.Add(new SqlParameter("@BANDEJA", iBandeja));
            oP.Add(new SqlParameter("@EXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@PROCESO", iProceso));
            oP.Add(new SqlParameter("@MOTIVO", iMotivo));
            oP.Add(new SqlParameter("@LOBJETO", oO.Detalle));
            return (new sql()).Exec("EXI_U_OBJETO_ENTREGA3", oP);
        }

        public List<Objeto> rObjetoSeguimiento(Interna.Entity.Objeto oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", oO.ID));
            return oSql.TablaParametro<Objeto>("PC_TRACKING_R_OBJETO_SEGUIMIENTO", oP);
        }

        public int uModificarObjetoSeguimiento(int IID,
                                            string sAutogenerado,
                                            int iEstado,
                                            int iUsuario,
                                            int iBandeja,
                                            int iExpedicion,
                                            int iProceso,
                                            int iMotivo,            //string sFechaEntrega,
                                            string sEntregaDNI,
                                            string sEntregaObservacion)
        //int iEntregaResultado)
        {
            sql oSql = new sql();

            List<SqlParameter> uParameter = new List<SqlParameter>();
            uParameter.Add(new SqlParameter("@IDUSUARIO", iUsuario));

            Usuario usuario = oSql.TablaTop<Usuario>("PC_USUARIO_R_NOMBRE_POR_ID", uParameter);

            Encryption.Encrypt encrypt = new Encryption.Encrypt();
            string nombreUsuario = encrypt.Desencriptar(usuario.sCodigo);

            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", IID));
            oP.Add(new SqlParameter("@AUTOGENERADO", sAutogenerado));
            oP.Add(new SqlParameter("@ESTADO", iEstado));
            oP.Add(new SqlParameter("@USUARIO", iUsuario));
            oP.Add(new SqlParameter("@BANDEJA", iBandeja));
            oP.Add(new SqlParameter("@EXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@PROCESO", iProceso));
            oP.Add(new SqlParameter("@MOTIVO", iMotivo));
            oP.Add(new SqlParameter("@FECHAENTREGA", ""));
            oP.Add(new SqlParameter("@ENTREGADNI", sEntregaDNI));
            oP.Add(new SqlParameter("@ENTREGAOBSERVACION", sEntregaObservacion));
            oP.Add(new SqlParameter("@ENTREGARESULTADO", 0));
            oP.Add(new SqlParameter("@NOMBRE_USUARIO", nombreUsuario));
            return oSql.Exec("EXI_U_OBJETO_ESTADO", oP);
        }

        //2022 por eliminar de web, de pc?
        public String rObjetoSeguimientoJSON(int ID, int idcasilla)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            oP.Add(new SqlParameter("@IDCASILLA", idcasilla));
            return oSql.TablaParametroJSON("SIMIH_TRACKING_R_OBJETO_SEGUIMIENTO", oP);
        }
        //2023
        public string CorrespondenciaSeguimiento(int CorrespondenciaId, string upn)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", CorrespondenciaId));
            oP.Add(new SqlParameter("@UPN", upn));
            return oSql.TablaParametroJSON("SIMIH_WEB_CORRESPONDENCIA_SEGUIMIENTO", oP);
        }

        public String rObtenerDetalleJSON(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJECTO", id));
            return oSql.TablaParametroJSON("EXI_R_OBJECTO_DETALLE", oP);
        }
        //2022
        public String rObtenerCreados(string bandejaRemitente, string bandejaDestinatario, int idExpedicion)
        {
            sql Osql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@CasillaDe", bandejaRemitente));
            oP.Add(new SqlParameter("@CasillaPara", bandejaDestinatario));
            oP.Add(new SqlParameter("@IdExpedicion", idExpedicion));
            return Osql.TablaParametroJSON("SIMIH_R_OBTENERCREADO_MODIFICADO", oP);
        }

        public String rObjetosAsociadosEntrega(int iExpedicion, string lPalomares)
        {
            sql Osql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@PALOMARES", lPalomares));
            return Osql.TablaParametroJSON("PEXI_R_OBJETO_ASOCIADO_PALOMAR", oP);
        }
        public Objeto uCambioEstado(string xml, Usuario us, int tipo)
        {

            sql Osql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@OBJETO", xml));
            oP.Add(new SqlParameter("@IDEXPEDICION", us.IdExpedicion));
            oP.Add(new SqlParameter("@IDUSUARIO", us.ID));
            oP.Add(new SqlParameter("@IDCASILLA", us.idCasilla));
            oP.Add(new SqlParameter("@IDGEOCASILLA", us.idGeoCasilla));
            oP.Add(new SqlParameter("@TIPO", tipo));
            return Osql.TablaTop<Objeto>("EXI_U_OBJETO_CAMBIO_ESTADO", oP);

        }

        public string rObjetosINDICADORESVISTOSJSON(int idCasilla, int tipo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCasilla", idCasilla));
            oP.Add(new SqlParameter("@TIPO", tipo));
            return oSql.TablaParametroJSON("WEXI_R_ObtenerINDICADORESVISTOS", oP);
        }
        //2022
        public String rObtenerDetalleWEXIJSON(int id, int idcasilla)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", id));
            oP.Add(new SqlParameter("@IDCASILLA", idcasilla));
            return oSql.TablaParametroJSON("SIMIH_WEB_R_OBJETO_DETALLE", oP);
        }
        //2023
        public string CorrespondenciaDetalle(int correspondenciaId, string upn)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCORRESPONDENCIA", correspondenciaId));
            oP.Add(new SqlParameter("@UPN", upn));
            return oSql.TablaParametroJSON("SIMIH_WEB_CORRESPONDENCIA_DETALLE", oP);
        }

        //2022 por eliminar
        public int rObjetoPorConfirmarJSON(String valores)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@CADENA", valores));
            return Convert.ToInt32(oSql.Escalar("SIMIH_WEB_R_PORCONFIRMAR", oP));
        }

        //2023
        public int CorrespondenciaConfirmar(string json, string upn)
        {
            List<ObjetoConfirmado> listaObjetos = JsonConvert.DeserializeObject<List<ObjetoConfirmado>>(json);
            Objeto objeto = new Objeto();
            string xml = objeto.SerializeObjectWindows(listaObjetos);
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@UPN", upn));
            oP.Add(new SqlParameter("@CONFIRMADOS", xml));
            return Convert.ToInt32(oSql.Escalar("SIMIH_WEB_CORRESPONDENCIA_CONFIRMAR", oP));
        }


        //2022
        public String rObtenerIndicadoresInicio(int id, String fechaI, String fechaF)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", id));
            oP.Add(new SqlParameter("@FECHAINI", fechaI));
            oP.Add(new SqlParameter("@FECHAFIN", fechaF));
            return oSql.TablaParametroJSON("SIMIH_WEB_R_INDICADORES_INICIO", oP);
        }

        //2023
        public string ObtenerIndicadoresInicioPorUsuario(string upn, string fechaI, string fechaF)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@UPN", upn));
            oP.Add(new SqlParameter("@FECHAINI", fechaI));
            oP.Add(new SqlParameter("@FECHAFIN", fechaF));
            return oSql.TablaParametroJSON("SIMIH_WEB_R_INDICADORES_INICIO_POR_USUARIO", oP);
        }

        public List<String> GetTrackingObjeto(Objeto ob)
        {
            sql Osql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", ob.ID));
            return Osql.ListaTablaParametroJSON("EXI_R_OBJETO_TRACKING_TODO", oP);
        }

        /*Villarreal 02/10/2015*/
        public String rObjetoPalomar(int idPalomar)
        {
            sql Osql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDPALOMAR", idPalomar));
            return Osql.TablaParametroJSON("PEXI_R_OBJETO_PALOMAR", oP);
        }
        //2022
        public String rOneObjetoCustodia(string Autogenerado, string Remitente, string Destinatario, int idExpedicion, String fechaDesde, String fechaHasta)
        {
            sql Osql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@AUTOGENERADO", Autogenerado));
            oP.Add(new SqlParameter("@REMITENTE", Remitente));
            oP.Add(new SqlParameter("@DESTINATARIO", Destinatario));
            oP.Add(new SqlParameter("@FECHADESDE", fechaDesde));
            oP.Add(new SqlParameter("@FECHAHASTA", fechaHasta));
            return Osql.TablaParametroJSON("SIMIH_DOCUMENTOSCUSTODIADOS_R_CONSULTACOMPLETA", oP);
        }
        //2022
        public string ValidarEstadoObjeto(string Autogenerado)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@AUTOGENERADO", Autogenerado));
            return oSql.TablaParametroJSON("SIMIH_VALIDA_ESTADO_OBJETO", oP);
        }

        public int uGrabarTipoResultado(string detalle, int idEntrega, int idUsuario, int idBandeja, int idExpedicion, int idGeoCasilla)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@OBJETO", detalle));
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            oP.Add(new SqlParameter("@IDBANDEJA", idBandeja));
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@IDGEOCASILLA", idGeoCasilla));
            return Convert.ToInt32(oSql.Escalar("PEXI_U_ENTREGA_PISOS_GRABAR_CAMBIOS_IMPORTACION", oP));
        }

        //2022
        public string rObjetosOtraSucursal(string sAutogenerado, string sRemitente, string sDestinatario, int iExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@AUTOGENERADO", sAutogenerado));
            oP.Add(new SqlParameter("@REMITENTE", sRemitente));
            oP.Add(new SqlParameter("@DESTINATARIO", sDestinatario));
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            return oSql.TablaParametroJSON("SIMIH_IMPRESIONOTRASEDE_R_BUSCAR", oP);

        }
        //2022
        public int uCustodiaAutogeneradoOtraSucursal(int iAutogenerado, int iUsuario, int iExpedicion, int iCasilla, int iGeoCasilla)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", iAutogenerado));
            oP.Add(new SqlParameter("@IDUSUARIO", iUsuario));
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@IDCASILLA", iCasilla));
            oP.Add(new SqlParameter("@IDGEOCASILLA", iGeoCasilla));
            return Convert.ToInt32(oSql.Escalar("SIMIH_IMPRESIONOTRASEDE_U_IMPRIMIR", oP));
        }
        /*Benji villarreal 04/01/2016*/
        public int uRegularizarObjeto(Objeto obj, int idUsuario, int idBandeja, int idExpedicion, int idGeo)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", obj.ID));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            oP.Add(new SqlParameter("@IDBANDEJA", idBandeja));
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@IDGEO", idGeo));
            return Convert.ToInt32((new sql()).Escalar("PEXI_U_REGULARIZAR_OBJETO", oP));
        }
        //2022
        public string rObtenerSobrantes(string autogenerado, int idExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@AUTOGENERADO", autogenerado));
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            return oSql.TablaParametroJSON("SIMIH_DOCUMENTOSSOBRANTES_R_CONSULTAR", oP);
        }
        //2022
        public int uRegularizarObjetoSobrante(Objeto obj, int idUsuario, int idBandeja, int idExpedicion, int idGeo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", obj.ID));
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            oP.Add(new SqlParameter("@IDGEO", idGeo));
            oP.Add(new SqlParameter("@IDCASILLA", idBandeja));
            return Convert.ToInt32((new sql()).Escalar("SIMIH_DOCUMENTOSSOBRANTES_U_CUSTODIAR", oP));
        }
        //2022
        public List<String> SeguimientoAutogeneradoDesktop(Objeto ob)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", ob.ID));
            return oSql.ListaTablaParametroJSON("SIMIH_TRACKING_R_TODO", oP);
        }
        //2022
        public String rConsultaAutogeneradoReporte(String autogenerado)
        {
            sql Osql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@Autogenerado", autogenerado));
            oP.Add(new SqlParameter("@De", ""));
            oP.Add(new SqlParameter("@Para", ""));
            oP.Add(new SqlParameter("@Desde", ""));
            oP.Add(new SqlParameter("@Hasta", ""));
            return Osql.TablaParametroJSON("SIMIH_CONSULTAYREPORTES_R_LISTARELEMENTOS", oP);
        }
        //2022
        public String rConsultaAutogeneradoReporte(String de, String para, DateTime desde, DateTime hasta)
        {
            sql Osql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@Autogenerado", ""));
            oP.Add(new SqlParameter("@De", de));
            oP.Add(new SqlParameter("@Para", para));
            oP.Add(new SqlParameter("@Desde", desde));
            oP.Add(new SqlParameter("@Hasta", hasta));
            return Osql.TablaParametroJSON("SIMIH_CONSULTAYREPORTES_R_LISTARELEMENTOS", oP);
        }
        //2022
        public String rConsultaElementosReporteGeneral(int idEstado, int idTipoEntrega, int idExpedicionOrigen, int idExpedicionDestino,
            int FechaDe, DateTime desde, DateTime hasta)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDESTADO", idEstado));
            oP.Add(new SqlParameter("@TIPOENTREGA", idTipoEntrega));
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", idExpedicionOrigen));
            oP.Add(new SqlParameter("@IDEXPEDICIONDESTINO", idExpedicionDestino));
            oP.Add(new SqlParameter("@FECHADE", FechaDe));
            oP.Add(new SqlParameter("@DESDE", desde));
            oP.Add(new SqlParameter("@HASTA", hasta));
            return new sql().TablaParametroJSON("SIMIH_CONSULTAYREPORTES_CORRES_GENERAL_R_LISTAR_ELEMENTOS2", oP);
        }
        //2022
        public String rReportesListarElementosCreadosPediente(int idExpedicion)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            return new sql().TablaParametroJSON("SIMIH_CONSULTAYREPORTES_R_LISTAR_ELEMENTOS_CREADOS", oP);
        }
        //2022
        public string ListarObjetosPDA(string xmlLote)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@LOTE", xmlLote));
            return oSql.TablaParametroJSON("SIMIH_ENTREGAAGENCIA_R_LISTAROBJETOSPDA", oP);
        }
        //2022
        public int ImportarObjetosValidadosPDA(string xmlLote)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@LOTE", xmlLote));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAAGENCIA_U_IMPORTAR", oP));
        }
        //2022
        public int ImportarResultadoPDA(Usuario oUsuario)
        {
            sql oSql = new sql();
            List<ObjetoPiso> listaObjeto = JsonConvert.DeserializeObject<List<ObjetoPiso>>(Detalle);
            string xml = this.SerializeObjectWindows(listaObjeto);
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdUsuario", oUsuario.ID));
            oP.Add(new SqlParameter("@IdBandeja", oUsuario.idCasilla));
            oP.Add(new SqlParameter("@IdExpedicion", oUsuario.IdExpedicion));
            oP.Add(new SqlParameter("@IdEntrega", IdEntrega));
            oP.Add(new SqlParameter("@ListaObjeto", xml));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAPISOS_U_IMPORTAR_RESULTADO_PDA", oP));
        }

        //2022
        public string ListarAutogeneradoCambioEstado(string autogenerado)
        {
            sql Osql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@AUTOGENERADO", autogenerado));
            return Osql.TablaTopJson("SIMIH_CAMBIOESTADO_R_AUTOGENERADO", oP);
        }
        //2022
        public int CambiarEstadoAutogenerado(int idElemento, int idEstadoActual, int idNuevoEstado, int idUsuario, int idBandeja, int idGeo, int idExpedicion, string observacion, byte iIdMotivoCambioEstado)
        {
            sql Osql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDELEMENTO", idElemento));
            oP.Add(new SqlParameter("@IDESTADOACTUAL", idEstadoActual));
            oP.Add(new SqlParameter("@IDNUEVOESTADO", idNuevoEstado));
            oP.Add(new SqlParameter("@IDSUPERVISOR", idUsuario));
            oP.Add(new SqlParameter("@IDBANDEJA", idBandeja));
            oP.Add(new SqlParameter("@IDGEO", idGeo));
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@OBSERVACION", observacion));
            oP.Add(new SqlParameter("@iIdMotivoCambioEstado", iIdMotivoCambioEstado));
            return Convert.ToInt32((Osql.Escalar("SIMIH_CAMBIOESTADO_U_CAMBIARESTADO", oP)));
        }


        // Funcional - frmDocumentosProcesados
        public int AsociarAutogeneradoDocumentos(int IdTipoDocumento, int IdCasillaDe, int IdCasillaPara, string Asunto, string Mensaje, int IdUsuario, string ListaXML)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_TIPOOBJETO", IdTipoDocumento));
            oP.Add(new SqlParameter("@DE", IdCasillaDe));
            oP.Add(new SqlParameter("@PARA", IdCasillaPara));
            oP.Add(new SqlParameter("@ASUNTO", Asunto));
            oP.Add(new SqlParameter("@MENSAJE", Mensaje));
            oP.Add(new SqlParameter("@IDUSUARIO_CREADOR", IdUsuario));
            oP.Add(new SqlParameter("@DETALLE", ListaXML));
            return Convert.ToInt32(oSql.Escalar("PC_MESAPARTES_C_ASOCIAR_AUTOGENERADO_DOCUMENTOS", oP));
        }
        //2022
        public string ListarGeoAnteriorDeObjeto(Objeto objeto)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@sAutogenerado", objeto.Autogenerado));
            return oSql.TablaParametroJSON("SIMIH_ENTREGA_R_OBJETO_GEO_ANTERIOR", oP);
        }
        //2022
        public string ListarObjetosGeoCambiadoDeAgencia(string objetos)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@OBJETOS", objetos));
            return oSql.TablaParametroJSON("SIMIH_ENTREGAAGENCIA_U_OBJETOSGEOCAMBIADO", oP);
        }

        /*Orlando Heredia - 16/02/2017 */
        public int RetirarObjetoDeEntregaPisos()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdObjeto", ID));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicionCustodia));
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuario));
            oP.Add(new SqlParameter("@IDBANDEJA", IdCasillaDe)); // Casilla de la expedicion
            oP.Add(new SqlParameter("@IDGEO", IdGeoBandejaFisica));
            return Convert.ToInt32(oSql.Escalar("PC_ENTREGAPISOSRESULTADO_D_RETIRAR_OBJETO_ENTREGA", oP));
        }

        //2022
        public string RecibirObjetosMasivoContingencia()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@OBJETOS", Detalle));
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuario));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicionCustodia));
            return oSql.TablaParametroJSON("SIMIH_CONTINGENCIA_U_RECIBIR_DOCUMENTOS_MASIVO", oP);
        }
        //2022
        public String rConsultaElementosReporteGeneralDetalle(int idEstado, int idTipoEntrega, int idExpedicionOrigen, int idExpedicionDestino,
            int FechaDe, DateTime desde, DateTime hasta)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDESTADO", idEstado));
            oP.Add(new SqlParameter("@TIPOENTREGA", idTipoEntrega));
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", idExpedicionOrigen));
            oP.Add(new SqlParameter("@IDEXPEDICIONDESTINO", idExpedicionDestino));
            oP.Add(new SqlParameter("@FECHADE", FechaDe));
            oP.Add(new SqlParameter("@DESDE", desde));
            oP.Add(new SqlParameter("@HASTA", hasta));
            return new sql().TablaParametroJSON("SIMIH_CONSULTAYREPORTES_CORRES_GENERAL_R_LISTAR_ELEMENTOS_DETALLE", oP);
        }

        public string ListarRetiradosPorRango(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DFECHAINICIO", dFechaInicial));
            oP.Add(new SqlParameter("@DFECHAFIN", dFechaFinal));
            return new sql().TablaParametroJSON("WEB_REPORTES_LISTAR_DETALLE_RETIRADOS", oP);
        }

        //Funcional
        public string ListarCantidadEstadosIndicador(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@dFechaInicio", dFechaInicial));
            oP.Add(new SqlParameter("@dFechaFin", dFechaFinal));
            return new sql().TablaParametroJSON("WEB_REPORTES_LISTAR_CANTIDAD_PENDIENTES", oP);
        }

        //Funcional
        public string ListarEstadosIndicador(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@dFechaInicio", dFechaInicial));
            oP.Add(new SqlParameter("@dFechaFin", dFechaFinal));
            return new sql().TablaParametroJSON("WEB_REPORTES_LISTAR_DETALLE_PENDIENTES", oP);
        }

        //Funcional
        public string ListarCantidadEstadoAutogeneradoActual(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@dFechaInicio", dFechaInicial));
            oP.Add(new SqlParameter("@dFechaFin", dFechaFinal));
            return new sql().TablaParametroJSON("WEB_REPORTES_LISTAR_CANTIDAD_ESTADO_AUTOGENERADO_ACTUAL", oP);
        }

        //Funcional
        public string ListarDetalleEstadoAutogeneradoActual(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@dFechaInicio", dFechaInicial));
            oP.Add(new SqlParameter("@dFechaFin", dFechaFinal));
            return new sql().TablaParametroJSON("WEB_REPORTES_LISTAR_DETALLE_ESTADO_AUTOGENERADO_ACTUAL", oP);
        }

        //Funcional
        public string ListarCantidadEstadoAutogeneradoActualCustodia(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@dFechaInicio", dFechaInicial));
            oP.Add(new SqlParameter("@dFechaFin", dFechaFinal));
            return new sql().TablaParametroJSON("WEB_REPORTES_LISTAR_CANTIDAD_ESTADO_AUTOGENERADO_ACTUAL_CUSTODIA", oP);
        }

        //Funcional
        public string ListarDetalleEstadoAutogeneradoActualCustodia(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@dFechaInicio", dFechaInicial));
            oP.Add(new SqlParameter("@dFechaFin", dFechaFinal));
            return new sql().TablaParametroJSON("WEB_REPORTES_LISTAR_DETALLE_ESTADO_AUTOGENERADO_ACTUAL_CUSTODIA", oP);
        }

        //Funcional
        public string ListarCantidadEstadosIndicadorCustodia(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@dFechaInicio", dFechaInicial));
            oP.Add(new SqlParameter("@dFechaFin", dFechaFinal));
            return new sql().TablaParametroJSON("WEB_REPORTES_LISTAR_CANTIDAD_PENDIENTES_CUSTODIA", oP);
        }

        //Funcional
        public string ListarEstadosIndicadorCustodia(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@dFechaInicio", dFechaInicial));
            oP.Add(new SqlParameter("@dFechaFin", dFechaFinal));
            return new sql().TablaParametroJSON("WEB_REPORTES_LISTAR_DETALLE_PENDIENTES_CUSTODIA", oP);
        }

        //Funcional
        public string ReporteDocumentosEspeciales(int tipodocumento, DateTime dFechaInicial, DateTime dFechaFinal)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdTipoDocumento", tipodocumento));
            oP.Add(new SqlParameter("@dFechaInicio", dFechaInicial));
            oP.Add(new SqlParameter("@dFechaFin", dFechaFinal));
            return new sql().TablaParametroJSON("WEB_REPORTE_DOCUMENTOS_ESPECIALES_TIPO", oP);
        }
        //2022
        public string ValidarEstadoSobrante(string Autogenerado)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@AUTOGENERADO", Autogenerado));
            return oSql.TablaParametroJSON("SIMIH_VALIDAR_ESTADO_SOBRANTE", oP);
        }

        //2023
        public int ImportarResultadoPisosPDA(Usuario oUsuario)
        {
            sql oSql = new sql();
            List<ObjetoPiso> listaObjeto = JsonConvert.DeserializeObject<List<ObjetoPiso>>(Detalle, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            string xml = this.SerializeObjectWindows(listaObjeto);
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdUsuario", oUsuario.ID));
            oP.Add(new SqlParameter("@IdBandeja", oUsuario.idCasilla));
            oP.Add(new SqlParameter("@IdExpedicion", oUsuario.IdExpedicion));
            oP.Add(new SqlParameter("@IdEntrega", IdEntrega));
            oP.Add(new SqlParameter("@ListaObjeto", xml));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAPISOS_U_IMPORTAR_RESULTADO_PDA_BANDEJA_FISICA", oP));
        }

        //2023
        public string ConsultaElementosReporteGeneral(int idEstado, int idTipoEntrega, int idExpedicionOrigen, int idExpedicionDestino,
            int FechaDe, DateTime desde, DateTime hasta)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDESTADO", idEstado));
            oP.Add(new SqlParameter("@TIPOENTREGA", idTipoEntrega));
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", idExpedicionOrigen));
            oP.Add(new SqlParameter("@IDEXPEDICIONDESTINO", idExpedicionDestino));
            oP.Add(new SqlParameter("@FECHADE", FechaDe));
            oP.Add(new SqlParameter("@DESDE", desde));
            oP.Add(new SqlParameter("@HASTA", hasta));
            return new sql().TablaParametroJSON("SIMIH_CONSULTAYREPORTES_CORRES_GENERAL_R_LISTAR_ELEMENTOS3", oP);
        }

        //2023
        public string ConsultaElementosReporteGeneralDetalle(int idEstado, int idTipoEntrega, int idExpedicionOrigen, int idExpedicionDestino,
            int FechaDe, DateTime desde, DateTime hasta)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDESTADO", idEstado));
            oP.Add(new SqlParameter("@TIPOENTREGA", idTipoEntrega));
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", idExpedicionOrigen));
            oP.Add(new SqlParameter("@IDEXPEDICIONDESTINO", idExpedicionDestino));
            oP.Add(new SqlParameter("@FECHADE", FechaDe));
            oP.Add(new SqlParameter("@DESDE", desde));
            oP.Add(new SqlParameter("@HASTA", hasta));
            return new sql().TablaParametroJSON("SIMIH_CONSULTAYREPORTES_CORRES_GENERAL_R_LISTAR_ELEMENTOS_DETALLE3", oP);
        }

        //2023
        public string ReporteEntregaIntersucursales(DateTime desde, DateTime hasta)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DESDE", desde));
            oP.Add(new SqlParameter("@HASTA", hasta));
            return new sql().TablaParametroJSON("SIMIH_REPORTE_ENTREGA_INTERSUCURSALES", oP);
        }
        //2023
        public string CorrespondenciaPorNotificarEntregaBandejaFisica(int entregaId)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@entregaId", entregaId));
            return new sql().TablaParametroJSON("SIMIH_MAIL_CORRESPONDENCIA_POR_NOTIFICAR_ENTREGA_EN_BANDEJA_FISICA", oP);
        }
        //2023
        public string CorrespondenciaPorNotificarEntregaRutaAgencia(int loteId)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@loteId", loteId));
            return new sql().TablaParametroJSON("SIMIH_MAIL_CORRESPONDENCIA_POR_NOTIFICAR_ENTREGA_RUTA_AGENCIAS", oP);
        }
        //2023
        public string CorrespondenciaPorNotificarEntregaRutaAgenciaJos(int loteId)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@loteId", loteId));
            return new sql().TablaParametroJSON("SIMIH_MAIL_CORRESPONDENCIA_POR_NOTIFICAR_ENTREGA_RUTA_AGENCIAS_JOS", oP);
        }

        //2023
        public string ReportePorAutogenerado(string autogenerado)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@AUTOGENERADO", autogenerado));
            return new sql().TablaParametroJSON("SIMIH_REPORTES_POR_AUTOGENERADO", oP);
        }

        //2023
        public string ReportePorMatricula(string matricula, DateTime fechaInicio, DateTime fechaFin)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@MATRICULA", matricula));
            oP.Add(new SqlParameter("@FECHA_INICIO", fechaInicio));
            oP.Add(new SqlParameter("@FECHA_FIN", fechaFin));
            return new sql().TablaParametroJSON("SIMIH_REPORTES_POR_MATRICULA", oP);
        }

        //2023
        public string ReportePorEstado(int estadoId, DateTime fechaInicio, DateTime fechaFin)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ESTADO", estadoId));
            oP.Add(new SqlParameter("@FECHA_INICIO", fechaInicio));
            oP.Add(new SqlParameter("@FECHA_FIN", fechaFin));
            return new sql().TablaParametroJSON("SIMIH_REPORTES_POR_ESTADO", oP);
        }

        //2023
        public string ReporteDocumentosEntreExpediciones(int expedicionOrigenId, int expedicionDestinoId, int areaOrigenId, int areaDestinoId, DateTime fechaInicio, DateTime fechaFin)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@EXPEDICION_ORIGEN", expedicionOrigenId));
            oP.Add(new SqlParameter("@EXPEDICION_DESTINO", expedicionDestinoId));
            oP.Add(new SqlParameter("@AREA_ORIGEN", areaOrigenId));
            oP.Add(new SqlParameter("@AREA_DESTINO", areaDestinoId));
            oP.Add(new SqlParameter("@FECHA_INICIO", fechaInicio));
            oP.Add(new SqlParameter("@FECHA_FIN", fechaFin));
            return new sql().TablaParametroJSON("SIMIH_REPORTES_DOCUMENTOS_ENTRE_EXPEDICIONES", oP);
        }

        //2023
        public string ReporteDocumentosHaciaAgencias(int tipoAgenciaId, DateTime fechaInicio, DateTime fechaFin)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@TIPO_AGENCIA", tipoAgenciaId));
            oP.Add(new SqlParameter("@FECHA_INICIO", fechaInicio));
            oP.Add(new SqlParameter("@FECHA_FIN", fechaFin));
            return new sql().TablaParametroJSON("SIMIH_REPORTES_DOCUMENTOS_HACIA_AGENCIAS", oP);
        }

        //2023
        public string ReporteCorrespondenciaDetalle(int correspondenciaId)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCORRESPONDENCIA", correspondenciaId));
            return oSql.TablaParametroJSON("SIMIH_WEB_REPORTE_CORRESPONDENCIA_DETALLE", oP);
        }

        //2023
        public string ReporteCorrespondenciaSeguimiento(int CorrespondenciaId)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", CorrespondenciaId));
            return oSql.TablaParametroJSON("SIMIH_WEB_REPORTE_CORRESPONDENCIA_SEGUIMIENTO", oP);
        }

        //2024
        public string ActualizarCorrespondenciaNotificada(int loteId, List<CorrespondenciaNotificada> listaCorrespondenciaNotificada)
        {
            string xml = this.SerializeObjectWindows(listaCorrespondenciaNotificada);
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@loteId", loteId));
            oP.Add(new SqlParameter("@detalle", xml));
            return new sql().TablaParametroJSON("SIMIH_MAIL_CORRESPONDENCIA_NOTIFICADA_ACTUALIZAR", oP);
        }
    }

}