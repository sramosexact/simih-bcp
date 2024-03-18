using System;
using System.Runtime.Serialization;

namespace Interna.Entity.Estructuras
{
    [Serializable]
    [DataContract]
    public class ListaTipoDocumentoView : Core.Entity, Interfaces.ITipoDocumento, Interfaces.ITipoCorrespondencia
    {
        #region Propiedades
        [DataMember]
        public Int16 iIdTipoDocumento { get; set; }
        [DataMember]
        public String sDescripcionTipoDocumento { get; set; }
        [DataMember]
        public Byte iIdTipoCorrespondencia { get; set; }
        [DataMember]
        public String sDescripcionTipoCorrespondencia { get; set; }
        [DataMember]
        public Byte iMoneda { get; set; }
        [DataMember]
        public String sDescripcionValor { get; set; }
        [DataMember]
        public bool requiereDigitalizacion { get; set; }
        [DataMember]
        public bool entregaPersonalizada { get; set; }
        #endregion
    }
}
