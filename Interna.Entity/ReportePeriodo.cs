using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ReportePeriodo : Core.Entity
    {
        #region Propiedades

        [DataMember]
        public int iIdPeriodo { get; set; }

        [DataMember]
        public int iIdReportePeriodo { get; set; }

        [DataMember]
        public string sDescripcionReporte { get; set; }

        [DataMember]
        public bool bCumple { get; set; }

        #endregion

        #region Metodos

        public ReportePeriodo()
        { }

        public ReportePeriodo(int iIdPeriodo)
        {
            this.iIdPeriodo = iIdPeriodo;
        }

        public string ListarReportesPeriodo()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            return oSql.TablaParametroJSON("PC_REPORTEPERIODO_R_LISTAR_REPORTE_PERIODO", lP);
        }

        public int ActualizarReportesPeriodo(string sListaReportesPeriodo)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@sListaEstadosReporte", sListaReportesPeriodo));
            return Convert.ToInt32(oSql.Escalar("PC_REPORTEPERIODO_U_ACTUALIZAR", lP));
        }

        #endregion
    }
}
