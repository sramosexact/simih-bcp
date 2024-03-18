using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class TipoReclamoUTD : Core.Entity
    {
        #region Propiedades

        [DataMember]
        public byte iIdTipoReclamoUTD { get; set; }

        [DataMember]
        public string sDescripcionTipoReclamoUTD { get; set; }

        [DataMember]
        public string sObservacionTipoReclamoUTD { get; set; }

        [DataMember]
        public byte iActivoTipoReclamoUTD { get; set; }

        #endregion

        #region Metodos

        public string ListarTipoReclamoUTDActivo()
        {
            return new sql().TablaJSON("PC_RECLAMO_LISTAR_TIPO_RECLAMO_UTD");
        }

        public string ListarResumenTipoReclamoMes(DateTime fecha)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@dPeriodo", fecha));
            return new sql().TablaParametroJSON("PC_RECLAMO_R_LISTAR_TIPO_RECLAMO_RESUMEN", lP);
        }

        public string ListarCantidadPorTiposReclamo(DateTime fechaInicio, DateTime fechaFin)
        {

            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@FECHAINICIO", fechaInicio));
            lP.Add(new SqlParameter("@FECHAFIN", fechaFin));
            return new sql().TablaParametroJSON("WEB_REPORTES_LISTAR_CANTIDAD_TIPOS_RECLAMO", lP);
        }

        #endregion
    }
}
