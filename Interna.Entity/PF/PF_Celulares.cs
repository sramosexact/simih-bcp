using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_Celulares : PF_Entity
    {
        #region Propiedades

        [DataMember]
        public int celularesLimaColaborador { get; set; }
        [DataMember]
        public int celularesLimaBanco { get; set; }
        [DataMember]
        public int celularesProvinciaColaborador { get; set; }
        [DataMember]
        public int celularesProvinciaBanco { get; set; }

        #endregion

        #region Metodos

        public PF_Celulares()
        {

        }

        public PF_Celulares(int iIdPeriodo, int celularesLimaColaborador, int celularesLimaBanco, int celularesProvinciaColaborador, int celularesProvinciaBanco)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.celularesLimaColaborador = celularesLimaColaborador;
            this.celularesLimaBanco = celularesLimaBanco;
            this.celularesProvinciaColaborador = celularesProvinciaColaborador;
            this.celularesProvinciaBanco = celularesProvinciaBanco;
        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@celularesLimaColaborador", celularesLimaColaborador));
            lP.Add(new SqlParameter("@celularesLimaBanco", celularesLimaBanco));
            lP.Add(new SqlParameter("@celularesProvinciaColaborador", celularesProvinciaColaborador));
            lP.Add(new SqlParameter("@celularesProvinciaBanco", celularesProvinciaBanco));
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_CELULARES", lP));
        }



        #endregion
    }
}
