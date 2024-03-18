using Interna.Core;
using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class TipoDocumentoExterno : Core.Entity
    {
        #region Propiedades

        [DataMember]
        public byte iIdTipoDocumentoExterno { get; set; }
        [DataMember]
        public string sDescripcionTipoDocumentoExterno { get; set; }
        [DataMember]
        public byte iIdTipoDestinoExterno { get; set; }

        #endregion

        #region Metodos

        //2022
        public string ListarTipoDocumentoExterno()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("SIMIH_DOCUMENTOEXTERNO_R_LISTAR");
        }

        #endregion

    }
}
