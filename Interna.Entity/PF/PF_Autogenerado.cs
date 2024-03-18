using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_Autogenerado : PF_Entity
    {
        #region Propiedades
        [DataMember]
        public int cantidad { get; set; }
        [DataMember]
        public string expedicion { get; set; }
        [DataMember]
        public int autogeneradosLOP { get; set; }
        [DataMember]
        public int autogeneradosSIS { get; set; }
        [DataMember]
        public int autogeneradosLMO { get; set; }
        #endregion

        #region Metodos

        public PF_Autogenerado()
        {

        }

        public PF_Autogenerado(int iIdPeriodo)
        {
            this.iIdPeriodo = iIdPeriodo;
        }

        public string ListarAutogeneradosSede()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            return oSql.TablaParametroJSON("PF_AUTOGENERADO_R_LISTAR_AUTOGENERADOS_POR_SEDE", lP);
        }

        public string ListarAutogeneradosEntregados()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            return oSql.TablaParametroJSON("PF_AUTOGENERADO_R_LISTAR_AUTOGENERADOS_ENTREGADOS", lP);
        }

        public string ListarAutogeneradosMesaPartes()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            return oSql.TablaParametroJSON("PF_AUTOGENERADO_R_LISTAR_POR_MESA_PARTES", lP);
        }
        #endregion


    }
}
