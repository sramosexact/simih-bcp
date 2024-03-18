using Interna.Core;
using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class TipoReclamoJefe : Core.Entity
    {
        #region Propiedades
        [DataMember]
        public byte iIdTipoReclamoJefe { get; set; }

        [DataMember]
        public string sDescripcion { get; set; }
        #endregion

        #region Metodos

        public string ListarTiposReclamoJefe()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("PC_RECLAMO_R_LISTAR_TIPO_RECLAMO_JEFE");
        }

        #endregion
    }
}
