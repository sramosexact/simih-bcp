using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_EXT_TarjetasGremio : PF_Entity
    {
        #region Propiedades
        [DataMember]
        public int lima { get; set; }

        [DataMember]
        public int provincia { get; set; }
        #endregion

        #region Metodos
        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID_PERIODO", iIdPeriodo));
            lP.Add(new SqlParameter("@LIMA", lima));
            lP.Add(new SqlParameter("@PROVINCIA", provincia));
            return Convert.ToInt32(oSql.Escalar("PF_EXT_TARJETASGREMIO_U_ACTUALIZARPERIODO", lP));
        }
        #endregion
    }
}
