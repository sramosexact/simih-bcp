using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;


namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class CampoDigitalizacion : Core.Entity
    {

        #region Propiedades

        [DataMember]
        public int iIdCampoDigitalizacion { get; set; }

        [DataMember]
        public Int16 iIdTipoDocumento { get; set; }

        [DataMember]
        public string sDescripcion { get; set; }

        [DataMember]
        public int iActivo { get; set; }

        [DataMember]
        public int iIdentificador { get; set; }

        public string sIdentificador
        {
            get
            {
                return iIdentificador == 1 ? "SÍ" : "NO";
            }
        }

        public string sActivo
        {
            get
            {
                return iActivo == 1 ? "SÍ" : "NO";
            }
        }

        [DataMember]
        public bool opcional { get; set; }

        public string sOpcional
        {
            get
            {
                return opcional ? "SI" : "NO";
            }
        }




        #endregion

        #region Metodos
        public string ListarCamposPorTipoDocumento(TipoDocumento oTipoDocumento)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdTipoDocumento", oTipoDocumento.iIdTipoDocumento));
            return oSql.TablaParametroJSON("PC_MESAPARTES_R_CAMPOS_POR_TIPO_DOCUMENTO", lP);
        }

        public string ListarCamposActivosPorTipoDocumento(TipoDocumento oTipoDocumento)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdTipoDocumento", oTipoDocumento.iIdTipoDocumento));
            return oSql.TablaParametroJSON("PC_MESAPARTES_R_CAMPOS_ACTIVOS_POR_TIPO_DOCUMENTO", lP);
        }



        #endregion
    }
}
