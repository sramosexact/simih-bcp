using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_EXT_GestionCampanas : PF_Entity
    {
        #region Propiedades
        [DataMember]
        public int campanasGestionadas { get; set; }

        [DataMember]
        public int basesGestionadas { get; set; }

        [DataMember]
        public int registrosGestionados { get; set; }
        #endregion

        #region Metodos
        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID_PERIODO", iIdPeriodo));
            lP.Add(new SqlParameter("@CAMPANAS_GESTIONADAS", campanasGestionadas));
            lP.Add(new SqlParameter("@BASES_GESTIONADAS", basesGestionadas));
            lP.Add(new SqlParameter("@REGISTROS_GESTIONADOS", registrosGestionados));
            return Convert.ToInt32(oSql.Escalar("PF_EXT_GESTIONCAMPANAS_U_ACTUALIZARPERIODO", lP));
        }
        #endregion
    }
}
