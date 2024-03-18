using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_DocumentosProcesadosUTD : PF_Entity
    {
        #region Propiedades

        [DataMember]
        public int sunass { get; set; }
        [DataMember]
        public int tarjetasPresentacion { get; set; }

        [DataMember]
        public int periodicosEntregados { get; set; }

        [DataMember]
        public int campanasInternas { get; set; }

        #endregion

        #region Metodos

        public PF_DocumentosProcesadosUTD()
        {

        }

        public PF_DocumentosProcesadosUTD(int iIdPeriodo, int sunass, int tarjetasPresentacion, int periodicosEntregados, int campanasInternas)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.sunass = sunass;
            this.tarjetasPresentacion = tarjetasPresentacion;
            this.periodicosEntregados = periodicosEntregados;
            this.campanasInternas = periodicosEntregados;
        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@sunass", sunass));
            lP.Add(new SqlParameter("@tarjetasPresentacion", tarjetasPresentacion));
            lP.Add(new SqlParameter("@periodicosEntregados", periodicosEntregados));
            lP.Add(new SqlParameter("@campanasInternas", campanasInternas));
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_DOCUMENTOSPROCESADOSUTD", lP));
        }

        #endregion


    }
}
