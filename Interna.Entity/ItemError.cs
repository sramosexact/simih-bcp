using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Interna.Entity
{
    [Serializable]
    public class ItemError : Interna.Core.Entity
    {
        #region Propiedades
        public int ID { get; set; }
        public int CodigoCabecera { get; set; }
        public string CodigoExterno { get; set; }
        public int IdError { get; set; }
        public DateTime CreadoEl { get; set; }
        public int IdUsuario { get; set; }

        public string Error { get; set; }
        public string TipoDocumento { get; set; }
        #endregion

        public List<ItemError> lItemError()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCARGA", CodigoCabecera));
            return oSql.TablaParametro<ItemError>("EXI_R_ITEM_ERROR", oP);
        }
    }
}
