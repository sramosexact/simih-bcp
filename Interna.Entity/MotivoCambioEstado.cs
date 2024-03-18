using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class MotivoCambioEstado : Core.Entity
    {
        #region Propiedades
        [DataMember]
        public byte iIdMotivoCambioEstado { get; set; }
        [DataMember]
        public string sDescripcion { get; set; }
        [DataMember]
        public int iIdTipoEstado { get; set; }
        [DataMember]
        public byte iActivo { get; set; }

        #endregion

        #region Metodos
        //2022
        public string ListarMotivoCambioEstadoPorTipoEstado(int iIdTipoEstado)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdTipoEstado", iIdTipoEstado));
            return oSql.TablaParametroJSON("SIMIH_CAMBIOESTADO_R_MOTIVOCAMBIOESTADO_POR_TIPOESTADO", lP);

        }

        public string listarCantidadPorMotivoCambioEstado(DateTime fechaInicio, DateTime fechaFin)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@FECHAINICIO", fechaInicio));
            lP.Add(new SqlParameter("@FECHAFIN", fechaFin));
            return oSql.TablaParametroJSON("WEB_REPORTES_LISTAR_CANTIDAD_MOTIVOS_RETIRADOS", lP);
        }

        #endregion
    }
}
