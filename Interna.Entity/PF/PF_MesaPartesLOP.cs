using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_MesaPartesLOP : PF_Entity
    {
        #region Propiedades

        [DataMember]
        public int oficiosLegal { get; set; }
        [DataMember]
        public int sellosPersonalBanco { get; set; }
        [DataMember]
        public int aduanasVoucher { get; set; }

        #endregion

        #region Metodos

        public PF_MesaPartesLOP()
        {

        }

        public PF_MesaPartesLOP(int iIdPeriodo, int oficiosLegal, int sellosPersonalBanco, int aduanasVoucher)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.oficiosLegal = oficiosLegal;
            this.sellosPersonalBanco = sellosPersonalBanco;
            this.aduanasVoucher = aduanasVoucher;
        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@oficiosLegal", oficiosLegal));
            lP.Add(new SqlParameter("@sellosPersonalBanco", sellosPersonalBanco));
            lP.Add(new SqlParameter("@aduanasVoucher", aduanasVoucher));
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_MESAPARTESLOP", lP));
        }

        #endregion
    }
}
