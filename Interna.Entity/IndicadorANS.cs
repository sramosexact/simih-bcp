using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class IndicadorANS : Core.Entity
    {
        #region Propiedades

        [DataMember]
        public int iId { get; set; }

        [DataMember]
        public string sDescripcion { get; set; }

        [DataMember]
        public string sUnidadMedida { get; set; }

        [DataMember]
        public string sPeligro { get; set; }

        [DataMember]
        public string sMeta { get; set; }

        [DataMember]
        public string sUltimoPeriodo { get; set; }

        [DataMember]
        public string sPenultimoPeriodo { get; set; }

        [DataMember]
        public string sAntepenultimoPeriodo { get; set; }

        #endregion

        #region Metodos

        public string ListarIndicadores(int iIdPeriodo)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            return oSql.TablaParametroJSON("PC_REPORTE_ANS_R_RESUMEN", lP);
        }

        public string ListarGestionOportunaDetalle(int iIdPeriodo)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            return oSql.TablaParametroJSON("PC_REPORTE_ANS_R_GESTION_OPORTUNA_DETALLE", lP);
        }

        public string ListarEfectividadEntregaDetalle(int iIdPeriodo)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            return oSql.TablaParametroJSON("PC_REPORTE_ANS_R_EFECTIVIDAD_ENTREGA_DETALLE", lP);
        }

        public string ListarProcesadosMesaPartesDetalle(int iIdPeriodo)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            return oSql.TablaParametroJSON("PC_REPORTE_ANS_R_PROCESADOS_MESA_PARTES_DETALLE", lP);
        }

        public string ListarReportesDeServiciosDetalle(int iIdPeriodo)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            return oSql.TablaParametroJSON("PC_REPORTE_ANS_R_REPORTES_DE_SERVICIOS_DETALLE", lP);
        }

        #endregion
    }
}
