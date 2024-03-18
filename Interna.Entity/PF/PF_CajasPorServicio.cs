using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_CajasPorServicio : PF_Entity
    {

        #region Metodos
        [DataMember]
        public int limaOPRansa { get; set; }
        [DataMember]
        public int multibancaRansa { get; set; }
        [DataMember]
        public int multibancaEnotria { get; set; }
        [DataMember]
        public int cajasPorCoordinacion { get; set; }
        #endregion


        #region Metodos

        public PF_CajasPorServicio()
        {

        }

        public PF_CajasPorServicio(int iIdPeriodo, int limaOPRansa, int multibancaRansa, int multibancaEnotria, int cajasPorCoordinacion)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.limaOPRansa = limaOPRansa;
            this.multibancaRansa = multibancaRansa;
            this.multibancaEnotria = multibancaEnotria;
            this.cajasPorCoordinacion = cajasPorCoordinacion;
        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@limaOPRansa", limaOPRansa));
            lP.Add(new SqlParameter("@multibancaRansa", multibancaRansa));
            lP.Add(new SqlParameter("@multibancaEnotria", multibancaEnotria));
            lP.Add(new SqlParameter("@cajasPorCoordinacion", cajasPorCoordinacion));
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_CAJASPORSERVICIO", lP));
        }

        #endregion
    }
}
