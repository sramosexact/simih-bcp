using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_BolsasNaranjas : PF_Entity
    {
        #region Propiedades

        [DataMember]
        public int dentroProvincia { get; set; }
        [DataMember]
        public int fueraLima { get; set; }
        [DataMember]
        public int fueraProvincia { get; set; }

        #endregion

        #region Metodos

        public PF_BolsasNaranjas()
        {

        }

        public PF_BolsasNaranjas(int iIdPeriodo, int dentroProvincia, int fueraLima, int fueraProvincia)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.dentroProvincia = dentroProvincia;
            this.fueraLima = fueraLima;
            this.fueraProvincia = fueraProvincia;
        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@dentroProvincia", dentroProvincia));
            lP.Add(new SqlParameter("@fueraLima", fueraLima));
            lP.Add(new SqlParameter("@fueraProvincia", fueraProvincia));
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_BOLSASNARANJAS", lP));
        }

        #endregion
    }
}
