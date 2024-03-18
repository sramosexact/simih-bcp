using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_Entity : Core.Entity
    {

        #region Propiedades
        [DataMember]
        public int iId { get; set; }

        [DataMember]
        public int iIdPeriodo { get; set; }
        #endregion

        #region Metodos

        public string ListarEntidadPorPeriodo(int iIdPeriodo, string entidad)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@sNombreTabla", entidad));
            return oSql.TablaParametroJSON("PF_R_TABLA", lP);
        }



        #endregion
    }
}
