using Interna.Core;
using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class TipoReclamoUsuario : Interna.Core.Entity
    {
        #region Propiedades

        [DataMember]
        public byte iIdTipoReclamoUsuario { get; set; }

        [DataMember]
        public string sDescripcionTipoReclamoUsuario { get; set; }

        [DataMember]
        public byte iActivoTipoReclamoUsuario { get; set; }

        #endregion

        #region Metodos

        public string ListarTipoReclamoUsuario()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("WEB_RECLAMO_LISTAR_TIPO_RECLAMO_USUARIO");
        }

        #endregion

    }
}
