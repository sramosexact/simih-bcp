using Interna.Core;
using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class TipoFeriado : Core.Entity
    {
        #region Propiedades
        [DataMember]
        public byte iIdTipoFeriado { get; set; }

        [DataMember]
        public string sDescripcionTipoFeriado { get; set; }

        #endregion

        #region Metodos
        //2022
        public string ListarTiposFeriado()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("SIMIH_MANTENIMIENTOFERIADO_R_TIPOFERIADO");
        }

        #endregion
    }
}
