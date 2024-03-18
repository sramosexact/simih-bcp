using System;
using System.Runtime.Serialization;

namespace Interna.Entity.Estructuras
{
    [Serializable]
    [DataContract]
    public class ListaTipoReclamoUTDView : Core.Entity
    {
        #region Propiedades

        [DataMember]
        public byte iIdTipoReclamoUTD { get; set; }

        [DataMember]
        public string sDescripcionTipoReclamoUTD { get; set; }

        [DataMember]
        public int iCantidadReclamos { get; set; }

        [DataMember]
        public int iCantidadFundados { get; set; }

        [DataMember]
        public byte iExpedicion { get; set; }

        [DataMember]
        public string sExpedicion { get; set; }

        #endregion

    }
}
