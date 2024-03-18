using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class CorrespondenciaNotificacion : Core.Entity
    {
        [DataMember]
        public string Autogenerado { get; set; }
        [DataMember]
        public string BandejaVirtualDestino { get; set; }
        [DataMember]
        public string BandejaFisica { get; set; }
        [DataMember]
        public string CorreoUsuario { get; set; }
        [DataMember]
        public string TipoDocumento { get; set; }
        [DataMember]
        public DateTime FechaHoraResultado { get; set; }
    }
}
