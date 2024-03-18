using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_AgentesBCP : PF_Entity
    {


        #region Propiedades

        [DataMember]
        public int boletas { get; set; }
        [DataMember]
        public int facturas { get; set; }

        #endregion

        #region Metodos

        public PF_AgentesBCP()
        {

        }

        public PF_AgentesBCP(int iIdPeriodo, int boletas, int facturas)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.boletas = boletas;
            this.facturas = facturas;
        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@boletas", boletas));
            lP.Add(new SqlParameter("@facturas", facturas));
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_AGENTESBCP", lP));
        }

        #endregion
    }
}
