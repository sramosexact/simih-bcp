using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_Valijas : PF_Entity
    {
        #region Propiedades

        [DataMember]
        public int enviadasLima { get; set; }
        [DataMember]
        public int enviadasProvincia { get; set; }
        [DataMember]
        public int incidenciasOperativa { get; set; }
        [DataMember]
        public int incidenciasComercial { get; set; }

        [DataMember]
        public int valijasLima { get; set; }
        [DataMember]
        public int valijasProvincia { get; set; }

        #endregion

        #region Metodos

        public PF_Valijas()
        {

        }

        public PF_Valijas(int iIdPeriodo, int enviadasLima, int enviadasProvincia, int incidenciasOperativa, int incidenciasComercial)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.enviadasLima = enviadasLima;
            this.enviadasProvincia = enviadasProvincia;
            this.incidenciasOperativa = incidenciasOperativa;
            this.incidenciasComercial = incidenciasComercial;
        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@enviadasLima", enviadasLima));
            lP.Add(new SqlParameter("@enviadasProvincia", enviadasProvincia));
            lP.Add(new SqlParameter("@incidenciasOperativa", incidenciasOperativa));
            lP.Add(new SqlParameter("@incidenciasComercial", incidenciasComercial)); ;
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_VALIJAS", lP));
        }

        #endregion
    }
}
