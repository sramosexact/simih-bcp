using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_DocumentosRecogidosSerpost : PF_Entity
    {
        #region Propiedades

        [DataMember]
        public int recogidosLOP { get; set; }
        [DataMember]
        public int recogidosLMO { get; set; }

        #endregion

        #region Metodos

        public PF_DocumentosRecogidosSerpost()
        {

        }

        public PF_DocumentosRecogidosSerpost(int iIdPeriodo, int recogidosLOP, int recodigosLMO)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.recogidosLOP = recogidosLOP;
            this.recogidosLMO = recodigosLMO;
        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@recogidosLOP", recogidosLOP));
            lP.Add(new SqlParameter("@recogidosLMO", recogidosLMO));
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_DOCUMENTOSRECOGIDOSSERPOST", lP));
        }

        #endregion
    }
}
