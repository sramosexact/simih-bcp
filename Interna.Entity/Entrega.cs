using Interna.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Entrega : Interna.Core.Entity
    {
        #region Propiedades
        /*
         * PAGINACION 
         * */
        public int PageRecordIndex { get; set; }
        public int PageWidth { get; set; }


        // 
        [DataMember]
        public int ID { get; set; }

        [Column(Name = "IdExpedicion")]
        [DataMember]
        public int IdExpedicionOrigen { get; set; }

        [Column(Name = "Expedicion")]
        [DataMember]
        public string ExpedicionOrigen { get; set; }

        [Column(Name = "IdTipoTransporte")]
        [DataMember]
        public int IdTipoEntrega { get; set; }
        [DataMember]
        public string TipoEntrega { get; set; }
        [DataMember]
        public int IdMensajeria { get; set; }
        public string Mensajeria { get; set; }
        [DataMember]
        public string Usuario { get; set; }


        public DateTime Registro { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public DateTime Cierre { get; set; }

        //FECHAS JSON **************************
        private string _RegistroJson = "0001-01-01";
        [DataMember]
        public string RegistroJson
        {
            get
            {
                return _RegistroJson;
            }
            set
            {
                Registro = DateTime.Parse(value);
                _RegistroJson = value;
            }
        }

        private string _InicioJson = "0001-01-01";
        [DataMember]
        public string InicioJson
        {
            get
            {
                return _InicioJson;
            }
            set
            {
                Inicio = DateTime.Parse(value);
                _InicioJson = value;
            }
        }

        private string _FinJson = "0001-01-01";
        [DataMember]
        public string FinJson
        {
            get
            {
                return _FinJson;
            }
            set
            {
                Fin = DateTime.Parse(value);
                _FinJson = value;
            }
        }

        private string _CierreJson = "0001-01-01";
        [DataMember]
        public string CierreJson
        {
            get
            {
                return _CierreJson;
            }
            set
            {
                Cierre = DateTime.Parse(value);
                _CierreJson = value;
            }
        }

        //*****************************************
        [DataMember]
        public int Exportado { get; set; }
        [DataMember]
        public int Importado { get; set; }

        [Column(Name = "Destino")]
        [DataMember]
        public int iDestino { get; set; }

        public String strRegistro { get { return Registro.Year < 2000 ? string.Empty : Registro.ToString(); } }
        public String strInicio { get { return Inicio.Year < 2000 ? string.Empty : Inicio.ToString(); } }
        public String strFin { get { return Fin.Year < 2000 ? string.Empty : Fin.ToString(); } }
        public String strCierre { get { return Cierre.Year < 2000 ? string.Empty : Cierre.ToString(); } }

        [Column(Name = "IdUsuario")]
        [DataMember]
        public int IdUsuarioCreador { get; set; }
        [DataMember]
        public int Estado { get; set; }
        [DataMember]
        public int idTipoValidacion { get; set; }
        public DateTime fechaValidacion { get; set; }
        public String strfechaValidacion { get { return fechaValidacion.Year < 2000 ? string.Empty : fechaValidacion.ToString(); } }
        [DataMember]
        public string EstadoDescripcion { get; set; }
        public string Detalle { get; set; }
        public int IdObjeto { get; set; }

        //Entrega tarjetas
        [DataMember]
        public int IdColaborador { get; set; }
        [DataMember]
        public string Colaborador { get; set; }
        public string DescRuta { get; set; }
        public string Descripcion { get; set; }
        public int IdRuta { get; set; }
        [DataMember]
        public int IdExpedicionDestino { get; set; }
        [DataMember]
        public string ExpedicionDestino { get; set; }
        [DataMember]
        public string UsuarioDescripcion { get; set; }

        public int IdServicio { get; set; }
        public string Servicio { get; set; }


        //:)
        [DataMember]
        public int noRecibido { get; set; }
        public int indicadorFlag { get; set; }


        //Para la Web 
        public int INX { get; set; }
        public string TABLA { get; set; }
        public string FECHA { get; set; }
        public string VALOR1 { get; set; }
        public string VALOR2 { get; set; }
        public string VALOR3 { get; set; }
        public string VALOR4 { get; set; }

        // Para la PC (Totales)
        [Info(Min = 0)]
        [DataMember]
        public int Total { get; set; }
        [Info(Min = 0)]
        [DataMember]
        public int Pendientes { get; set; }
        [Info(Min = 0)]
        [DataMember]
        public int Resuelto { get; set; }
        [Info(Min = 0)]
        [DataMember]
        public int Custodia { get; set; }
        [Info(Min = 0)]
        [DataMember]
        public int Recibido { get; set; }

        public List<Objeto> DetalleObjetos { set; get; }
        [DataMember]
        public string CodigoAgencia { get; set; }
        [DataMember]
        public string Agencia { get; set; }

        [DataMember]
        public byte iCantidadBultos { get; set; }

        [DataMember]
        public int iIdEntregaGrupo { get; set; }

        #endregion


        public int pcsGrabar()
        {
            int iKey = 0;

            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            if (ID > 0) oP.Add(new SqlParameter("@ID", ID));
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", IdExpedicionOrigen));
            oP.Add(new SqlParameter("@IDTIPOTRANSPORTE", IdTipoEntrega));
            oP.Add(new SqlParameter("@IDMENSAJERIA", IdMensajeria));
            //oP.Add(new SqlParameter("@INICIO", Inicio));
            //oP.Add(new SqlParameter("@FIN", Fin));
            oP.Add(new SqlParameter("@IDUSUARIOCREADOR", IdUsuarioCreador));
            oP.Add(new SqlParameter("@DETALLE", Detalle.Trim()));

            if (ID == 0)
                iKey = Convert.ToInt32(oSql.Escalar("EXI_C_ENTREGA", oP));
            else
                iKey = Convert.ToInt32(oSql.Escalar("EXI_U_ENTREGA", oP));

            return iKey;
        }

        public int pcsIniciar()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IID", ID));
            oP.Add(new SqlParameter("@ID_USUARIO", IdUsuarioCreador));

            return Convert.ToInt32(oSql.Escalar("EXI_C_ENTREGA_INICIA", oP));
        }

        public int pcsTerminar()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IID", ID));
            oP.Add(new SqlParameter("@ID_USUARIO", IdUsuarioCreador));

            return Convert.ToInt32(oSql.Escalar("EXI_C_ENTREGA_TERMINA", oP));
        }

        public int pcsCerrar()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IID", ID));
            return Convert.ToInt32(oSql.Escalar("EXI_C_ENTREGA_CIERRA", oP));
        }

        public int pcsEliminar()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IID", ID));

            sql osql = new sql();
            int iKey = Convert.ToInt32(osql.Escalar("EXI_D_ENTREGA", oP));
            return iKey;
        }

        public List<Entrega> pcsListar()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicionOrigen));
            return (new sql()).TablaParametro<Entrega>("EXI_R_ENTREGA", oP);
        }

        public Entrega rEntregaId(int ID)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@ID", ID));
            return (new sql()).TablaTop<Entrega>("EXI_R_ENTREGA_ID", oP);
        }

        public int uValidaEncasillado()
        {
            int iKey = 0;

            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            if (ID > 0) oP.Add(new SqlParameter("@IDENTREGA", ID));
            oP.Add(new SqlParameter("@IDOBJETO", IdObjeto));
            oP.Add(new SqlParameter("@IDUSUARIOCREADOR", IdUsuarioCreador));
            oP.Add(new SqlParameter("@TIPOVALIDACION", idTipoValidacion));
            oP.Add(new SqlParameter("@FECHAVALIDACION", fechaValidacion));

            iKey = Convert.ToInt32(oSql.Escalar("EXI_U_VALIDA_ENCASILLADO", oP));

            return iKey;
        }
        public int uValidarEncasilladoPDA()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            if (ID > 0) oP.Add(new SqlParameter("@IDENTREGA", ID));
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", IdExpedicionOrigen));
            oP.Add(new SqlParameter("@DETALLE", Detalle.Trim()));

            return Convert.ToInt32(oSql.Escalar("EXI_U_VALIDA_ENCASILLADO_PDA", oP));

        }
        public int dObjeto_Entrega()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            if (ID > 0) oP.Add(new SqlParameter("@IDOBJETO", IdObjeto));
            oP.Add(new SqlParameter("@IDENTREGA", ID));

            return Convert.ToInt32(oSql.Escalar("EXI_D_OBJETO_ENTREGA", oP));
        }

        public int uReemplazarObjetosEntrega()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            if (ID > 0) oP.Add(new SqlParameter("@IDENTREGA", ID));
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", IdExpedicionOrigen));
            oP.Add(new SqlParameter("@DETALLE", Detalle.Trim()));

            return Convert.ToInt32(oSql.Escalar("EXI_U_REEMPLAZA_OBJETO_ENTREGA", oP));
        }
        public int uAgregarObjetosEntrega()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            if (ID > 0) oP.Add(new SqlParameter("@IDENTREGA", ID));
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", IdExpedicionOrigen));
            oP.Add(new SqlParameter("@DETALLE", Detalle.Trim()));

            return Convert.ToInt32(oSql.Escalar("EXI_U_AGREGA_OBJETO_ENTREGA", oP));
        }

        //Entrega de tarjetas
        public int pcsGrabarTarjeta()
        {
            int iKey = 0;

            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            if (ID > 0) oP.Add(new SqlParameter("@ID", ID));
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", IdExpedicionOrigen));
            oP.Add(new SqlParameter("@IDTIPOTRANSPORTE", IdTipoEntrega));
            //oP.Add(new SqlParameter("@INICIO", Inicio));
            //oP.Add(new SqlParameter("@FIN", Fin));
            oP.Add(new SqlParameter("@IDUSUARIOCREADOR", IdUsuarioCreador));
            oP.Add(new SqlParameter("@IDUSUARIOCOLABORADOR", IdColaborador));
            oP.Add(new SqlParameter("@IDRUTA", IdRuta));
            oP.Add(new SqlParameter("@DETALLE", Detalle.Trim().ToUpper()));

            if (ID == 0)
                iKey = Convert.ToInt32(oSql.Escalar("EXI_C_ENTREGA_TARJETA", oP));
            else
                iKey = Convert.ToInt32(oSql.Escalar("EXI_U_ENTREGA_TARJETA", oP));

            return iKey;
        }

        public Entrega rEntregaTarjetaId(int ID)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@ID", ID));
            return (new sql()).TablaTop<Entrega>("EXI_R_ENTREGA_TARJETA_ID", oP);
        }

        public int pcsTerminarEntregaTarjeta()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IID", ID));
            oP.Add(new SqlParameter("@ID_USUARIO", IdUsuarioCreador));
            oP.Add(new SqlParameter("@DETALLE", Detalle));

            sql osql = new sql();
            int iKey = Convert.ToInt32(osql.Escalar("EXI_C_ENTREGA_TARJETA_TERMINA", oP));
            return iKey;
        }

        public int pcsCerrarTarjeta()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IID", ID));
            oP.Add(new SqlParameter("@DETALLE", Detalle));

            sql osql = new sql();
            int iKey = Convert.ToInt32(osql.Escalar("EXI_C_ENTREGA_TARJETA_CIERRA", oP));

            return iKey;
        }
        // Jhoel

        public int pcsGrabarExterna()
        {
            int iKey = 0;

            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            if (ID > 0) oP.Add(new SqlParameter("@ID", ID));
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", IdExpedicionOrigen));
            oP.Add(new SqlParameter("@IDTIPOTRANSPORTE", IdTipoEntrega));
            oP.Add(new SqlParameter("@IDMENSAJERIA", IdMensajeria));
            oP.Add(new SqlParameter("@IDUSUARIOCREADOR", IdUsuarioCreador));

            oP.Add(new SqlParameter("@DETALLE", Detalle.Trim().ToUpper()));

            if (ID == 0)
                iKey = Convert.ToInt32(oSql.Escalar("EXI_C_ENTREGA_EXTERNA", oP));
            else
                iKey = Convert.ToInt32(oSql.Escalar("EXI_U_ENTREGA_EXTERNA", oP));

            return iKey;
        }

        public Entrega rEntregaExternaId(int ID)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@ID", ID));
            return (new sql()).TablaTop<Entrega>("EXI_R_ENTREGA_EXTERNA_ID", oP);
        }

        public int pcsGrabarExternaObjeto()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            if (ID > 0) oP.Add(new SqlParameter("@IDENTREGA", ID));
            oP.Add(new SqlParameter("@DETALLE", Detalle.Trim().ToUpper()));

            return Convert.ToInt32((new sql()).Escalar("EXI_C_ENTREGA_OBJETO_EXTERNA", oP));
        }
        //fin

        //POLLO
        public List<Entrega> rListarEntregaObjetoWeb(int idGeo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDGEO", idGeo));
            return oSql.TablaParametro<Entrega>("EXI_R_ENTREGA_OBJETO_WEB", oP);
        }

        // Alessandro
        public List<Entrega> EntregasAutomaticas()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", this.IdExpedicionOrigen));
            oP.Add(new SqlParameter("@IDUSUARIO", this.IdUsuarioCreador));
            oP.Add(new SqlParameter("@IDTIPOTRANSPORTE", this.IdTipoEntrega));
            return oSql.TablaParametro<Entrega>("EXI_C_ENTREGAS_AUTOMATICAS", oP);
        }

        public List<Entrega> rListarEntregaModo(int PageRecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicionOrigen));
            oP.Add(new SqlParameter("@IDMODO", IdObjeto));
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));
            return (new sql()).TablaParametro<Entrega>("EXI_R_ENTREGA_MODO", oP);
        }

        public int rListarEntregaModoCONTAR()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicionOrigen));
            oP.Add(new SqlParameter("@IDMODO", IdObjeto));
            return (int)oSql.Escalar("EXI_R_ENTREGA_MODO_CONTAR", oP);
        }

        public int uValidarEncasilladoMasivoPDA(Objeto oLista)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", oLista.IdExpedicionCustodia));
            oP.Add(new SqlParameter("@IDUSUARIO", oLista.IdUsuario));
            oP.Add(new SqlParameter("@DETALLE", oLista.Detalle));
            return (int)oSql.Escalar("EXI_U_ENTREGA_ENCASILLADO_MASIVO_PDA", oP);
        }

        public int uProcesarPisosMasivoPDA(Objeto oLista)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", oLista.IdExpedicionCustodia));
            oP.Add(new SqlParameter("@IDUSUARIO", oLista.IdUsuario));
            oP.Add(new SqlParameter("@DETALLE", oLista.Detalle));
            return (int)oSql.Escalar("EXI_U_ENTREGA_RESULTADO_MASIVO_PDA", oP);
        }

        public List<Objeto> rListarObjetoEntregaPDA(int IdExpedicion, int Tipo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@TIPO", Tipo));
            return (new sql()).TablaParametro<Objeto>("EXI_R_ENTREGA_OBJETOS_PDA", oP);
        }

        public int rEntregaAccionCONTAR(int IdExpedicion, int TipoEntrega, int EstadoEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@IDTIPOENTREGA", TipoEntrega));
            oP.Add(new SqlParameter("@IDESTADOENTREGA", EstadoEntrega));
            return (int)oSql.Escalar("EXI_R_ENTREGA_ACCION_CONTAR", oP);
        }

        public int uEntregaAccionMasivo(int IdExpedicion, int TipoEntrega, int EstadoEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@IDTIPOENTREGA", TipoEntrega));
            oP.Add(new SqlParameter("@IDESTADOENTREGA", EstadoEntrega));
            return (int)oSql.Escalar("EXI_U_ENTREGA_ACCION_MASIVO", oP);
        }
        public int uIniciaEntrega(int iBandeja, int iExpedicion, int iProceso)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@ENTREGA", ID));
            oP.Add(new SqlParameter("@USUARIO", IdUsuarioCreador));
            oP.Add(new SqlParameter("@BANDEJA", iBandeja));
            oP.Add(new SqlParameter("@EXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@PROCESO", iProceso));
            return Convert.ToInt32(oSql.Escalar("EXI_C_ENTREGA_INICIA", oP));
        }
        public int uCerrarEntregaPisos(int iUsuario, int iBandeja, int iExpedicion, int iProceso, int iMotivo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IID", ID));
            oP.Add(new SqlParameter("@USUARIO", iUsuario));
            oP.Add(new SqlParameter("@BANDEJA", iBandeja));
            oP.Add(new SqlParameter("@EXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@PROCESO", iProceso));
            oP.Add(new SqlParameter("@MOTIVO", iMotivo));
            return Convert.ToInt32(oSql.Escalar("EXI_C_ENTREGA_CIERRA3", oP));//<-------QUITAR 3
        }
        //2022
        public string rListaEntregas(int iExpedicion, int iTipoEntrega, int iModo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@IDTIPOENTREGA", iTipoEntrega));
            oP.Add(new SqlParameter("@IDMODO", iModo));
            return oSql.TablaParametroJSON("SIMIH_R_ENTREGA_LISTA", oP);
        }


        public int cCrearEntrega()
        {
            int iKey = 0;
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            if (ID > 0) oP.Add(new SqlParameter("@IDENTREGA", ID));
            if (ID == 0) oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", IdExpedicionOrigen));
            if (ID == 0) oP.Add(new SqlParameter("@IDCOLABORADOR", IdUsuarioCreador));
            oP.Add(new SqlParameter("@DETALLE", Detalle.Trim()));

            if (ID == 0)
                iKey = Convert.ToInt32(oSql.Escalar("EXI_C_ENTREGA_PISOS", oP));
            else
                iKey = Convert.ToInt32(oSql.Escalar("EXI_U_ENTREGA_PISOS", oP));

            return iKey;
        }
        //2022
        public List<string> rEntregaDetalle(int iEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", iEntrega));
            // DEVUELVE UNA LISTA DE CADENAS DE TEXTO EN FORMATO JSON - EL INDICE 0 DE LA LISTA CONTIENE EL REGISTRO DE LA ENTREGA (CABECERA) - EL INDICE 1 CONTIENE EL DETALLE DE LA ENTREGA (AUTOGENERADOS QUE PERTENECEN A LA ENTREGA)            
            List<string> lista = oSql.ListaTablaParametroJSON("SIMIH_ENTREGA_R_DETALLE", oP);
            return lista;
        }

        //2022
        public string ListarAutogeneradosEntregasSucursalRecibidas(int IdUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuario));
            return oSql.TablaParametroJSON("SIMIH_ENTREGASUCURSAL_R_AUTOGENERADOSRECEPCION", oP);
        }

        //2022
        public List<string> EntregaAgenciaDetalle(int IdGrupo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDGRUPO", IdGrupo));
            // DEVUELVE UNA LISTA DE CADENAS DE TEXTO EN FORMATO JSON - EL INDICE 0 DE LA LISTA CONTIENE EL REGISTRO DE LA ENTREGA (CABECERA) - EL INDICE 1 CONTIENE EL DETALLE DE LA ENTREGA (AUTOGENERADOS QUE PERTENECEN A LA ENTREGA)            
            List<string> lEntregaDetalle = oSql.ListaTablaParametroJSON("SIMIH_ENTREGA_R_GRUPO_AGENCIA", oP);
            return lEntregaDetalle;
        }


        public int uExportarImportarMovil(int opcion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", ID));
            oP.Add(new SqlParameter("@OPCION", opcion)); // 1 EXPORTAR  2 IMPORTAR
            return Convert.ToInt32(oSql.Escalar("EXI_U_ENTREGA_EXPORTAR_IMPORTAR_MOVIL", oP));
        }


        public int uIniciarEntregaPisos()
        {
            int iKey = 0;
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", ID));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicionOrigen));
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuarioCreador));
            oP.Add(new SqlParameter("@IDBANDEJA", idTipoValidacion));
            oP.Add(new SqlParameter("@DETALLE", Detalle.Trim()));
            iKey = Convert.ToInt32(oSql.Escalar("EXI_U_ENTREGA_PISOS_INICIA", oP));
            return iKey;
        }


        public int uTerminarEntregaPisos()
        {
            int iKey = 0;
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", ID));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicionOrigen));
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuarioCreador));
            iKey = Convert.ToInt32(oSql.Escalar("EXI_U_ENTREGA_PISOS_TERMINA", oP));
            return iKey;
        }


        public int cCrearEntregaSucursales(int iExpedicion, int iPalomar, int iUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", iExpedicion));
            oP.Add(new SqlParameter("@PALOMAR", iPalomar));
            oP.Add(new SqlParameter("@COLABORADOR", iUsuario));

            return Convert.ToInt32(oSql.Escalar("PC_ENTREGASUCURSAL_C_NUEVO", oP));

        }

        //2022
        public string rEntrega(int iEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", iEntrega));
            return (oSql.TablaParametroJSON("SIMIH_R_ENTREGA_ID", oP));
        }
        //2022
        public int uEntregaSucursal(int iEntrega, int iUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", iEntrega));
            oP.Add(new SqlParameter("@IDUSUARIO", iUsuario));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGASUCURSAL_U_ENTREGA", oP));
        }
        // Funcional - frmNuevaEntregaPisos
        public int cCrearEntregaPisos(int iExpedicion, int iUsuario, string Palomares, int iIdUsuarioLogeado)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", iExpedicion));
            oP.Add(new SqlParameter("@IDCOLABORADOR", iUsuario));
            oP.Add(new SqlParameter("@DETALLE", Palomares));
            oP.Add(new SqlParameter("@IDUSUARIO", iIdUsuarioLogeado));
            return Convert.ToInt32(oSql.Escalar("PC_ENTREGAPISOS_C_ENTREGA", oP));
        }
        //2022
        public int uValidaEntregaSucursal(int iEntrega, string sDetalle)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", iEntrega));
            oP.Add(new SqlParameter("@DETALLE", sDetalle));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGASUCURSAL_U_GUARDARCAMBIOS", oP));
        }
        //2022
        public int GuardarCambiosEntregaAgencias(int IdEntregaGrupo, string sDetalle)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGAGRUPO", IdEntregaGrupo));
            oP.Add(new SqlParameter("@DETALLE", sDetalle));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGASUCURSAL_U_GUARDARCAMBIOSGRUPO", oP));
        }


        //2022
        public int uRecargarEntregaSucursal(int iEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", iEntrega));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGASUCURSAL_U_RECARGARELEMENTOS", oP));
        }

        public int uRetirarEntregaSucursal(int iEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", iEntrega));
            return Convert.ToInt32(oSql.Escalar("PC_ENTREGASUCURSAL_D_RETIRARNOVALIDADOS", oP));

        }

        //2022
        public int uIniciarEntregaSucursal()
        {
            int iKey = 0;
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", ID));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicionOrigen));
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuarioCreador));
            oP.Add(new SqlParameter("@IDBANDEJA", idTipoValidacion));
            iKey = Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGASUCURSAL_U_INICIAR", oP));
            return iKey;
        }
        //2022
        public string rEntregaSucursalDestino(int iExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            return (oSql.TablaParametroJSON("SIMIH_ENTREGASUCURSAL_R_LISTARVALIJACUSTODIA", oP));
        }
        //2022
        public int dEliminarEntregaSucursal(int iEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", iEntrega));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGA_D_SELECCIONADA", oP));
        }
        //2022
        public int EliminarEntregasAgenciaVacias(int IdEntregaGrupo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGAGRUPO", IdEntregaGrupo));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAAGENCIA_D_GRUPO", oP));
        }

        //2022
        public int uModificaEntregaPisos(int idEntrega, int iUsuario, string detalle, int idexpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            oP.Add(new SqlParameter("@IDUSUARIO", iUsuario));
            oP.Add(new SqlParameter("@DETALLE", detalle));
            oP.Add(new SqlParameter("@IDEXPEDICION", idexpedicion));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAPISOS_U_ENTREGA", oP));
        }
        //2022
        public String refrescar(int modo, int idEntrega, Entrega oo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", oo.IdExpedicionOrigen));
            oP.Add(new SqlParameter("@IDTIPOENTREGA", idEntrega));
            oP.Add(new SqlParameter("@IDMODO", modo));
            oP.Add(new SqlParameter("@IDENTREGA", oo.ID));
            return oSql.TablaParametroJSON("SIMIH_R_ENTREGA_TOP1", oP);
        }
        //2022
        public int uEntregaPisosIniciar(int idEntrega, int idUsuario, int idExpedicion, int idBandeja)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@IDBANDEJA", idBandeja));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAPISOS_U_INICIAPISOS", oP));
        }
        //2022
        public int uEntregaPisosTerminar(int idEntrega, int idExpedicion, int idUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            return Convert.ToInt32(oSql.Escalar("SIMIH_U_ENTREGA_PISOS_TERMINAR", oP));
        }
        //2022
        public string uRecepcionEntregaSucursal(int iEntrega, int iExpedicion, int iUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", iEntrega));
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@IDUSUARIO", iUsuario));
            return oSql.TablaParametroJSON("SIMIH_ENTREGASUCURSAL_U_RECEPCIONARVALIJA", oP);
        }
        //2022
        public int CustodiaAutogeneradosEntregaSucursal(int iEntrega, int iUsuario, int iExpedicion, string sDetalle)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", iEntrega));
            oP.Add(new SqlParameter("@IDUSUARIO", iUsuario));
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@DETALLE", sDetalle));
            return Convert.ToInt32(oSql.Escalar("SIMIH_RECEPCIONVALIJASUCURSAL_U_CUSTODIARAUTOGENERADOS", oP));
        }
        //2022
        public int CustodiarAutogeneradosEntregasSucursal(int iUsuario, string sDetalle)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", iUsuario));
            oP.Add(new SqlParameter("@DETALLE", sDetalle));
            return Convert.ToInt32(oSql.Escalar("SIMIH_RECEPCIONVALIJASUCURSAL_U_CUSTODIARAUTOGENERADOSENTREGAS", oP));
        }
        //2022
        public int uGrabarEntregaPisos(string detalle, int idEntrega, int idgeo, int idbandeja, int idusuario, int idexpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DETALLE", detalle));
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            oP.Add(new SqlParameter("@IDGEO", idgeo));
            oP.Add(new SqlParameter("@IDBANDEJA", idbandeja));
            oP.Add(new SqlParameter("@IDUSUARIO", idusuario));
            oP.Add(new SqlParameter("@IDEXPEDICION", idexpedicion));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAPISOS_U_GRABAR", oP));
        }
        //2022
        public String rObtenerDocumentosPorEntregaJson(Interna.Entity.Entrega oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdEntrega", oO.ID));
            string json = oSql.TablaParametroJSON("SIMIH_R_ENTREGA_OBJETO", oP);
            return json;
        }

        public int rRefrescarEntregaPisos(Interna.Entity.Entrega oO)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", oO.ID));
            return Convert.ToInt32(oSql.Escalar("PEXI_REFRESCAR_ENTREGA_PISOS", oP));
        }
        public int rValidarObjetoEntregaPisos(String json, int idEntrega, DateTime fecha)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DETALLE", json));
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            return Convert.ToInt32(oSql.Escalar("PEXI_U_ENTREGA_OBJETO_PISOS", oP));
        }
        //2022
        public int rEliminarObjetoEntregaPisos(int idEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            return Convert.ToInt32(oSql.Escalar("SIMIH_U_ENTREGA_RETIRAR_NO_VALIDADOS", oP));
        }
        //2022
        public int rEliminarEntregaPisos(int idEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            return Convert.ToInt32(oSql.Escalar("SIMIH_D_ENTREGA_SUCURSAL", oP));
        }
        //2022
        public int uCerrarEntregaPisos1(int idEntrega, int idExpedicion, int idUsuario, int idBandeja, int idGeo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            oP.Add(new SqlParameter("@IDGEO", idGeo));
            oP.Add(new SqlParameter("@IDBANDEJA", idBandeja));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAPISOSRESULTADO_U_CERRARENTREGA", oP));
        }
        //2022
        public string rEntregaSucursalDestinoRuta(int iExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            return (oSql.TablaParametroJSON("SIMIH_ENTREGASUCURSAL_R_LISTARVALIJARUTA", oP));
        }
        //2022
        public int uGrabarCambioObjetoEntregaPisos(string detalle, int idEntrega, int idUsuario, int idBandeja, int idExpedicion, int idGeoCasilla, int Tipo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DETALLE", detalle));
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            oP.Add(new SqlParameter("@IDBANDEJA", idBandeja));
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@IDGEOCASILLA", idGeoCasilla));
            oP.Add(new SqlParameter("@TIPO", Tipo));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAPISOS_U_GRABAR_CAMBIOS", oP));
        }

        public int uEntregaPisosDesvalidarObjeto(int idObjeto, int idEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDOBJETO", idObjeto));
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            return Convert.ToInt32(oSql.Escalar("PEXI_U_ENTREGA_PISOS_DESVALIDAROBJETO", oP));
        }
        // Funcional - frmListaEntregaAgencia
        public string rEntregaAgencia(int iExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            return (oSql.TablaParametroJSON("PC_ENTREGAAGENCIA_R_LISTAR", oP));
        }
        //2022
        public string ListarEntregaGrupoAgencia(int iExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            return oSql.TablaParametroJSON("SIMIH_ENTREGAAGENCIA_R_GRUPO_LISTAR", oP);
        }

        public int cCrearEntregaAgencia(int iExpedicion, int iColaborador, int iPalomar, DateTime dFecha)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", iExpedicion));
            oP.Add(new SqlParameter("@COLABORADOR", iColaborador));
            oP.Add(new SqlParameter("@GRUPOPALOMAR", iPalomar));
            oP.Add(new SqlParameter("@FECHA", dFecha));

            return Convert.ToInt32(oSql.Escalar("PC_ENTREGAAGENCIA_C_CREARENTREGASPROGRAMADAS", oP));

        }
        //2022
        public int RecargarEntregaAgencia(int iEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGAGRUPO", iEntrega));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAAGENCIA_U_RECARGARELEMENTOSGRUPO", oP));
        }


        public int uIniciarEntregaAgencia(int iEntrega, int iExpedicion, int iUsuario, int iBandeja)
        {
            int iKey = 0;
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", iEntrega));
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@IDUSUARIO", iUsuario));
            oP.Add(new SqlParameter("@IDBANDEJA", iBandeja));
            iKey = Convert.ToInt32(oSql.Escalar("PEXI_U_ENTREGA_AGENCIA_INICIA", oP));
            return iKey;
        }

        public List<string> rEntregaAgenciaDetalle(int iEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", iEntrega));
            List<string> lEntregaDetalle = oSql.ListaTablaParametroJSON("PEXI_R_ENTREGA_AGENCIA_DETALLE", oP);
            return lEntregaDetalle;
        }

        public int uValidaEncasilladoMovil(int iEntrega, string sDetalleXml)
        {
            int iKey = 0;
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", iEntrega));
            oP.Add(new SqlParameter("@DETALLE", sDetalleXml));
            iKey = Convert.ToInt32(oSql.Escalar("PEXI_U_VALIDA_ENCASILLADO_MOVIL", oP));
            return iKey;
        }

        //2022
        public int uExportarImportarMovilModo(int opcion, int forma)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", ID));
            oP.Add(new SqlParameter("@IDFORMA", forma));
            oP.Add(new SqlParameter("@OPCION", opcion)); // 1 EXPORTAR  2 IMPORTAR

            return Convert.ToInt32(oSql.Escalar("SIMIH_U_ENTREGA_EXPORTAR_IMPORTAR_MOVIL_MODO", oP));
        }
        /*Benji Villarreal 25/02/2016*/
        public string rListarTipoEntregas()
        {
            return new sql().TablaJSON("PC_COMUN_R_LISTARTIPOENTREGA");
        }

        //2022
        public string rElementosPorRefrescar(int idEntrega)
        {
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            return new sql().TablaParametroJSON("SIMIH_ENTREGAPISOS_R_ELEMENTOSREFRESCADOS", lP);
        }
        //2022
        public int EliminarEntregaAgencia(string listaEntregas)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@LOTE", listaEntregas));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAAGENCIA_D_SELECCIONADAS", oP));
        }
        // Funcional - frmListaEntregaAgencias
        public int IniciarLoteEntregaAgencia(Usuario oUsuario, string xmlLote)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_USUARIO", oUsuario.ID));
            oP.Add(new SqlParameter("@ID_EXPEDICION", oUsuario.IdExpedicion));
            oP.Add(new SqlParameter("@ID_BANDEJA", oUsuario.idCasilla));
            oP.Add(new SqlParameter("@LOTE", xmlLote));
            return Convert.ToInt32(oSql.Escalar("PC_ENTREGAAGENCIA_U_INICIAR", oP));
        }
        //2022
        public int IniciarLoteAgenciasGrupo(Usuario oUsuario, string xmlLote)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_USUARIO", oUsuario.ID));
            oP.Add(new SqlParameter("@ID_EXPEDICION", oUsuario.IdExpedicion));
            oP.Add(new SqlParameter("@ID_BANDEJA", oUsuario.idCasilla));
            oP.Add(new SqlParameter("@LOTE", xmlLote));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAAGENCIA_U_INICIAR_LOTES", oP));
        }

        //2022
        public int EliminarEntregaPisosResultado(int idEntrega, int idExpedicion, int idUsuario, int idBandeja, int idGeo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            oP.Add(new SqlParameter("@IDGEO", idGeo));
            oP.Add(new SqlParameter("@IDBANDEJA", idBandeja));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAPISOS_D_RESULTADO", oP));
        }

        /*César Baltazar - 01/08/2016 */
        public string ListarEntregaAgenciaPorEstado(int iEstado, DateTime dDesde, DateTime dHasta)
        {
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IDESTADO", iEstado));
            lP.Add(new SqlParameter("@DESDE", dDesde));
            lP.Add(new SqlParameter("@HASTA", dHasta));
            return new sql().TablaParametroJSON("PC_ENTREGAAGENCIA_R_LISTARPORESTADO", lP);
        }

        //2022
        public string ListarEntregaAgenciaSeguimiento()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@idExpedicion", IdExpedicionOrigen));
            return oSql.TablaParametroJSON("SIMIH_ENTREGAAGENCIA_R_SEGUIMIENTO", lP);
        }
        // Funcional - frmEntregaPisosPrin
        public int rEstadoEntrega(int idEntrega)
        {
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ENTREGA", idEntrega));
            return Convert.ToInt32(new sql().Escalar("PC_ENTREGAPISOS_R_VERIFICARESTADOENTREGA", lP));
        }
        //2022
        public int CrearEntregaSucursal(Expedicion oExpedicion, Palomar oPalomar, Operario oColaborador, int idUsuarioCreador)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICIONORIGEN", oExpedicion.ID));
            oP.Add(new SqlParameter("@PALOMAR", oPalomar.ID));
            oP.Add(new SqlParameter("@COLABORADOR", oColaborador.ID));
            oP.Add(new SqlParameter("@IDUSUARIOCREADOR", idUsuarioCreador));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGASUCURSAL_C_NUEVO", oP));
        }
        //2022
        public string ListarEntregasSucursalesActivas()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicionOrigen));
            return oSql.TablaParametroJSON("SIMIH_ENTREGASUCURSAL_R_LISTAR_ACTIVOS", oP);
        }
        // Funcional - frmListaEntregaAgencias
        public int ModificarCantidadBultos()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdEntrega", ID));
            oP.Add(new SqlParameter("@ICantidadBultos", iCantidadBultos));
            return Convert.ToInt32(oSql.Escalar("PC_ENTREGAAGENCIA_U_CANTIDAD_BULTOS", oP));
        }

        public string ListarEntregasPorRecibirPorJOS(int iIdAgencia)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdAgencia", iIdAgencia));
            return oSql.TablaParametroJSON("WEB_JOS_R_ENTREGAS_POR_RECIBIR", oP);
        }

        public string ListarEntregaDetalleJOS()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdEntrega", ID));
            return oSql.TablaParametroJSON("WEB_JOS_R_ENTREGA_DETALLE", oP);
        }


        public string ListarEntregasCerradasJOS(int iIdAgencia, string dFechaInicio, string dFechaFin)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdAgencia", iIdAgencia));
            oP.Add(new SqlParameter("@FechaInicio", dFechaInicio));
            oP.Add(new SqlParameter("@FechaFin", dFechaFin));
            return oSql.TablaParametroJSON("WEB_JOS_R_ENTREGAS_CERRADAS", oP);
        }

        public string ListarEntregaDetalleCerradasJOS()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdEntrega", ID));
            return oSql.TablaParametroJSON("WEB_JOS_R_ENTREGA_DETALLE_CERRADAS", oP);
        }

        //2023
        public int GrabarCambiosEntregaAgencias(int IdEntregaGrupo, string elementosJson)
        {
            List<ObjetoAgencia> objetoAgencias = JsonConvert.DeserializeObject<List<ObjetoAgencia>>(elementosJson, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            Objeto objeto = new Objeto();
            string detalleXml = objeto.SerializeObjectWindows(objetoAgencias);

            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGAGRUPO", IdEntregaGrupo));
            oP.Add(new SqlParameter("@DETALLE", detalleXml));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAAGENCIA_U_GUARDARCAMBIOSGRUPO", oP));
        }

        //2023
        public int RecargarElementosEntregaAgencia(int idEntregaGrupo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGAGRUPO", idEntregaGrupo));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAAGENCIA_U_RECARGAR_ELEMENTOS_GRUPO", oP));
        }
    }
}