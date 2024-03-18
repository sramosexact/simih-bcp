using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;


namespace Interna.Entity
{

    [Serializable]
    [DataContract]
    public class CampoExterno : Core.Entity
    {
        #region Propiedades

        [DataMember]
        public int iIdCampoExterno { get; set; }

        [DataMember]
        public int iIdCampoDigitalizacion { get; set; }

        [DataMember]
        public int iIdDocumento { get; set; }

        [DataMember]
        public string sValor { get; set; }

        [DataMember]
        public string sDescripcionCampoExterno { get; set; }


        #endregion

        // Funcional - frmDocumentosProcesados
        public string ListarDetalleDocumento(int IdDocumento)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdDocumento", IdDocumento));
            return new sql().TablaParametroJSON("PC_MESAPARTES_R_DETALLE_DOCUMENTO", lP);
        }

    }
}
