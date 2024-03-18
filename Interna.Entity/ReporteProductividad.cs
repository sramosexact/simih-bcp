using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ReporteProductividad : Core.Entity
    {
        #region Propiedades

        [DataMember]
        public string servicio { get; set; }
        [DataMember]
        public string categoria { get; set; }
        [DataMember]
        public string criterio { get; set; }
        [DataMember]
        public string fecha { get; set; }
        [DataMember]
        public string tipoItem { get; set; }
        [DataMember]
        public string cantidadItem { get; set; }

        [DataMember]
        public string totalHorasEmpleadas { get; set; }

        [DataMember]
        public string cantidadPersonalRequerido { get; set; }

        #endregion

        #region Metodos

        public static string ReporteParcial(DateTime fechaInicio, DateTime fechaFinal)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@FECHA_INICIO", fechaInicio));
            lP.Add(new SqlParameter("@FECHA_FINAL", fechaFinal));
            return oSql.TablaParametroJSON("WEB_REPORTE_R_INFORMACION_PARCIAL", lP);
        }

        public static string ReporteFinal(string reportes)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@REPORTES", reportes));
            return oSql.TablaParametroJSON("WEB_REPORTE_R_PRODUCTIVIDAD", lP);
        }

        #endregion

    }
}
