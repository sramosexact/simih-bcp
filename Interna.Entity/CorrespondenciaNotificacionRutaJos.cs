using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class CorrespondenciaNotificacionRutaJos : Core.Entity
    {
        [DataMember]
        public string Autogenerado { get; set; }
        [DataMember]
        public string BandejaVirtualDestino { get; set; }
        [DataMember]
        public string CodigoAgencia { get; set; }
        [DataMember]
        public string Agencia { get; set; }
        [DataMember]
        public string CorreoUsuario { get; set; }
        [DataMember]
        public string TipoDocumento { get; set; }
    }
}
