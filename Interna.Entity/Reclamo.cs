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
    public class Reclamo : Interna.Core.Entity
    {
        #region Propiedades
        [DataMember]
        public int iIdReclamo { get; set; }
        [DataMember]
        public int iIdUsuario { get; set; }
        [DataMember]
        public byte iIdTipoReclamoUsuario { get; set; }
        [DataMember]
        public string sDocReferencia { get; set; }
        [DataMember]
        public string sDetalle { get; set; }
        [DataMember]
        public byte iIdEstadoReclamo { get; set; }

        [DataMember]
        public DateTime dFechaRegistro { get; set; }


        private string fechaRegistroJson = "0001-01-01";

        [DataMember]
        public string FechaRegistroJson
        {
            get { return fechaRegistroJson; }
            set
            {
                dFechaRegistro = DateTime.Parse(value);
                fechaRegistroJson = value;
            }
        }

        [DataMember]
        public DateTime dFechaAtencion { get; set; }

        private string fechaAtencionJson = "0001-01-01";

        [DataMember]
        public string FechaAtencionJson
        {
            get { return fechaAtencionJson; }
            set
            {
                dFechaAtencion = DateTime.Parse(value);
                fechaAtencionJson = value;
            }
        }
        [DataMember]
        public int iIdUsuarioAtencion { get; set; }
        [DataMember]
        public byte iFundado { get; set; }
        [DataMember]
        public byte iIdTipoReclamoUTD { get; set; }
        [DataMember]
        public byte iIdTipoResponsable { get; set; }
        [DataMember]
        public string sPersonaResponsable { get; set; }
        [DataMember]
        public string sCausa { get; set; }
        [DataMember]
        public string sAccionInmediata { get; set; }

        [DataMember]
        public DateTime dFechaSolucion { get; set; }

        private string fechaSolucionJson = "0001-01-01";

        [DataMember]
        public string FechaSolucionJson
        {
            get { return fechaSolucionJson; }
            set
            {
                dFechaSolucion = DateTime.Parse(value);
                fechaSolucionJson = value;
            }
        }

        [DataMember]
        public DateTime dFechaVerificacion { get; set; }

        private string fechaVerificacionJson = "0001-01-01";

        [DataMember]
        public string FechaVerificacionJson
        {
            get { return fechaVerificacionJson; }
            set
            {
                dFechaVerificacion = DateTime.Parse(value);
                fechaVerificacionJson = value;
            }
        }


        [DataMember]
        public byte iIdEstadoVerificacion { get; set; }
        [DataMember]
        public byte iObservado { get; set; }
        [DataMember]
        public byte iCalificacion { get; set; }

        [DataMember]
        public byte iIdTipoReclamoJefe { get; set; }

        [DataMember]
        public string sObservacion { get; set; }

        [DataMember]
        public string sSolucion { get; set; }

        [DataMember]
        public int iCorreccion { get; set; }

        [DataMember]
        public string sCorreccion { get; set; }


        #endregion

        #region Constructor

        public Reclamo() { }

        public Reclamo(int iIdReclamo)
        {
            this.iIdReclamo = iIdReclamo;
        }

        public Reclamo(int iIdReclamo, int iIdUsuario)
        {
            this.iIdReclamo = iIdReclamo;
            this.iIdUsuario = iIdUsuario;
        }

        public Reclamo(int iIdUsuario, byte iIdTipoReclamoUsuario, string sDocReferencia, string sDetalle)
        {
            this.iIdUsuario = iIdUsuario;
            this.iIdTipoReclamoUsuario = iIdTipoReclamoUsuario;
            this.sDocReferencia = sDocReferencia;
            this.sDetalle = sDetalle;
        }

        #endregion

        #region Metodos



        public int RegistrarReclamo()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdUsuario", iIdUsuario));
            oP.Add(new SqlParameter("@iIdTipoReclamoUsuario", iIdTipoReclamoUsuario));
            oP.Add(new SqlParameter("@sDocumento", sDocReferencia));
            oP.Add(new SqlParameter("@sDetalle", sDetalle));
            return (int)oSql.Escalar("WEB_RECLAMO_REGISTRAR_RECLAMO", oP);
        }

        public int RegistrarReclamoDesdeUTD()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdUsuario", iIdUsuario));
            oP.Add(new SqlParameter("@iIdUsuarioAtencion", iIdUsuarioAtencion));
            oP.Add(new SqlParameter("@iIdTipoReclamoUsuario", iIdTipoReclamoUsuario));
            oP.Add(new SqlParameter("@sDocumento", sDocReferencia));
            oP.Add(new SqlParameter("@sDetalle", sDetalle));
            oP.Add(new SqlParameter("@dFechaAtencion", dFechaAtencion));
            oP.Add(new SqlParameter("@dFechaRegistro", dFechaRegistro));
            return (int)oSql.Escalar("PC_RECLAMO_C_REGISTRAR_RECLAMO", oP);
        }

        public string ListarReclamoUsuario()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdUsuario", iIdUsuario));
            return oSql.TablaParametroJSON("WEB_RECLAMO_LISTAR_RECLAMO_USUARIO", lP);
        }

        public string ListarReclamoPorExpedicion(int iIdExpedicion)
        {
            sql oSql = new sql();
            //byte[] llave = Encoding.ASCII.GetBytes(File.ReadAllText(ConfigurationManager.AppSettings["rutaLlave"].ToString()));
            Encryption.Encrypt encrypt = new Encryption.Encrypt();

            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdExpedicion", iIdExpedicion));
            List<Dictionary<string, object>> Encriptados = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(oSql.TablaParametroJSON("PC_RECLAMO_LISTAR_RECLAMOS_POR_EXPEDICION", lP));
            List<Dictionary<string, object>> Desencriptados = encrypt.Desencriptar(Encriptados, "sUsuarioCliente");

            return JsonConvert.SerializeObject(Desencriptados);
        }

        public string ListarDetalleReclamo()
        {
            sql oSql = new sql();
            //byte[] llave = Encoding.ASCII.GetBytes(File.ReadAllText(ConfigurationManager.AppSettings["rutaLlave"].ToString()));
            Encryption.Encrypt encrypt = new Encryption.Encrypt();

            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdReclamo", iIdReclamo));
            List<Dictionary<string, object>> Encriptados = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(oSql.TablaParametroJSON("PC_RECLAMO_LISTAR_DETALLE_RECLAMO", lP));
            List<Dictionary<string, object>> Desencriptados = encrypt.Desencriptar(Encriptados, "sUsuarioCliente");

            return JsonConvert.SerializeObject(Desencriptados);
        }

        public int RegistrarPrimeraRespuesta()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdUsuario", iIdUsuario));
            oP.Add(new SqlParameter("@iIdReclamo", iIdReclamo));
            return (int)oSql.Escalar("PC_RECLAMO_REGISTRAR_PRIMERA_RESPUESTA", oP);
        }

        public int RegistrarSolucion()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdReclamo", iIdReclamo));
            oP.Add(new SqlParameter("@iFundado", iFundado));
            oP.Add(new SqlParameter("@iIdTipoReclamoUTD", iIdTipoReclamoUTD));
            oP.Add(new SqlParameter("@sAccion", sAccionInmediata));
            oP.Add(new SqlParameter("@sCausa", sCausa));
            oP.Add(new SqlParameter("@iIdTipoResponsable", iIdTipoResponsable));
            oP.Add(new SqlParameter("@sResponsable", sPersonaResponsable));
            oP.Add(new SqlParameter("@sSolucion", sSolucion));
            return (int)oSql.Escalar("PC_RECLAMO_REGISTRAR_SOLUCION", oP);

        }

        public string ListarReclamosSolucionadosPorTipoReclamoUTDYExpedicion(int iIdExpedicion)
        {
            sql oSql = new sql();
            //byte[] llave = Encoding.ASCII.GetBytes(File.ReadAllText(ConfigurationManager.AppSettings["rutaLlave"].ToString()));
            Encryption.Encrypt encrypt = new Encryption.Encrypt();

            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdTipoReclamoUTD", iIdTipoReclamoUTD));
            oP.Add(new SqlParameter("@iIdExpedicion", iIdExpedicion));
            oP.Add(new SqlParameter("@dPeriodo", dFechaRegistro));

            List<Dictionary<string, object>> Encriptados = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(oSql.TablaParametroJSON("PC_RECLAMO_R_LISTAR_RECLAMOS_SOLUCIONADOS_POR_TIPORECLAMOUTD_Y_EXPEDICION", oP));
            List<Dictionary<string, object>> Desencriptados = encrypt.Desencriptar(Encriptados, "sUsuarioCliente", "sUsuarioAtencion");
            return JsonConvert.SerializeObject(Desencriptados);

            //return oSql.TablaParametroJSON("PC_RECLAMO_R_LISTAR_RECLAMOS_SOLUCIONADOS_POR_TIPORECLAMOUTD_Y_EXPEDICION", oP);
        }

        public int RegistrarVerificacion()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdReclamo", iIdReclamo));
            oP.Add(new SqlParameter("@iIdEstadoVerificacion", iIdEstadoVerificacion));
            oP.Add(new SqlParameter("@iCalificacion", iCalificacion));
            oP.Add(new SqlParameter("@iIdTipoReclamoJefe", iIdTipoReclamoJefe));
            oP.Add(new SqlParameter("@iObservado", iObservado));
            oP.Add(new SqlParameter("@sObservacion", sObservacion));
            return (int)oSql.Escalar("PC_RECLAMO_U_REGISTRAR_VERIFICACION", oP);
        }
        // Funcional - frmReporteReclamosAnalista
        public string GenerarReportePorPeriodo()
        {
            sql oSql = new sql();
            //byte[] llave = Encoding.ASCII.GetBytes(File.ReadAllText(ConfigurationManager.AppSettings["rutaLlave"].ToString()));
            Encryption.Encrypt encrypt = new Encryption.Encrypt();

            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@PERIODO", dFechaRegistro));

            List<Dictionary<string, object>> Encriptados = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(oSql.TablaParametroJSON("PC_CONSULTASYREPORTES_R_RECLAMOS_POR_PERIODO", oP));
            List<Dictionary<string, object>> Desencriptados = encrypt.Desencriptar(Encriptados, "sUsuarioCliente", "sUsuarioAtencion");

            return JsonConvert.SerializeObject(Desencriptados);
        }

        public int MarcarReclamoPorCorregir()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdReclamo", iIdReclamo));
            return (int)oSql.Escalar("PC_RECLAMO_U_MARCAR_RECLAMO_POR_CORREGIR", oP);
        }

        public int GuardarCorreccion()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdReclamo", iIdReclamo));
            oP.Add(new SqlParameter("@sCorreccion", sCorreccion));
            return (int)oSql.Escalar("PC_RECLAMO_U_GUARDAR_CORRECCION", oP);
        }

        public string ListarReclamosPorRangoDeFecha(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DFECHAINICIO", dFechaInicial));
            oP.Add(new SqlParameter("@DFECHAFIN", dFechaFinal));
            return oSql.TablaParametroJSON("WEB_REPORTES_LISTAR_DETALLE_MOTIVOS_RECLAMOS", oP);
        }

        #endregion
    }
}
