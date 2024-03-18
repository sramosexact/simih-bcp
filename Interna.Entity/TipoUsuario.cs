using Interna.Core;
using Interna.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class TipoUsuario : Interna.Core.Entity, ITipoUsuario
    {
        #region propiedades
        [DataMember]
        public byte iIdTipoUsuario { get; set; }
        [DataMember]
        public string sDescripcionTipoUsuario { get; set; }
        #endregion
        #region Metodos
        //2022
        public string ListarTipoUsuario()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdTipoUsuario", this.iIdTipoUsuario));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_TIPOUSUARIO", oP);
        }

        #endregion
    }
}
