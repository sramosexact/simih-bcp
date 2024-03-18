using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class CampoTipoDocumento : Interna.Core.Entity, Interfaces.ICampoTipoDocumento
    {
        #region Propiedades

        [DataMember]
        public int iIdCampoTipoDocumento { get; set; }
        [DataMember]
        public Int16 iIdTipoDocumento { get; set; }
        [DataMember]
        public string sNombreCampoTipoDocumento { get; set; }
        [DataMember]
        public string sDescripcionCampoTipoDocumento { get; set; }
        #endregion


        #region Metodos

        public string ListarCamposTipoDocumento()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdTipoDocumento", iIdTipoDocumento));
            return oSql.TablaParametroJSON("PC_MESAPARTES_R_LISTAR_CAMPOS_TIPO_DOCUMENTO", lP);
        }

        #endregion

    }
}
