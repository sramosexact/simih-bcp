using Interna.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Documento : Core.Entity
    {
        #region Propiedades
        [DataMember]
        public int iId { get; set; }
        [DataMember]
        public int iIdEstado { get; set; }
        [DataMember]
        public int iIdCasillaDe { get; set; }
        [DataMember]
        public int iIdCasillaPara { get; set; }
        [DataMember]
        public int iIdUsuarioCreador { get; set; }
        [DataMember]
        public int iIdEmpaque { get; set; }
        [DataMember]
        public int iIdTipoDocumento { get; set; }
        [DataMember]
        public string sCodigoDocumento { get; set; }
        [DataMember]
        public string sProcedencia { get; set; }
        [DataMember]
        public string sObservacion { get; set; }
        [DataMember]
        public int iMoneda { get; set; }
        [DataMember]
        public decimal iMonto { get; set; }
        [DataMember]
        public string sNombreImagen { get; set; }
        [DataMember]
        public Image imagen { get; set; }


        [DataMember]
        public string Usuario { get; set; }
        [DataMember]
        public string Empaque { get; set; }
        [DataMember]
        public string TipoDocumento { get; set; }
        [DataMember]
        public string Moneda { get; set; }
        [DataMember]
        public string CasillaDe { get; set; }
        [DataMember]
        public string CasillaPara { get; set; }
        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string Descripcion { get; set; }


        public DateTime FechaRegistro { get; set; }
        private string _fechaRegistroJson = "0001-01-01";
        [DataMember]
        public string FechaRegistroJSON
        {
            get
            {
                return _fechaRegistroJson;
            }
            set
            {
                FechaRegistro = DateTime.Parse(value);
                _fechaRegistroJson = value;
            }
        }

        [DataMember]
        public string Autogenerado { get; set; }

        [DataMember]
        public bool requiereDigitalizacion { get; set; }

        #endregion

        #region Metodos

        public string RegistrarDocumento(bool RequiereAutogenerado, int IdDocumentoRechazado)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdOrigen", iIdCasillaDe));
            lP.Add(new SqlParameter("@IdDestino", iIdCasillaPara));
            lP.Add(new SqlParameter("@IdUsuario", iIdUsuarioCreador));
            lP.Add(new SqlParameter("@IdTipoDocumento", iIdTipoDocumento));
            lP.Add(new SqlParameter("@Procedencia", sProcedencia));
            lP.Add(new SqlParameter("@Observacion", sObservacion));
            lP.Add(new SqlParameter("@Moneda", iMoneda));
            lP.Add(new SqlParameter("@Monto", iMonto));
            lP.Add(new SqlParameter("@NombreImagen", sNombreImagen));
            lP.Add(new SqlParameter("@campos", Descripcion));
            lP.Add(new SqlParameter("@Empaque", iIdEmpaque));
            lP.Add(new SqlParameter("@RequiereAutogenerado", RequiereAutogenerado));
            lP.Add(new SqlParameter("@IdDocumentoRechazado", IdDocumentoRechazado));
            return oSql.TablaParametroJSON("PC_MESAPARTES_C_DOCUMENTOS", lP);
            //return Convert.ToInt32(oSql.Escalar("PC_MESAPARTES_C_DOCUMENTOS", lP));
        }
        // Funcional - frmDocumentosProcesados
        public string ListarDocumentosRegistrados()
        {
            return new sql().TablaJSON("PC_MESAPARTES_R_DOCUMENTOSREGISTRADOS");
        }

        public string ListarDocumentosAsociados()
        {
            return new sql().TablaJSON("PC_MESAPARTES_R_DOCUMENTOSASOCIADOS");
        }

        public string ListarDocumentosRechazados()
        {
            return new sql().TablaJSON("PC_MESAPARTES_R_DOCUMENTOSRECHAZADOS");
        }

        public int RecibirRechazarDocumento()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdDocumento", iId));
            lP.Add(new SqlParameter("@IdEstado", iIdEstado));
            lP.Add(new SqlParameter("@IdUsuario", iIdUsuarioCreador));
            return Convert.ToInt32(oSql.Escalar("PC_MESAPARTES_U_RECIBIR_RECHAZAR_DOCUMENTO", lP));
        }
        // frmDocumentoSeguimiento
        public string ListarSeguimientoDocumento(int IdDocumento)
        {
            sql oSql = new sql();
            //byte[] llave = Encoding.ASCII.GetBytes(File.ReadAllText(ConfigurationManager.AppSettings["rutaLlave"].ToString()));
            Encryption.Encrypt encrypt = new Encryption.Encrypt();

            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdDocumento", IdDocumento));

            List<Dictionary<string, object>> Encriptados = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(oSql.TablaParametroJSON("PC_MESAPARTES_R_SEGUIMIENTO_DOCUMENTO", lP));
            List<Dictionary<string, object>> Desencriptados = encrypt.Desencriptar(Encriptados, "Usuario");

            return JsonConvert.SerializeObject(Desencriptados);
        }
        // Funcional - frmDocumentosProcesados
        public string ListarDocumentosHistoricos(DateTime FechaDesde, DateTime FechaHasta)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@FechaDesde", FechaDesde));
            lP.Add(new SqlParameter("@FechaHasta", FechaHasta));
            return new sql().TablaParametroJSON("PC_MESAPARTES_R_DOCUMENTOSHISTORICOS", lP);
        }

        public int ModificarDocumento()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@Id", iId));
            lP.Add(new SqlParameter("@IdOrigen", iIdCasillaDe));
            lP.Add(new SqlParameter("@IdDestino", iIdCasillaPara));
            lP.Add(new SqlParameter("@IdUsuario", iIdUsuarioCreador));
            lP.Add(new SqlParameter("@IdTipoDocumento", iIdTipoDocumento));
            lP.Add(new SqlParameter("@CodigoDocumento", sCodigoDocumento));
            lP.Add(new SqlParameter("@Procedencia", sProcedencia));
            lP.Add(new SqlParameter("@Observacion", sObservacion));
            lP.Add(new SqlParameter("@Moneda", iMoneda));
            lP.Add(new SqlParameter("@Monto", iMonto));
            lP.Add(new SqlParameter("@NombreImagen", sNombreImagen));
            return Convert.ToInt32(oSql.Escalar("PC_MESAPARTES_U_DOCUMENTOS", lP));
        }

        public string ListarDocumentosActivosDigitalizacion(int idCasilla)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            return new sql().TablaParametroJSON("WEB_DIGITALIZACION_R_LISTAR_DOCUMENTOS_ACTIVOS", lP);
        }

        public string ListarDocumentosHistoricosDigitalizacion(int idCasilla, DateTime FechaDesde, DateTime FechaHasta)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            lP.Add(new SqlParameter("@FechaDesde", FechaDesde));
            lP.Add(new SqlParameter("@FechaHasta", FechaHasta));
            return new sql().TablaParametroJSON("WEB_DIGITALIZACION_R_LISTAR_DOCUMENTOS_HISTORICOS", lP);

        }

        public int RecibirRechazarDocumentoDigitalizado(int iIdDocumento, int iIdUsuario, int iIdCasilla, int accion, string motivo)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdDocumento", iIdDocumento));
            lP.Add(new SqlParameter("@iIdUsuario", iIdUsuario));
            lP.Add(new SqlParameter("@iIdCasilla", iIdCasilla));

            if (accion == 1)
            {
                return Convert.ToInt32(oSql.Escalar("WEB_DIGITALIZACION_U_RECIBIR_DOCUMENTO", lP));
            }

            lP.Add(new SqlParameter("@motivo", motivo.Trim().ToUpper()));
            return Convert.ToInt32(oSql.Escalar("WEB_DIGITALIZACION_U_RECHAZAR_DOCUMENTO", lP));
        }


        public int RegistrarDocumentosEspecialesMasivo(bool RequiereAutogenerado)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdOrigen", iIdCasillaDe));
            lP.Add(new SqlParameter("@IdDestino", iIdCasillaPara));
            lP.Add(new SqlParameter("@IdUsuario", iIdUsuarioCreador));
            lP.Add(new SqlParameter("@IdTipoDocumento", iIdTipoDocumento));
            lP.Add(new SqlParameter("@Procedencia", sProcedencia));
            lP.Add(new SqlParameter("@Observacion", sObservacion));
            lP.Add(new SqlParameter("@Moneda", iMoneda));
            lP.Add(new SqlParameter("@Monto", iMonto));
            lP.Add(new SqlParameter("@NombreImagen", sNombreImagen));
            lP.Add(new SqlParameter("@campos", Descripcion));
            lP.Add(new SqlParameter("@Empaque", iIdEmpaque));
            lP.Add(new SqlParameter("@RequiereAutogenerado", RequiereAutogenerado));
            return Convert.ToInt32(oSql.Escalar("PC_MESAPARTES_C_DOCUMENTOS_ESPECIALES_MASIVO", lP));
        }


        #endregion
    }
}
