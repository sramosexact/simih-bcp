using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class ReporteProductividadGrupo : Core.Entity
    {
        #region Propiedades

        [DataMember]
        public int iId { get; set; }
        [DataMember]
        public DateTime dFechaCarga { get; set; }
        [DataMember]
        public string sDescripcion { get; set; }
        [DataMember]
        public int iIdUsuario { get; set; }

        [DataMember]
        public string xmlReporte { get; set; }

        #endregion

        #region Metodos

        public static string ListarReporteProductividadGrupo(DateTime fechaInicio, DateTime fechaFinal)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@FECHA_INICIO", fechaInicio));
            lP.Add(new SqlParameter("@FECHA_FINAL", fechaFinal));
            return oSql.TablaParametroJSON("WEB_GRUPO_R_REPORTE_PRODUCTIVIDAD", lP);
        }

        public int ImportarReporteProductividad(string nombreArchivo)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@REPORTE_XML", xmlReporte));
            lP.Add(new SqlParameter("@NOMBRE_ARCHIVO", nombreArchivo));
            return Convert.ToInt32(oSql.Escalar("WEB_REPORTE_PRODUCTIVIDAD_C_IMPORTAR", lP));
        }

        public int EliminarReporteProductividad(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("ID", id));
            return Convert.ToInt32(oSql.Escalar("WEB_REPORTE_PRODUCTIVIDAD_D_ELIMINAR", lP));
        }


        #endregion

    }
}
