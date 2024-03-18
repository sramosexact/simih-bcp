using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_ChequerasVerbales : PF_Entity
    {
        #region Propiedades

        [DataMember]
        public int chequerasLima { get; set; }
        [DataMember]
        public int chequerasProvincia { get; set; }
        [DataMember]
        public int verbalesCreditoLima { get; set; }
        [DataMember]
        public int verbalesCreditoProvincia { get; set; }
        [DataMember]
        public int verbalesDebitoLima { get; set; }
        [DataMember]
        public int verbalesDebitoProvincia { get; set; }

        #endregion

        #region Metodos

        public PF_ChequerasVerbales()
        {

        }

        public PF_ChequerasVerbales(int iIdPeriodo, int chequerasLima, int chequerasProvincia, int verbalesCreditoLima, int verbalesCreditoProvincia, int verbalesDebitoLima, int verbalesDebitoProvincia)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.chequerasLima = chequerasLima;
            this.chequerasProvincia = chequerasProvincia;
            this.verbalesCreditoLima = verbalesCreditoLima;
            this.verbalesCreditoProvincia = verbalesCreditoProvincia;
            this.verbalesDebitoLima = verbalesDebitoLima;
            this.verbalesDebitoProvincia = verbalesDebitoProvincia;

        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@chequerasLima", chequerasLima));
            lP.Add(new SqlParameter("@chequerasProvincia", chequerasProvincia));
            lP.Add(new SqlParameter("@verbalesCreditoLima", verbalesCreditoLima));
            lP.Add(new SqlParameter("@verbalesCreditoProvincia", verbalesCreditoProvincia));
            lP.Add(new SqlParameter("@verbalesDebitoLima", verbalesDebitoLima));
            lP.Add(new SqlParameter("@verbalesDebitoProvincia", verbalesDebitoProvincia));
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_CHEQUERASVERBALES", lP));
        }

        #endregion
    }
}
