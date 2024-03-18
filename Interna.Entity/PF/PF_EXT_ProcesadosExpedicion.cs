using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_EXT_ProcesadosExpedicion : PF_Entity
    {
        #region Propiedades
        [DataMember]
        public int documentosLima { get; set; }

        [DataMember]
        public int documentosProvincia { get; set; }

        [DataMember]
        public int documentosExterior { get; set; }

        [DataMember]
        public int tokenExterior { get; set; }

        [DataMember]
        public int notasAbono { get; set; }

        [DataMember]
        public int pagares { get; set; }

        [DataMember]
        public int documentosSerpost { get; set; }

        [DataMember]
        public int detracciones { get; set; }

        [DataMember]
        public int retenciones { get; set; }

        [DataMember]
        public int priorityPass { get; set; }

        [DataMember]
        public int auditoriasRealizadas { get; set; }
        #endregion

        #region Metodos
        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID_PERIODO", iIdPeriodo));
            lP.Add(new SqlParameter("@DOCUMENTOS_LIMA", documentosLima));
            lP.Add(new SqlParameter("@DOCUMENTOS_PROVINCIA", documentosProvincia));
            lP.Add(new SqlParameter("@DOCUMENTOS_EXTERIOR", documentosExterior));
            lP.Add(new SqlParameter("@TOKEN_EXTERIOR", tokenExterior));
            lP.Add(new SqlParameter("@NOTAS_ABONO", notasAbono));
            lP.Add(new SqlParameter("@PAGARES", pagares));
            lP.Add(new SqlParameter("@DOCUMENTOS_SERPOST", documentosSerpost));
            lP.Add(new SqlParameter("@DETRACCIONES", detracciones));
            lP.Add(new SqlParameter("@RETENCIONES", retenciones));
            lP.Add(new SqlParameter("@PRIORITY_PASS", priorityPass));
            lP.Add(new SqlParameter("@AUDITORIAS_REALIZADAS", auditoriasRealizadas));
            return Convert.ToInt32(oSql.Escalar("PF_EXT_PROCESADOSEXPEDICION_U_ACTUALIZARPERIODO", lP));
        }
        #endregion
    }
}
