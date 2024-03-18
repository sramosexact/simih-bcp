using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_EXT_TarjetasExterior : PF_Entity
    {
        #region Propiedades
        [DataMember]
        public int debito { get; set; }

        [DataMember]
        public int credito { get; set; }
        #endregion

        #region Metodos
        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID_PERIODO", iIdPeriodo));
            lP.Add(new SqlParameter("@DEBITO", debito));
            lP.Add(new SqlParameter("@CREDITO", credito));
            return Convert.ToInt32(oSql.Escalar("PF_EXT_TARJETASEXTERIOR_U_ACTUALIZARPERIODO", lP));
        }
        #endregion
    }
}
