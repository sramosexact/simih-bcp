using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_Otros : PF_Entity
    {
        #region Propiedades

        [DataMember]
        public int segurosCodigoBarras { get; set; }
        [DataMember]
        public int segurosSinCodigoBarras { get; set; }
        [DataMember]
        public int solicitudesCreditoLima { get; set; }
        [DataMember]
        public int solicitudesCreditoProvincia { get; set; }
        [DataMember]
        public int tokenLima { get; set; }
        [DataMember]
        public int tokenProvincia { get; set; }

        #endregion

        #region Metodos
        public PF_Otros()
        {

        }

        public PF_Otros(int iIdPeriodo, int segurosCodigoBarras, int segurosSinCodigoBarras, int solicitudesCreditoLima, int solicitudesCreditoProvincia, int tokenLima, int tokenProvincia)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.segurosCodigoBarras = segurosCodigoBarras;
            this.segurosSinCodigoBarras = segurosSinCodigoBarras;
            this.solicitudesCreditoLima = solicitudesCreditoLima;
            this.solicitudesCreditoProvincia = solicitudesCreditoProvincia;
            this.tokenLima = tokenLima;
            this.tokenProvincia = tokenProvincia;
        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@segurosCodigoBarras", segurosCodigoBarras));
            lP.Add(new SqlParameter("@segurosSinCodigoBarras", segurosSinCodigoBarras));
            lP.Add(new SqlParameter("@solicitudesCreditoLima", solicitudesCreditoLima));
            lP.Add(new SqlParameter("@solicitudesCreditoProvincia", solicitudesCreditoProvincia));
            lP.Add(new SqlParameter("@tokenLima", tokenLima));
            lP.Add(new SqlParameter("@tokenProvincia", tokenProvincia));
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_OTROS", lP));
        }

        #endregion
    }
}
