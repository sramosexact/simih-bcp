using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class TipoDocumento : Core.Entity, Interfaces.ITipoDocumento
    {
        #region Propiedades

        [DataMember]
        public Int16 iIdTipoDocumento { get; set; }
        [DataMember]
        public String sDescripcionTipoDocumento { get; set; }
        [DataMember]
        public Byte iIdTipoCorrespondencia { get; set; }
        [DataMember]
        public Byte iMoneda { get; set; }

        [DataMember]
        public bool requiereDigitalizacion { get; set; }

        [DataMember]
        public bool entregaPersonalizada { get; set; }

        #endregion

        #region Metodos
        //2022
        public string ListarTipoDocumentoRegistrados()
        {
            return new sql().TablaJSON("SIMIH_MANTENIMIENTOTIPODOCUMENTO_R_REGISTRADOS");
        }
        //2022
        public string ListarTipoDocumentoPorTipoCorrespondenciaMesaDePartes(int IdTipoCorrespondencia)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IDTIPOCORRESPONDENCIA", IdTipoCorrespondencia));
            return oSql.TablaParametroJSON("SIMIH_MESAPARTES_R_TIPODOCUMENTO_POR_TIPOCORRESPONDENCIA", lP);
        }
        //2022
        public int RegistrarTipoDocumento()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@DESCRIPCION", sDescripcionTipoDocumento));
            lP.Add(new SqlParameter("@IDTIPOCORRESPONDENCIA", iIdTipoCorrespondencia));
            lP.Add(new SqlParameter("@ITIPOVALOR", iMoneda));
            lP.Add(new SqlParameter("@ENTREGAPERSONALIZADA", entregaPersonalizada));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOTIPODOCUMENTO_C_REGISTRAR", lP));

        }
        //2022
        public int ModificarTipoDocumento()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID", iIdTipoDocumento));
            lP.Add(new SqlParameter("@DESCRIPCION", sDescripcionTipoDocumento));
            lP.Add(new SqlParameter("@IDTIPOCORRESPONDENCIA", iIdTipoCorrespondencia));
            lP.Add(new SqlParameter("@ITIPOVALOR", iMoneda));
            lP.Add(new SqlParameter("@ENTREGAPERSONALIZADA", entregaPersonalizada));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOTIPODOCUMENTO_U_MODIFICAR", lP));
        }

        //2022
        public int AsociarModulo(ModuloCreacion oModulo, Casilla oCasilla, string camposJson)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdModuloCreacion", oModulo.iId));
            lP.Add(new SqlParameter("@IdTipoDocumento", iIdTipoDocumento));
            lP.Add(new SqlParameter("@iIdCasilla", oCasilla.ID));
            lP.Add(new SqlParameter("@requiereDigitalizacion", requiereDigitalizacion));
            lP.Add(new SqlParameter("@sCampos", camposJson));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOTIPODOCUMENTO_C_ASOCIAR_MODULO", lP));
        }
        //2022
        public int QuitarAsociacionModulo(int IdModulo, int IdTipoDocumento)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdModuloCreacion", IdModulo));
            lP.Add(new SqlParameter("@IdTipoDocumento", IdTipoDocumento));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOTIPODOCUMENTO_D_QUITAR_ASOCIACION_MODULO", lP));
        }

        public string ListarBandejasPorAsociarAlTipoDocumento(Casilla casilla)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@sDescripcionCasilla", casilla.sDescripcion));
            return oSql.TablaParametroJSON("PC_MANTENIMIENTOTIPODOCUMENTO_R_CASILLA_POR_ASOCIAR", lP);
        }


        public string ListarTipoDocumentoDigital()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("PC_MESAPARTES_R_TIPODOCUMENTODIGITAL");
        }

        public int EditarCamposDocumentosEspeciales(string camposJson)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdTipoDocumento", iIdTipoDocumento));
            lP.Add(new SqlParameter("@requiereDigitalizacion", requiereDigitalizacion));
            lP.Add(new SqlParameter("@sCampos", camposJson));
            return Convert.ToInt32(oSql.Escalar("PC_MANTENIMIENTOTIPODOCUMENTO_U_EDITARCAMPOS", lP));
        }

        public static string ListarTipoDocumentoSinDigitalizacion()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("PC_MESAPARTES_R_TIPO_DOCUMENTO_SIN_DIGITALIZACION");
        }
        #endregion


    }
}
