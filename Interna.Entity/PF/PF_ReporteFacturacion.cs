using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_ReporteFacturacion : PF_Entity
    {
        #region Propiedades
        [DataMember]
        public string descripcion { get; set; }
        [DataMember]
        public string ultimoPeriodo { get; set; }
        [DataMember]
        public string penultimoPeriodo { get; set; }
        [DataMember]
        public string antepenultimoPeriodo { get; set; }
        [DataMember]
        public int enero { get; set; }
        [DataMember]
        public int febrero { get; set; }
        [DataMember]
        public int marzo { get; set; }
        [DataMember]
        public int abril { get; set; }
        [DataMember]
        public int mayo { get; set; }
        [DataMember]
        public int junio { get; set; }
        [DataMember]
        public int julio { get; set; }
        [DataMember]
        public int agosto { get; set; }
        [DataMember]
        public int setiembre { get; set; }
        [DataMember]
        public int octubre { get; set; }
        [DataMember]
        public int noviembre { get; set; }
        [DataMember]
        public int diciembre { get; set; }
        [DataMember]
        public int total { get; set; }
        [DataMember]
        public string meses { get; set; }
        [DataMember]
        public int cantidad { get; set; }
        #endregion

        #region Metodos
        public List<string> generarReporteFacturacion(int IdPeriodo)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", IdPeriodo));
            return oSql.ListaTablaParametroJSON("PF_R_REPORTE_FACTURACION", lP);
        }
        public string generarReporteMonitor(int IdPeriodo)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", IdPeriodo));
            return oSql.TablaParametroJSON("PF_R_REPORTE_MONITOR", lP);
        }
        public List<string> generarReporteResumenReclamo(int IdPeriodo)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@Periodo", IdPeriodo));
            return oSql.ListaTablaParametroJSON("PC_REPORTE_RECLAMOS_RESUMEN", lP);
        }
        #endregion

    }
}
