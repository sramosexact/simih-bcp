using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_MesaPartesSIS : PF_Entity
    {
        #region Propiedades

        [DataMember]
        public int documentosExterior { get; set; }
        [DataMember]
        public int embargosCoactivos { get; set; }

        #endregion

        #region Metodos

        public PF_MesaPartesSIS()
        {

        }

        public PF_MesaPartesSIS(int iIdPeriodo, int documentosExterior, int embargosCoactivos)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.documentosExterior = documentosExterior;
            this.embargosCoactivos = embargosCoactivos;
        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@documentosExterior", documentosExterior));
            lP.Add(new SqlParameter("@embargosCoactivos", embargosCoactivos));
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_MESAPARTESSIS", lP));
        }

        #endregion
    }
}
